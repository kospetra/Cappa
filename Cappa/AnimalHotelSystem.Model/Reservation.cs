using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Model
{
    public class Reservation
    {
        public Guid ReservationId { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }

        public Animal Animal { get; private set; }

        public List<Toy> Toys { get; private set; } = new List<Toy>();

        public Reservation()
        {

        }

        public Reservation(DateTime fromDate, DateTime toDate, Animal animal, IList<Toy> toys)
        {
            if(fromDate > toDate)
            {
                throw new Exception("Ending date has to be after starting date.");
            }

            ReservationId = Guid.NewGuid();
            FromDate = fromDate;
            ToDate = toDate;

            Animal = animal;

            foreach (var toy in toys)
            {
                AddToy(toy);
            }
        }

        public void AddToy(Toy toy)
        {
            if(toy.TypeOfAnimal != Animal.Type)
            {
                throw new Exception("Toy does not fit animal type.");
            }

            Toys.Add(toy);
        }

    }
}
