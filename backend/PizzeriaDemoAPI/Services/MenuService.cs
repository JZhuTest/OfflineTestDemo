using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Repositories;

namespace PizzeriaDemoAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        public MenuService(IMenuRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MenuItem> GetMenuByLocation(int locationId)
        {
            return _repository.GetMenuByLocation(locationId);
        }
    }
}