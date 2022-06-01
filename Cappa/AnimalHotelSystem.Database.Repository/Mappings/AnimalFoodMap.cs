using AnimalHotelSystem.Database.Repository.Entities;
using FluentNHibernate.Mapping;

namespace AnimalHotelSystem.Database.Repository.Mappings
{
    public class AnimalFoodMap : ClassMap<Db_AnimalFood>
    {
        public AnimalFoodMap()
        {
            Id(x => x.Name).GeneratedBy.Assigned();
            Map(x => x.PortionsOfFood).Not.Nullable();
            Map(x => x.TypeOfAnimalGroup).Not.Nullable();
            Map(x => x.AlergensInFood);
            Map(x => x.AgeGroup).Not.Nullable();
            Table("AnimalFood");
        }
    }
}
