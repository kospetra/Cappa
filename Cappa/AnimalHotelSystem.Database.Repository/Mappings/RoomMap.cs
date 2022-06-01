using AnimalHotelSystem.Database.Repository.Entities;
using FluentNHibernate.Mapping;

namespace AnimalHotelSystem.Database.Repository.Mappings
{
    public class RoomMap : ClassMap<Db_Room>
    {
        public RoomMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.RoomNumber).Unique().Not.Nullable();
            Map(x => x.RoomLength).Not.Nullable();
            Map(x => x.RoomWidth).Not.Nullable();
            Map(x => x.Temperature).Not.Nullable();
            Map(x => x.AnimalType).Not.Nullable();
            Map(x => x.CageLength).Nullable();
            Map(x => x.CageWidth).Nullable();
            Map(x => x.CageHeight).Nullable();

            HasMany(x => x.Reservations).KeyColumn("RoomId").Cascade.All();
            Table("Room");
        }
    }
}
