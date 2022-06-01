using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Model;

namespace AnimalHotelSystem.Database.Repository.EntityMappers
{
    public static class ToyMapper
    {
        public static Toy ToToy(this Db_Toy source)
        {
            var target = new Toy();

            var animalType = target.GetType();
            animalType.GetProperty("Id").SetValue(target, source.Id);
            animalType.GetProperty("Name").SetValue(target, source.Name);
            animalType.GetProperty("TypeOfAnimal").SetValue(target, source.TypeOfAnimal);

            return target;
        }

        public static Db_Toy ToDb_Toy(this Toy source, Db_Toy target)
        {
            target.Name = source.Name;
            target.TypeOfAnimal = source.TypeOfAnimal;

            return target;
        }

        public static Db_Toy ToDb_Toy(this Toy source)
        {
            var target = new Db_Toy();
            return source.ToDb_Toy(target);
        }

    }
}
