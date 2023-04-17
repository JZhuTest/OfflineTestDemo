using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Helpers;

namespace PizzeriaDemoAPI.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IMemoryCache _memoryCache;

        public LocationRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IEnumerable<Location> GetAll()
        {
            return CacheReader.GetAll<Location>(_memoryCache, 
                                                Constant.LocationAllCacheKey, 
                                                Constant.LocationFilePath,
                                                (s) => FileReader.ReadLocationsFromCsvFile(s));
        }
    }
}