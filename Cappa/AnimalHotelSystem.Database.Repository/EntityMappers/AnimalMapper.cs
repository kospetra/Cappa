using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Model;

namespace AnimalHotelSystem.Database.Repository.EntityMappers
{
    public static class AnimalMapper
    {
        public static Animal ToAnimal(this Db_Animal source)
        {
            var target = new Animal();

            var type = target.GetType();
            type.GetProperty("Id").SetValue(target, source.AnimalId);
            type.GetProperty("Type").SetValue(target, source.Type);
            type.GetProperty("Name").SetValue(target, source.Name);
            type.GetProperty("Age").SetValue(target, source.Age);
            type.GetProperty("Length").SetValue(target, source.Length);
            type.GetProperty("Height").SetValue(target, source.Height);
            type.GetProperty("Weight").SetValue(target, source.Weight);
            type.GetProperty("Alergies").SetValue(target, source.Alergies);
            type.GetProperty("OwnerName").SetValue(target, source.OwnerName);
            type.GetProperty("OwnerSurname").SetValue(target, source.OwnerSurname);

            return target;
        }

        public static Db_Animal ToDb_Animal(this Animal source, Db_Animal target)
        {
            target.Type = source.Type;
            target.Name = source.Name;
            target.Age = source.Age;
            target.Length = source.Length;
            target.Height = source.Height;
            target.Weight = source.Weight;
            target.Alergies = source.Alergies;
            target.OwnerName = source.OwnerName;
            target.OwnerSurname = source.OwnerSurname;

            return target;
        }

        public static Db_Animal ToDb_Animal(this Animal source)
        {
            var target = new Db_Animal();
            return source.ToDb_Animal(target);
        }
    }
}
