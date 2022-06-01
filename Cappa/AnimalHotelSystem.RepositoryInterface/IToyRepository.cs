using AnimalHotelSystem.Model;
using System.Collections.Generic;

namespace AnimalHotelSystem.RepositoryInterface
{
    public interface IToyRepository
    {
        List<Toy> GetAllToys();
        //List<Toy> GetAllFreeToys();
        //List<Toy> GetAllFreeToysByTypeAnimal(TypeOfAnimal typeOfAnimalEnum);
        Toy GetToyById(string name);
        List<Toy> GetToysById(IList<int> toyIds);
        List<Toy> GetToyByTypeAnimalOwner(TypeOfAnimal typeOfAnimalEnum );
        void AddToy(Toy toy);
        void DeleteToy(string name);

    }
}
