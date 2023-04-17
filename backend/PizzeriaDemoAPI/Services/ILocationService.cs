using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Repositories;
using System.Threading.Tasks;

namespace PizzeriaDemoAPI.Services
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
    }
}