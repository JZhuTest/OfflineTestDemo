using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Repositories;

namespace PizzeriaDemoAPI.Services
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetTopIngredients();
    }
}