using AnimalHotelSystem.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Model
{
    public abstract class Room : EntityBase<int>
    {
        public string RoomNumber { get; private set; }
        public RoomDimensions Dimensions { get; private set; }

        public int Temperature { get; private set; }
        public abstract TypeOfAnimal AnimalType {  get;  }
        public IList<Reservation> Reservations { get; private set; } = new List<Reservation>();

        protected Room()
        {
                
        }

        protected Room(string roomNumber, double length, double width, int temperature )
        {
            RoomNumber = roomNumber;
            Dimensions = new RoomDimensions(length, width);
            Temperature = temperature;
        }

        public void AddNewReservation( Reservation reservation)
        {
            if(Reservations.Any(r => r.ReservationId == reservation.ReservationId))
            {
                throw new Exception("This reservation already exists");
            }

            ValidateReservation(reservation);

            Reservations.Add(reservation);
        }

        private void ValidateReservation(Reservation reservation)
        {
            ValidateRoomAndAnimalType(reservation);
            ValidateRoomAvailability(reservation);
            ValidateRoomAdequacy(reservation);
        }

        private void ValidateRoomAndAnimalType(Reservation reservation)
        {
            if (AnimalType != reservation.Animal.Type)
            {
                throw new Exception("Animal type doesn't match room type");
            }
        }

        private void ValidateRoomAvailability(Reservation reservation)
        {
            if( Reservations.Any(r => r.FromDate <= reservation.ToDate && r.ToDate >= reservation.FromDate))
            {
                throw new Exception("Room is not available");
            }
        }

        protected abstract void ValidateRoomAdequacy(Reservation reservation);

        public void RemoveReservation(Guid reservationId)
        {
            var reservation = Reservations.FirstOrDefault(r => r.ReservationId == reservationId);
            if (reservation == null)
            {
                throw new Exception("There is no such reservation");
            }

            Reservations.Remove(reservation);
        }


        public void ChangeTemperature(int temperature)
        {
            Temperature = temperature;
        } 
    }
}
