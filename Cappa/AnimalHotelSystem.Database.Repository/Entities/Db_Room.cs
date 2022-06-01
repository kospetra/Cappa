using AnimalHotelSystem.Model;
using System.Collections.Generic;

namespace AnimalHotelSystem.Database.Repository.Entities
{
    public class Db_Room
    {
        public virtual int Id { get; set; }
        public virtual string RoomNumber { get; set; }
        public virtual double RoomLength { get; set; }
        public virtual double RoomWidth { get; set; }
        public virtual int Temperature { get; set; }
        public virtual TypeOfAnimal AnimalType { get; set; }
        public virtual double? CageLength { get; set; }
        public virtual double? CageWidth { get; set; }
        public virtual double? CageHeight { get; set; }

        public virtual ISet<Db_Reservation> Reservations { get;  set; }
    }
}
