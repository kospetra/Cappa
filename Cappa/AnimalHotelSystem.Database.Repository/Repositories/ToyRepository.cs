using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Database.Repository.EntityMappers;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.Repositories
{
    public class ToyRepository : IToyRepository
    {
        public void AddToy(Toy toy)
        {
            var dbToy = toy.ToDb_Toy();
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Save(dbToy);
                session.Flush();
            }
        }

        public void DeleteToy(string name)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Query<Db_Toy>().Where(t => t.Name == name).Delete();
                session.Flush();
            }
        }

        public List<Toy> GetAllToys()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var toys = session.Query<Db_Toy>().ToList();
                return toys.Select(t => t.ToToy()).ToList();
            }
        }

        public Toy GetToyById(string name)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var toy = session.Query<Db_Toy>().FirstOrDefault(t => t.Name == name);
                return toy.ToToy();
            }
        }

        public List<Toy> GetToyByTypeAnimalOwner(TypeOfAnimal typeOfAnimalEnum)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var toys = session.Query<Db_Toy>().Where(t => t.TypeOfAnimal == typeOfAnimalEnum).ToList();
                return toys.Select(t => t.ToToy()).ToList();
            }
        }

        public List<Toy> GetToysById(IList<int> toyIds)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var toys = session.Query<Db_Toy>().ToList();
                return toys.Join(toyIds, t => t.Id, id => id, (t, id) => t).Select(t => t.ToToy()).ToList();
            }
        }
    }
}
