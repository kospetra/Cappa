using AnimalHotelSystem.Model;

namespace AnimalHotelSystem.Database.Repository.Entities
{
    public class Db_AnimalFood
    {
        public virtual string Name { get; set; }
        public virtual string AlergensInFood { get; set; }
        public virtual AgeOfAnimal AgeGroup { get; set; }
        public virtual TypeOfAnimal TypeOfAnimalGroup { get; set; }
        public virtual int PortionsOfFood { get; set; }
    }
}
