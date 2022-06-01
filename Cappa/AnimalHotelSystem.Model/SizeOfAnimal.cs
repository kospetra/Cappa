using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Model
{
    public enum SizeOfAnimal : int
    {
        Small = 1,
        Medium = 2,
        Large = 3
    };

    public static class SizeOfAnimalExtensions
    {

        public static Dictionary<SizeOfAnimal, string> SizeOfAnimalDictionary = new Dictionary<SizeOfAnimal, string>
        {
            {SizeOfAnimal.Small, "small" },
            {SizeOfAnimal.Medium, "medium" },
            {SizeOfAnimal.Large, "large" },
        };

        public static SizeOfAnimal GetSizeOfAnimalEnum(string inSizeOfAnimal)
        {
            foreach (var val in SizeOfAnimalDictionary)
                if (val.Value == inSizeOfAnimal)
                    return val.Key;
            throw new Exception("Wrong Animal Size In String");
        }

        public static string GetSizeOfAnimalName(this SizeOfAnimal inSizeOfAnimalEnum)
        {
            return SizeOfAnimalDictionary[inSizeOfAnimalEnum];
        }

        public static List<string> GetSizeOfAnimalsList()
        {
            return SizeOfAnimalDictionary.Select(an => an.Value).ToList();
        }

    }
}
