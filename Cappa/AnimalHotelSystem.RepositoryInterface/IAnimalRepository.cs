using AnimalHotelSystem.Model;
using System.Collections.Generic;

namespace AnimalHotelSystem.RepositoryInterface
{
    public interface IAnimalRepository
    {
        int AddUserAnimal(Animal inUsersAnimals);
        void DeleteUSerAnimal(int inId);
        Animal GetAnimalById(int inId);
        List<Animal> GetUsersAnimals();
        List<Animal> GetUsersAnimalsByType(TypeOfAnimal inTypeOfAnimalEnum);
    }
}
