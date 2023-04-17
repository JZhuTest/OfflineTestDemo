using System.IO;

namespace PizzeriaDemoAPI.Helpers
{
    public class Constant
    {
        public static string LocationFilePath = $"{Directory.GetCurrentDirectory()}/Resources/Location.csv";
        public static string IngredientFilePath = $"{Directory.GetCurrentDirectory()}/Resources/Ingredient.csv";
        public static string PizzaTypeFilePath = $"{Directory.GetCurrentDirectory()}/Resources/PizzaType.csv";
        public static string MenuItemFilePath = $"{Directory.GetCurrentDirectory()}/Resources/MenuItem.csv";

        public static readonly string LocationAllCacheKey = "locationAllCacheKey";
        public static readonly string IngredientAllCacheKey = "ingredientAllCacheKey";
        public static readonly string PizzaTypeAllCacheKey = "pizzaTypeAllCacheKey";
        public static readonly string MenuAllCacheKey = "menuAllCacheKey";
    }
}