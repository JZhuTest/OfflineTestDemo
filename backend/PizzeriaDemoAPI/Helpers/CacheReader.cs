using Microsoft.Extensions.Caching.Memory;
using System.Globalization;

namespace PizzeriaDemoAPI.Helpers
{
    public class CacheReader
    {
        // A generic function to get cached value from a Cache store or retrieve the data
        // from the give fileReader at the first time then save into the Cache store
        public static IEnumerable<T> GetAll<T>(IMemoryCache cache, 
                                            string cacheKey, 
                                            string filePath,
                                            Func<string, IEnumerable<T>> fileReader)
        {
            IEnumerable<T> values = null;
            // If found in cache, return cached data
            if (cache.TryGetValue(cacheKey, out values))
            {
                return values;
            }

            values = fileReader(filePath);

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));

            // Set object in cache
            cache.Set(cacheKey, values, cacheOptions);
            return values;
        }

        // A generic function to get cached value from a Cache store or retrieve the data
        // from the give fileReader at the first time and find value from the given map,
        // then save into the Cache store
        public static IEnumerable<T> GetAll<T, W>(IMemoryCache cache, 
                                            string cacheKey, 
                                            string filePath,
                                            IEnumerable<W> referenceMap,
                                            Func<string, List<W>, IEnumerable<T>> fileReader)
        {
            IEnumerable<T> values = null;
            // If found in cache, return cached data
            if (cache.TryGetValue(cacheKey, out values))
            {
                return values;
            }

            values = fileReader(filePath, (List<W>)referenceMap);

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));

            // Set object in cache
            cache.Set(cacheKey, values, cacheOptions);
            return values;
        }
    }
}