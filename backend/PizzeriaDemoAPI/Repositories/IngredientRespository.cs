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
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IMemoryCache _memoryCache;

        public IngredientRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IEnumerable<Ingredient> GetTopIngredients()
        {
            return CacheReader.GetAll<Ingredient>(_memoryCache, 
                                                Constant.IngredientAllCacheKey, 
                                                Constant.IngredientFilePath,
                                                (s) => FileReader.ReadIngredientsFromCsvFile(s))
                                                .Where(i => i.IsTop);
        }
    }
}