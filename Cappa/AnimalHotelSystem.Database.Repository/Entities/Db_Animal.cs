using AnimalHotelSystem.Model;

namespace AnimalHotelSystem.Database.Repository.Entities
{
    public class Db_Animal
    {
        public virtual int AnimalId { get; set; }
        public virtual TypeOfAnimal Type { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual int Length { get; set; }
        public virtual int Height { get; set; }
        public virtual int Weight { get; set; }
        public virtual string Alergies { get; set; }
        public virtual string OwnerName { get; set; }
        public virtual string OwnerSurname { get; set; }
    }
}
