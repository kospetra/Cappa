using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Model;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.EntityMappers
{
    public static class ReservationMapper
    {
        public static Reservation ToReservation(this Db_Reservation source)
        {
            var target = new Reservation();

            var type = target.GetType();
            type.GetProperty("ReservationId").SetValue(target, source.ReservationId);
            type.GetProperty("FromDate").SetValue(target, source.FromDate);
            type.GetProperty("ToDate").SetValue(target, source.ToDate);
            type.GetProperty("Animal").SetValue(target, source.Animal.ToAnimal());
            type.GetProperty("Toys").SetValue(target, source.Toys.Select(t => t.ToToy()).ToList());

            return target;
        }

        public static Db_Reservation ToDb_Reservation(this Reservation source, Db_Reservation target)
        {
            target.ReservationId = source.ReservationId;
            target.FromDate = source.FromDate;
            target.ToDate = source.ToDate;

            return target;
        }

        public static Db_Reservation ToDb_Reservation(this Reservation source)
        {
            var target = new Db_Reservation();
            return source.ToDb_Reservation(target);
        }
    }
}
