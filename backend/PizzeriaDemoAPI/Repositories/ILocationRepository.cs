using PizzeriaDemoAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace PizzeriaDemoAPI.Repositories
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();
    }
}