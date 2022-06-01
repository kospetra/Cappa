namespace AnimalHotelSystem.Model
{
    public class Toy : EntityBase<int>
    {
        public string Name { get; private set; }
        public TypeOfAnimal TypeOfAnimal { get; private set; }

        public Toy(string nameOfTheToy, TypeOfAnimal typeOfAnimal)
        {
            Name = nameOfTheToy;
            TypeOfAnimal = typeOfAnimal;
        }

        public Toy()
        {
        }

    }
}