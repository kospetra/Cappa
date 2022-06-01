using System;
using System.Collections.Generic;
using System.Linq;


namespace AnimalHotelSystem.Model
{
    public enum TypeOfAnimal : int
    {
        Dog = 1,
        Cat = 2,
        Parrot = 3
    };

    public static class TypeOfAnimalExtensions
    {
        public static Dictionary<TypeOfAnimal, string> TypeOfAnimalDictonary = new Dictionary<TypeOfAnimal, string>
        {
            {TypeOfAnimal.Cat, "cat" },
            {TypeOfAnimal.Dog, "dog" },
            {TypeOfAnimal.Parrot, "parrot" }
        };

        public static TypeOfAnimal GetTypeOfAnimalEnum(string inTypeOfAnimal)
        {
            foreach (var val in TypeOfAnimalDictonary)
                if (val.Value == inTypeOfAnimal)
                    return val.Key;
            throw new Exception("Wrong Animal Type Name In String");
        }

        public static string GetTypeOfAnimalName(this TypeOfAnimal inTypeOfAnimalEnum)
        {
            return TypeOfAnimalDictonary[inTypeOfAnimalEnum];
        }

        public static List<string> GetTypeOfAnimalsList()
        {
            return TypeOfAnimalDictonary.Select(an => an.Value).ToList();
        }
    }
}