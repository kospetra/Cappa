using AnimalHotelSystem.Database.Repository.Repositories;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using System.Collections.Generic;

namespace AnimalHotelSystem.Application.Services
{
    public class ToyService
    {
        private readonly IToyRepository _toyRepository;

        public ToyService()
        {
            //_toyRepository = ToyRepository.GetInstance();
            _toyRepository = new ToyRepository();
        }

        public void AddToy(FrameAddNewToy newToy)
        {
            var toy = new Toy(newToy.Name, newToy.TypeOfAnimal);

            _toyRepository.AddToy(toy);
        }

        public List<Toy> GetAllToys()
        {
            return _toyRepository.GetAllToys();
        }
    }
}
