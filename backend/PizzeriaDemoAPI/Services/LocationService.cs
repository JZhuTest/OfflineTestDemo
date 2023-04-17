using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Repositories;

namespace PizzeriaDemoAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _repository.GetAll();
        }
    }
}