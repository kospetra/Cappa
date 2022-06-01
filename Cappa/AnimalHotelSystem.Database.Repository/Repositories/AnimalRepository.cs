using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Database.Repository.EntityMappers;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        public int AddUserAnimal(Animal inUsersAnimals)
        {
            var dbAnimal = inUsersAnimals.ToDb_Animal();
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Save(dbAnimal);
                session.Flush();
                return dbAnimal.AnimalId;
            }
        }

        public void DeleteUSerAnimal(int inId)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Query<Db_Animal>().Where(a => a.AnimalId == inId).Delete();
                session.Flush();
            }
        }

        public Animal GetAnimalById(int inId)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                return session.Query<Db_Animal>().FirstOrDefault(a => a.AnimalId == inId).ToAnimal();
            }
        }

        public List<Animal> GetUsersAnimals()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var animals = session.Query<Db_Animal>().ToList();
                return animals.Select(a => a.ToAnimal()).ToList();
            }
        }

        public List<Animal> GetUsersAnimalsByType(TypeOfAnimal inTypeOfAnimalEnum)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var animals = session.Query<Db_Animal>().Where(a => a.Type == inTypeOfAnimalEnum).ToList();
                return animals.Select(a => a.ToAnimal()).ToList();
            }
        }
    }
}
