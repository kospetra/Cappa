using AnimalHotelSystem.Model;

namespace AnimalHotelSystem.Database.Repository.Entities
{
    public class Db_Toy
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual TypeOfAnimal TypeOfAnimal { get; set; }
    }
}
