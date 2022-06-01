using AnimalHotelSystem.Database.Repository.Entities;
using FluentNHibernate.Mapping;

namespace AnimalHotelSystem.Database.Repository.Mappings
{
    public class ReservationsMap : ClassMap<Db_Reservation>
    {
        public ReservationsMap()
        {
            Id(x => x.ReservationId);
            Map(x => x.FromDate).Not.Nullable();
            Map(x => x.ToDate).Not.Nullable();
            Map(x => x.RoomId).Not.Nullable();
            References(x => x.Animal, "AnimalId");
            HasManyToMany(x => x.Toys);
            Table("Reservations");
        }
    }
}
