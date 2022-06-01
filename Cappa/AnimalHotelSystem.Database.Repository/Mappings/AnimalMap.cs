using AnimalHotelSystem.Database.Repository.Entities;
using FluentNHibernate.Mapping;

namespace AnimalHotelSystem.Database.Repository.Mappings
{
    public class AnimalMap : ClassMap<Db_Animal>
    {
        public AnimalMap()
        {
            Id(x => x.AnimalId).GeneratedBy.Increment();
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Age).Not.Nullable();
            Map(x => x.Length).Not.Nullable();
            Map(x => x.Height).Not.Nullable();
            Map(x => x.Weight).Not.Nullable();
            Map(x => x.Alergies);
            Map(x => x.OwnerName).Not.Nullable();
            Map(x => x.OwnerSurname).Not.Nullable();
            Table("Animal");
        }
    }
}
