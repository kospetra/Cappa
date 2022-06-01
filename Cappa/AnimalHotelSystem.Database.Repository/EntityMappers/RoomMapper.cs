using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.Model.ValueObjects;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.EntityMappers
{
    public static class RoomMapper
    {
        public static Room ToRoom(this Db_Room source)
        {
            Room target;
            switch (source.AnimalType)
            {
                case TypeOfAnimal.Dog:
                    target = source.ToDogRoom();
                    break;
                case TypeOfAnimal.Cat:
                    target = source.ToCatRoom();
                    break;
                case TypeOfAnimal.Parrot:
                    target = source.ToParrotRoom();
                    break;
                default:
                    throw new System.Exception();
            }

            var type = target.GetType();
            type.BaseType.GetProperty("Id").SetValue(target, source.Id);
            type.BaseType.GetProperty("RoomNumber").SetValue(target, source.RoomNumber);
            type.BaseType.GetProperty("Dimensions").SetValue(target, new RoomDimensions(source.RoomLength, source.RoomWidth));
            type.BaseType.GetProperty("Temperature").SetValue(target, source.Temperature);
            type.BaseType.GetProperty("Reservations").SetValue(target, source.Reservations.Select(r => r.ToReservation()).ToList());

            return target;
        }

        public static DogRoom ToDogRoom(this Db_Room source)
        {
            var target = new DogRoom();

            return target;
        }

        public static CatRoom ToCatRoom(this Db_Room source)
        {
            var target = new CatRoom();

            return target;
        }

        public static ParrotRoom ToParrotRoom(this Db_Room source)
        {
            var target = new ParrotRoom();

            var type = target.GetType();
            type.GetProperty("CageDimensions").SetValue(target, 
                new CageDimensions(source.CageLength.GetValueOrDefault(), source.CageWidth.GetValueOrDefault(), source.CageHeight.GetValueOrDefault()));
            return target;
        }

        public static Db_Room ToDb_Room(this Room source, Db_Room target)
        {
            target.RoomNumber = source.RoomNumber;
            target.RoomLength = source.Dimensions.Length;
            target.RoomWidth = source.Dimensions.Width;
            target.Temperature = source.Temperature;
            target.AnimalType = source.AnimalType;

            if (source is ParrotRoom parrotRoom)
            {
                target.CageLength = parrotRoom.CageDimensions.Length;
                target.CageWidth = parrotRoom.CageDimensions.Width;
                target.CageHeight = parrotRoom.CageDimensions.Height;
            }
            else
            {
                target.CageLength = null;
                target.CageWidth = null;
                target.CageHeight = null;
            }

            return target;
        }

        public static Db_Room ToDb_Room(this Room source)
        {
            var target = new Db_Room();
            return source.ToDb_Room(target);
        }
    }
}
