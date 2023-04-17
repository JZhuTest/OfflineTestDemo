using PizzeriaDemoAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace PizzeriaDemoAPI.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetTopIngredients();
    }
}