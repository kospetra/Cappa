using AnimalHotelSystem.Model;
using System.Collections.Generic;


namespace AnimalHotelSystem.RepositoryInterface
{
    public interface IAnimalFoodRepository
    {
        AnimalFood GetAnimalFoodByName(string name);
        List<AnimalFood> GetAllAnimalFoodByAgeGroup(AgeOfAnimal inAgeOfAnimalEnum);
        List<AnimalFood> GetAllAnimalFoodByType(TypeOfAnimal inTypeOfAnimalEnum);
        List<AnimalFood> GetAllAnimalFood();

        AnimalFood GetAppropriateAnimalFood(Animal animal);

        void AddNewFood(AnimalFood inAnimalFood);
        void UpdateFood(AnimalFood inAnimalFood);
        void RemoveFood(string name);

    }
}
