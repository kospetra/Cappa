namespace AnimalHotelSystem.Model
{
    public class Animal : EntityBase<int>
    {
        public TypeOfAnimal Type { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Length { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Alergies { get; private set; }
        public string OwnerName { get; private set; }
        public string OwnerSurname { get; private set; }

        public SizeOfAnimal Size
        {
            get
            {
                if (Weight < 10 || Height < 20)
                    return SizeOfAnimal.Small;
                else if (Weight > 10 && Weight < 30 || Height > 20 && Height < 70)
                    return SizeOfAnimal.Medium;
                else
                    return SizeOfAnimal.Large;
            }
        }

        public AgeOfAnimal AgeGroup
        {
            get
            {
                if (this.Age < 2)
                    return AgeOfAnimal.Junior;
                else if (this.Age < 11)
                    return AgeOfAnimal.Grown;
                else
                    return AgeOfAnimal.Senior;
            }
        }

        public Animal()
        {

        }

        public Animal(TypeOfAnimal type, string name, int age, int length, 
            int height, int weight, string alergies, string ownerName, string ownerSurname)
        {
            Type = type;
            Name = name;
            Age = age;
            Length = length;
            Height = height;
            Weight = weight;
            Alergies = alergies;
            OwnerName = ownerName;
            OwnerSurname = ownerSurname;
        }
    }
}
