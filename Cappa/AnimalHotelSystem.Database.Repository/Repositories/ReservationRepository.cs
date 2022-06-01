using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Database.Repository.EntityMappers;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public List<Reservation> GetAllCurrentReservations()
        {
            var currentDate = DateTime.Now;
            using (var session = NhibernateHelper.OpenSession())
            {
                var reservations = session.Query<Db_Reservation>().Where(r => r.FromDate < currentDate && r.ToDate > currentDate ).ToList();
                return reservations.Select(r => r.ToReservation()).ToList();
            }
        }

        public List<Reservation> GetAllReservations()
        {
            var currentDate = DateTime.Now;
            using (var session = NhibernateHelper.OpenSession())
            {
                var reservations = session.Query<Db_Reservation>().ToList();
                return reservations.Select(r => r.ToReservation()).ToList();
            }
        }
    }
}
