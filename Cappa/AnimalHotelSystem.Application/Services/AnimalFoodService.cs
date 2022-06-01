using AnimalHotelSystem.Database.Repository.Repositories;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Application
{
    public class AnimalFoodService
    {
        private readonly IAnimalFoodRepository _animalFoodRepository;
        private readonly IReservationRepository _reservationRepository;

        public AnimalFoodService()
        {
            //_animalFoodRepository = AnimalFoodRepository.getInstance();
            _animalFoodRepository = new AnimalFoodRepository();
            _reservationRepository = new ReservationRepository();
        }

        public void AddNewFood(FrameAddNewFood inFoodView)
        {
            var food = new AnimalFood(inFoodView.FoodName, inFoodView.AlergensInFood,inFoodView.TypeOfAnimalGroup, inFoodView.AgeGroup, inFoodView.PortionsOfFood);
            _animalFoodRepository.AddNewFood(food);
        }

        public void ReplenishFood(string name, int addedPortions)
        {
            var food = _animalFoodRepository.GetAnimalFoodByName(name);
            food.AddNewPortionsOfFood(addedPortions);
            _animalFoodRepository.UpdateFood(food);
        }

        public void FeedAnimals()
        {
            var currentReservations = _reservationRepository.GetAllCurrentReservations();

            var servedFood = new List<AnimalFood>();
            foreach(var reservation in currentReservations)
            {
                var food = _animalFoodRepository.GetAppropriateAnimalFood(reservation.Animal);
                if(food == null)
                {
                    throw new System.Exception($"There is no appropriate food for {reservation.Animal.Name}");
                }

                if(servedFood.Any(f => f.Name == food.Name))
                {
                    food = servedFood.First(f => f.Name == food.Name);
                }
                else
                {
                    servedFood.Add(food);
                }

                food.RemovePortionsOfFood(1);
            }

            servedFood.ForEach(f => _animalFoodRepository.UpdateFood(f));
        }

        public List<AnimalFood> GetFoodList()
        {
            var food = _animalFoodRepository.GetAllAnimalFood();
            return food;
        }
    }
}
