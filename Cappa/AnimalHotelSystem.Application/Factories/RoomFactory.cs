using AnimalHotelSystem.Model;
using System;

namespace AnimalHotelSystem.Application.Factories
{
    public static class RoomFactory
    {
        public static Room CreateRoom(FrameNewRoom frameNewRoom)
        {
            switch (frameNewRoom.AnimalType)
            {
                case TypeOfAnimal.Dog:
                    return new DogRoom(frameNewRoom.RoomNumber, frameNewRoom.Length, frameNewRoom.Width, frameNewRoom.Temperative);
                case TypeOfAnimal.Cat:
                    return new CatRoom(frameNewRoom.RoomNumber, frameNewRoom.Length, frameNewRoom.Width, frameNewRoom.Temperative);
                case TypeOfAnimal.Parrot:
                    return new ParrotRoom(frameNewRoom.RoomNumber, frameNewRoom.Length, frameNewRoom.Width, frameNewRoom.Temperative, frameNewRoom.CageLength, frameNewRoom.CageWidth, frameNewRoom.CageHeight);
                default:
                    throw new Exception("Invalid animal type");
            }
        }
    }
}
