﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Concurrent;
using STSdb4.Data;

namespace STSdb4.WaterfallTree
{
    public partial class WTree
    {
        private class BranchesOptimizator
        {
            private const int MAP_CAPACITY = 131072;
            private ConcurrentDictionary<ILocator, Range> Map = new ConcurrentDictionary<ILocator, Range>();
            private BranchCollection Branches;

            public BranchesOptimizator()
            {
            }

            public void Rebuild(BranchCollection branches)
            {
                Branches = branches;
                Map = BuildRanges();
            }

            private ConcurrentDictionary<ILocator, Range> BuildRanges()
            {
                ConcurrentDictionary<ILocator, Range> map = new ConcurrentDictionary<ILocator, Range>();
                var path = Branches[0].Key.Locator;
                Range range = new Range(0, true);
                map[path] = range;

                for (int i = 1; i < Branches.Count; i++)
                {
                    var newpath = Branches[i].Key.Locator;

                    if (newpath.Equals(path))
                    {
                        range.LastIndex = i;
                        continue;
                    }

                    path = newpath;
                    map[path] = range = new Range(i, true);
                }

                return map;
            }

            public Range FindRange(ILocator locator)
            {
                Range range;

                if (Map.TryGetValue(locator, out range))
                    return range;

                int idx = Branches.BinarySearch(new FullKey(locator, null));
                Debug.Assert(idx < 0);
                idx = ~idx - 1;
                Debug.Assert(idx >= 0);

                Map[locator] = range = new Range(idx, false);

                if (Map.Count > MAP_CAPACITY)
                    Map = BuildRanges(); //TODO: background rebuild

                return range;
            }

            public int FindIndex(Range range, ILocator locator, IData key)
            {
                if (!range.IsBaseLocator)
                    return range.LastIndex;

                int cmp = locator.KeyComparer.Compare(key, Branches[range.LastIndex].Key.Key);
                if (cmp >= 0)
                    return range.LastIndex;

                if (range.FirstIndex == range.LastIndex)
                    return range.LastIndex - 1;

                int idx = Branches.BinarySearch(new FullKey(locator, key), range.FirstIndex, range.LastIndex - range.FirstIndex, LightComparer.Instance);
                if (idx < 0)
                    idx = ~idx - 1;

                return idx;
            }

            private class LightComparer : IComparer<KeyValuePair<FullKey, Branch>>
            {
                public readonly static LightComparer Instance = new LightComparer();

                public int Compare(KeyValuePair<FullKey, Branch> x, KeyValuePair<FullKey, Branch> y)
                {
                    //Debug.Assert(x.Key.Path.Equals(y.Key.Path));

                    return x.Key.Locator.KeyComparer.Compare(x.Key.Key, y.Key.Key);
                }
            }
        }

        [DebuggerDisplay("FirstIndex = {FirstIndex}, LastIndex = {LastIndex}, IsBaseLocator = {IsBaseLocator}")]
        private class Range
        {
            public int FirstIndex;
            public int LastIndex;
            public bool IsBaseLocator;

            public Range(int firstIndex, bool baseLocator)
            {
                FirstIndex = firstIndex;
                LastIndex = firstIndex;
                IsBaseLocator = baseLocator;
            }
        }
    }
}