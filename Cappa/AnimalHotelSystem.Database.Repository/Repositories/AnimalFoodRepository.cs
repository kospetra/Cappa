using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Database.Repository.EntityMappers;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.Repositories
{
    public class AnimalFoodRepository : IAnimalFoodRepository
    {
        public void AddNewFood(AnimalFood inAnimalFood)
        {
            var dbAnimalFood = inAnimalFood.ToDb_AnimalFood();
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Save(dbAnimalFood);
                session.Flush();
            }
        }

        public List<AnimalFood> GetAllAnimalFood()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var dbAnimalFood = session.Query<Db_AnimalFood>().ToList();
                return dbAnimalFood.Select(af => af.ToAnimalFood()).ToList();
            }
        }

        public List<AnimalFood> GetAllAnimalFoodByAgeGroup(AgeOfAnimal inAgeOfAnimalEnum)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var dbAnimalFood = session.Query<Db_AnimalFood>().Where(af => af.AgeGroup == inAgeOfAnimalEnum).ToList();
                return dbAnimalFood.Select(af => af.ToAnimalFood()).ToList();
            }
        }

        public List<AnimalFood> GetAllAnimalFoodByType(TypeOfAnimal inTypeOfAnimalEnum)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var dbAnimalFood = session.Query<Db_AnimalFood>().Where(af => af.TypeOfAnimalGroup == inTypeOfAnimalEnum).ToList();
                return dbAnimalFood.Select(af => af.ToAnimalFood()).ToList();
            }
        }

        public AnimalFood GetAnimalFoodByName(string name)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                return session.Query<Db_AnimalFood>().FirstOrDefault(af => af.Name == name).ToAnimalFood();
            }
        }

        public AnimalFood GetAppropriateAnimalFood(Animal animal)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                return session.Query<Db_AnimalFood>()
                    .FirstOrDefault(af => af.AgeGroup == animal.AgeGroup && af.TypeOfAnimalGroup == animal.Type).ToAnimalFood();
            }
        }

        public void RemoveFood(string name)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Query<Db_AnimalFood>().Where(af => af.Name == name).Delete();
                session.Flush();
            }
        }

        public void UpdateFood(AnimalFood inAnimalFood)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var dbAnimalFood = session.Query<Db_AnimalFood>().First(af => af.Name == inAnimalFood.Name);
                dbAnimalFood = inAnimalFood.ToDb_AnimalFood(dbAnimalFood);
                session.Update(dbAnimalFood);
                session.Flush();
            }
        }
    }
}
