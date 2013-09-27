﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace libInterface
{
	public interface ICache
	{
		/// <summary>
		/// Gets the number of items in the cache.
		/// </summary>
//	int Count { get; }


		/// <summary>
		/// Gets a collection of all cache item keys.
		/// </summary>
//ICollection Keys { get; }


		/// <summary>
		/// Whether or not there is a cache entry for the specified key.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		bool Contains(string key);


		/// <summary>
		/// Retrieves an item from the cache.
		/// </summary>
		object Get(object key);


		/// <summary>
		/// Retrieves an item from the cache of the specified type.
		/// </summary>
		T Get<T>(object key);


		/// <summary>
		/// Retrieves an item from the cache of the specified type and key and 
		/// inserts by getting it using the lamda it if isn't there
		/// </summary>
		T GetOrInsert<T>(object key, int timeToLiveInSeconds, bool slidingExpiration, Func<T> fetcher);


		/// <summary>
		/// Removes an item from the cache.
		/// </summary>
		void Remove(object key);


		/// <summary>
		/// Removes collection of items from the cache.
		/// </summary>
		void RemoveAll(ICollection keys);


		/// <summary>
		/// Removes all items from the cache.
		/// </summary>
		void Clear();


		/// <summary>
		/// Inserts an item into the cache.
		/// </summary>
		void Insert(object key, object value);


		/// <summary>
		/// Inserts an item into the cache.
		/// </summary>
		void Insert(object key, object value, int timeToLive, bool slidingExpiration);


		/// <summary>
		/// Inserts an item into the cache.
		/// </summary>
		//void Insert(object key, object value, int timeToLive, bool slidingExpiration, CacheItemPriority priority);


		/// <summary>
		/// Get description of the cache entries.
		/// </summary>
		/// <returns></returns>
		//IList<CacheItemDescriptor> GetDescriptors();
	}
}
