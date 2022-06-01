using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Model
{
    public enum AgeOfAnimal : int
    {
        Junior = 1,
        Grown = 2,
        Senior = 3
    };

    public static class AgeOfAnimalExtensions
    {
        public static Dictionary<AgeOfAnimal, string> AgeOfAnimalDictonary = new Dictionary<AgeOfAnimal, string>
        {
            {AgeOfAnimal.Junior, "junior" },
            {AgeOfAnimal.Grown, "grown" },
            {AgeOfAnimal.Senior, "senior" }
        };

        public static AgeOfAnimal GetAgeOfAnimalEnum(string inAgeOfAnimal)
        {
            foreach (var val in AgeOfAnimalDictonary)
                if (val.Value == inAgeOfAnimal)
                    return val.Key;
            throw new Exception("Wrong Animal Age In String");
        }

        public static string GetAgeOfAnimalName(this AgeOfAnimal inAgeOfAnimalEnum)
        {
            return AgeOfAnimalDictonary[inAgeOfAnimalEnum];
        }

        public static List<string> GetAgeOfAnimalsList()
        {
            return AgeOfAnimalDictonary.Select(an => an.Value).ToList();
        }
    }
}
