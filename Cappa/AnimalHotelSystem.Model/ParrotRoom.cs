using AnimalHotelSystem.Model.ValueObjects;
using System;

namespace AnimalHotelSystem.Model
{
    public class ParrotRoom : Room
    {
        public override TypeOfAnimal AnimalType => TypeOfAnimal.Parrot;
        public CageDimensions CageDimensions { get; private set; }

        public ParrotRoom() : base()
        {
            
        }

        public ParrotRoom(string roomNumber, double length, double width, int temperature,
            double cageLenght, double cageWidth, double cageHeight) : base(roomNumber, length, width, temperature)
        {
            if(cageWidth > Dimensions.Width || cageLenght > Dimensions.Length)
            {
                throw new Exception("Cage does not fit.");
            }

            CageDimensions = new CageDimensions(cageLenght, cageWidth, cageHeight);
        }

        protected override void ValidateRoomAdequacy(Reservation reservation)
        {
            if (CageDimensions.Volume < GetMinimalVolumeForParrot(reservation.Animal.Size))
            {
                throw new Exception("Cage is too small for a parrot.");
            }
        }

        public static double GetMinimalVolumeForParrot(SizeOfAnimal size)
        {
            const double baseVolume = 10;

            switch (size)
            {
                case SizeOfAnimal.Small:
                    return baseVolume;
                case SizeOfAnimal.Medium:
                    return baseVolume * 3;
                case SizeOfAnimal.Large:
                    return baseVolume * 4;
                default:
                    return baseVolume;
            }
        }
    }
}
