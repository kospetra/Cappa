using System;

namespace AnimalHotelSystem.Model
{
    public class CatRoom : Room
    {
        public override TypeOfAnimal AnimalType => TypeOfAnimal.Cat;

        public CatRoom() : base()
        {

        }

        public CatRoom(string roomNumber, double length, double width, int temperature) : base(roomNumber, length, width, temperature)
        {
        }

        protected override void ValidateRoomAdequacy(Reservation reservation)
        {
            if (Dimensions.AreaSize < GetMinimalRoomAreaForCat(reservation.Animal.Size))
            {
                throw new Exception("Room is too small for a cat.");
            }
        }

        public static double GetMinimalRoomAreaForCat(SizeOfAnimal size)
        {
            const double baseArea = 3;

            switch (size)
            {
                case SizeOfAnimal.Small:
                    return baseArea;
                case SizeOfAnimal.Medium:
                    return baseArea * 2;
                case SizeOfAnimal.Large:
                    return baseArea * 3;
                default:
                    return baseArea;
            }
        }
    }
}
