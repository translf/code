using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libInterface
{
	class aspnetCache:ICache
	{
		//public int Count
		//{
		//    get { throw new NotImplementedException(); }
		//}

		//public System.Collections.ICollection Keys
		//{
		//    get { throw new NotImplementedException(); }
		//}

		public bool Contains(string key)
		{
			throw new NotImplementedException();
		}

		public object Get(object key)
		{
			throw new NotImplementedException();
		}

		public T Get<T>(object key)
		{
			throw new NotImplementedException();
		}

		public T GetOrInsert<T>(object key, int timeToLiveInSeconds, bool slidingExpiration, Func<T> fetcher)
		{
			throw new NotImplementedException();
		}

		public void Remove(object key)
		{
			throw new NotImplementedException();
		}

		public void RemoveAll(System.Collections.ICollection keys)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void Insert(object key, object value)
		{
			throw new NotImplementedException();
		}

		public void Insert(object key, object value, int timeToLive, bool slidingExpiration)
		{
			throw new NotImplementedException();
		}
	}
}
