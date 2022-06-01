using System;

namespace AnimalHotelSystem.Model
{
    public class DogRoom : Room
    {
        public override TypeOfAnimal AnimalType => TypeOfAnimal.Dog;

        public DogRoom() : base()
        {

        }

        public DogRoom(string roomNumber, double length, double width, int temperature) : base(roomNumber, length, width, temperature)
        {
        }

        protected override void ValidateRoomAdequacy(Reservation reservation)
        {
            if(Dimensions.AreaSize < GetMinimalRoomAreaForDog(reservation.Animal.Size))
            {
                throw new Exception("Room is too small for a dog.");
            }
        }

        public static double GetMinimalRoomAreaForDog(SizeOfAnimal size)
        {
            const double baseArea = 5;

            switch (size)
            {
                case SizeOfAnimal.Small:
                    return baseArea;
                case SizeOfAnimal.Medium:
                    return baseArea * 3;
                case SizeOfAnimal.Large:
                    return baseArea * 4;
                default:
                    return baseArea;
            }
        }
    }
}
