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
    public class MenuRepository : IMenuRepository
    {
        private readonly IMemoryCache _memoryCache;
        //private readonly string menuAllCacheKey = "menuAllCacheKey";

        public MenuRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IEnumerable<MenuItem> GetMenuByLocation(int locationId)
        {
            var ingredientMap = CacheReader.GetAll<Ingredient>(_memoryCache, 
                                                Constant.IngredientAllCacheKey, 
                                                Constant.IngredientFilePath, 
                                                s => FileReader.ReadIngredientsFromCsvFile(s));
                                                //FileReader.ReadIngredientsFromCsvFile(Constant.IngredientFilePath);
            var pizzaTypeMap = CacheReader.GetAll<PizzaType, Ingredient>(_memoryCache, 
                                                Constant.PizzaTypeAllCacheKey, 
                                                Constant.PizzaTypeFilePath, 
                                                ingredientMap,
                                                (s, t) => FileReader.ReadPizzaTypesFromCsvFile(s, t));
                                                //FileReader.ReadPizzaTypesFromCsvFile(Constant.PizzaTypeFilePath, ingredientMap);
            var menuItems = CacheReader.GetAll<MenuItem, PizzaType>(_memoryCache, 
                                                Constant.MenuAllCacheKey, 
                                                Constant.MenuItemFilePath, 
                                                pizzaTypeMap,
                                                (s, t) => FileReader.ReadMenuItemFromCsvFile(s, t));
                                                //FileReader.ReadMenuItemFromCsvFile(Constant.MenuItemFilePath, pizzaTypeMap);
            return menuItems.Where(m => m.LocationId == locationId);
        }
    }
}