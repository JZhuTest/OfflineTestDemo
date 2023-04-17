using PizzeriaDemoAPI.Models;

namespace PizzeriaDemoAPI.Repositories
{
    public interface IMenuRepository
    {
        IEnumerable<MenuItem> GetMenuByLocation(int locationId);
    }
}