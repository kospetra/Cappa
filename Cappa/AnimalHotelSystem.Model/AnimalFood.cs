using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Model
{
    public class AnimalFood 
    {
        public string Name { get; private set; }
        public List<string> AlergensInFood { get; private set; }
        public AgeOfAnimal AgeGroup { get; private set; }
        public TypeOfAnimal TypeOfAnimalGroup { get; private set; }
        public int PortionsOfFood { get; private set; }

        public AnimalFood()
        {

        }

        public AnimalFood(string inName, List<string> alergensInFood, TypeOfAnimal typeOfAnimalGroup,  AgeOfAnimal ageGroup, int porcionsOfFood)
        {
            Name = inName;
            AlergensInFood = alergensInFood;
            AgeGroup = ageGroup;
            PortionsOfFood = porcionsOfFood;
            TypeOfAnimalGroup = typeOfAnimalGroup;
        }

        public int AddNewPortionsOfFood(int inPortionsOfFood)
        {
            PortionsOfFood += inPortionsOfFood;
            return PortionsOfFood;
        }

        public int RemovePortionsOfFood(int inPortionsOfFood)
        {
            if(PortionsOfFood < inPortionsOfFood)
            {
                throw new Exception($"There is not enough portions of food: {Name}");
            }
            PortionsOfFood -= inPortionsOfFood;
            return PortionsOfFood;
        }

    }
}
