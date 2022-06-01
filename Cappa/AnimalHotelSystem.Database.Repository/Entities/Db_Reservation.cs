using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Database.Repository.Entities
{
    public class Db_Reservation
    {
        public virtual Guid ReservationId { get; set; }
        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }

        public virtual Db_Animal Animal { get; set; }

        public virtual IList<Db_Toy> Toys { get; set; } = new List<Db_Toy>();

        public virtual int RoomId { get; set; }
    }
}
