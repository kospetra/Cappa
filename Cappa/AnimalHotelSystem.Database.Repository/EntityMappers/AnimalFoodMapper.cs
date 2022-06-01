using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Model;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.EntityMappers
{
    public static class AnimalFoodMapper
    {
        public static AnimalFood ToAnimalFood(this Db_AnimalFood source)
        {
            var target = new AnimalFood();

            var foodType = target.GetType();
            foodType.GetProperty("Name").SetValue(target, source.Name);
            foodType.GetProperty("AlergensInFood").SetValue(target, source.AlergensInFood.Split(',').ToList());
            foodType.GetProperty("AgeGroup").SetValue(target, source.AgeGroup);
            foodType.GetProperty("TypeOfAnimalGroup").SetValue(target, source.TypeOfAnimalGroup);
            foodType.GetProperty("PortionsOfFood").SetValue(target, source.PortionsOfFood);

            return target;
        }

        public static Db_AnimalFood ToDb_AnimalFood(this AnimalFood source, Db_AnimalFood target)
        {
            target.Name = source.Name;
            target.AlergensInFood = string.Join(",", source.AlergensInFood);
            target.AgeGroup = source.AgeGroup;
            target.TypeOfAnimalGroup = source.TypeOfAnimalGroup;
            target.PortionsOfFood = source.PortionsOfFood;

            return target;
        }

        public static Db_AnimalFood ToDb_AnimalFood(this AnimalFood source)
        {
            var target = new Db_AnimalFood();
            return source.ToDb_AnimalFood(target);
        }
    }
}
