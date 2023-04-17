using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Repositories;

namespace PizzeriaDemoAPI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _repository;
        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ingredient> GetTopIngredients()
        {
            return _repository.GetTopIngredients();
        }
    }
}