using AnimalHotelSystem.Database.Repository.Entities;
using FluentNHibernate.Mapping;

namespace AnimalHotelSystem.Database.Repository.Mappings
{
    public class ToyMap : ClassMap<Db_Toy>
    {
        public ToyMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.TypeOfAnimal).Not.Nullable();
            Table("Toy");
        }
    }
}
