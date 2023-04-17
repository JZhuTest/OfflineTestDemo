using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Repositories;

namespace PizzeriaDemoAPI.Services
{
    public interface IMenuService
    {
        IEnumerable<MenuItem> GetMenuByLocation(int locationId);
    }
}