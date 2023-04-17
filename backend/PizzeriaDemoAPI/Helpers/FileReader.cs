using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzeriaDemoAPI.Models;

namespace PizzeriaDemoAPI.Helpers
{
    public class FileReader
    {
        public static List<Location> ReadLocationsFromCsvFile(string filePath)
        {
            var locations = new List<Location>();

            using (var reader = new StreamReader(filePath))
            {
                // Skip header row
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length != 2)
                        throw new Exception($"The Location csv value {line} has wrong length");

                    locations.Add(new Location
                    {
                        Id = ConvertToInt(values[0]),
                        Name = values[1]
                    });
                }
            }

            return locations;
        }

        public static List<Ingredient> ReadIngredientsFromCsvFile(string filePath)
        {
            var ingredients = new List<Ingredient>();

            using (var reader = new StreamReader(filePath))
            {
                // Skip header row
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length != 3)
                        throw new Exception($"The Ingredients csv value {line} has wrong length");

                    ingredients.Add(new Ingredient
                    {
                        Id = ConvertToInt(values[0]),
                        Name = values[1],
                        IsTop = bool.Parse(values[2])
                    });
                }
            }

            return ingredients;
        }

        public static List<PizzaType> ReadPizzaTypesFromCsvFile(string pizzaTypeFilePath, List<Ingredient> ingredientMap)
        {
            var pizzaTypes = new List<PizzaType>();

            using (var reader = new StreamReader(pizzaTypeFilePath))
            {
                // Skip header row
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length != 3)
                        throw new Exception($"The PizzaType csv value {line} has wrong length");

                    var ingredients = GetIngredientsFromPipeline(values[2], ingredientMap);

                    pizzaTypes.Add(new PizzaType
                    {
                        Id = ConvertToInt(values[0]),
                        Name = values[1],
                        Ingredients = ingredients,
                        IngredientsDescription = ingredients.ToDelimitedString(",")
                    });
                }
            }

            return pizzaTypes;
        }

        public static List<MenuItem> ReadMenuItemFromCsvFile(string menuItemFilePath, List<PizzaType> pizzaTypeMap)
        {
            var menuItems = new List<MenuItem>();

            using (var reader = new StreamReader(menuItemFilePath))
            {
                // Skip header row
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length != 3)
                        throw new Exception($"The MenuItem csv value {line} has wrong length");

                    var pizzaTypeId = ConvertToInt(values[1]);
                    menuItems.Add(new MenuItem
                    {
                        LocationId = ConvertToInt(values[0]),
                        PizzaTypeId = pizzaTypeId,
                        Price = ConvertToDecimal(values[2]),
                        PizzaType = pizzaTypeMap.FirstOrDefault(p => p.Id == pizzaTypeId)
                    });
                }
            }

            return menuItems;
        }

        private static List<Ingredient> GetIngredientsFromPipeline(string ingredientPipeline, List<Ingredient> ingredientMap)
        {
            var ingredients = new List<Ingredient>();
            var values = ingredientPipeline?.Split('|');
            foreach(var value in values){
                var id = ConvertToInt(value);
                ingredients.Add(ingredientMap.FirstOrDefault(i => i.Id == id));
            }
            return ingredients;
        }

        private static int ConvertToInt(string value)
        {
            int val = 0;
            if (!int.TryParse(value, out val))
                throw new Exception($"Invalid integer value {value}");
            return val;
        }

        private static decimal ConvertToDecimal(string value)
        {
            decimal val = 0;
            if (!decimal.TryParse(value, out val))
                throw new Exception($"Invalid decimal value {value}");
            return val;
        }
    }
}