using AnimalHotelSystem.Database.Repository.Entities;
using AnimalHotelSystem.Database.Repository.EntityMappers;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHotelSystem.Database.Repository.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public void AddRoom(Room inRoom)
        {
            var dbRoom = inRoom.ToDb_Room();
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Save(dbRoom);
                session.Flush();
            }
        }

        public void DeleteRoom(int inId)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.Query<Db_Room>().Where(r => r.Id == inId).Delete();
                session.Flush();
            }
        }

        public List<CatRoom> GetAllFreeCatRoomsThisDate(DateTime fromDate, DateTime toDate)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var rooms = GetAvailableRoomsQuery(fromDate, toDate, session).Where(r => r.AnimalType == TypeOfAnimal.Cat).ToList();

                return rooms.Select(r => r.ToRoom()).Cast<CatRoom>().ToList();
            }
        }

        public List<DogRoom> GetAllFreeDogRoomsThisDate(DateTime fromDate, DateTime toDate)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var rooms = GetAvailableRoomsQuery(fromDate, toDate, session).Where(r => r.AnimalType == TypeOfAnimal.Dog).ToList();

                return rooms.Select(r => r.ToRoom()).Cast<DogRoom>().ToList();
            }
        }

        public List<ParrotRoom> GetAllFreeParrotRoomsThisDate(DateTime fromDate, DateTime toDate)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var rooms = GetAvailableRoomsQuery(fromDate, toDate, session).Where(r => r.AnimalType == TypeOfAnimal.Parrot).ToList();

                return rooms.Select(r => r.ToRoom()).Cast<ParrotRoom>().ToList();
            }
        }

        public List<Room> GetAllFreeRoomsThisDate(DateTime fromDate, DateTime toDate)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var rooms = GetAvailableRoomsQuery(fromDate, toDate, session).ToList();

                return rooms.Select(r => r.ToRoom()).ToList();
            }
        }

        public Room GetRoomById(int inId)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                return session.Query<Db_Room>().FirstOrDefault(r => r.Id == inId).ToRoom();
            }
        }

        public void UpdateRoom(Room inRoom)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var dbRoom = session.Query<Db_Room>().First(r => r.RoomNumber == inRoom.RoomNumber);
                dbRoom = inRoom.ToDb_Room(dbRoom);

                var reservationPairs = inRoom.Reservations.GroupJoin(dbRoom.Reservations, r => r.ReservationId, dr => dr.ReservationId, (r, dr) => new { Reservation = r, DbReservation = dr.FirstOrDefault() });

                foreach (var pair in reservationPairs)
                {
                    if (pair.DbReservation != null)
                    {
                        pair.Reservation.ToDb_Reservation(pair.DbReservation);
                        session.Update(pair.DbReservation);
                    }
                    else
                    {
                        var dbReservation = pair.Reservation.ToDb_Reservation();
                        dbReservation.Animal = session.Load<Db_Animal>(pair.Reservation.Animal.Id);
                        pair.Reservation.Toys.ForEach(t => dbReservation.Toys.Add(session.Load<Db_Toy>(t.Id)));
                        dbReservation.RoomId = dbRoom.Id;
                        session.Save(dbReservation);
                        dbRoom.Reservations.Add(dbReservation);
                    }
                }

                session.Update(dbRoom);
                session.Flush();
            }
        }

        private IEnumerable<Db_Room> GetAvailableRoomsQuery(DateTime fromDate, DateTime toDate, ISession session)
        {
            var reservationQuery = session.Query<Db_Reservation>().Where(r => r.FromDate <= toDate && r.ToDate >= fromDate).ToList();
            var roomsQuery = session.Query<Db_Room>().ToList().GroupJoin(reservationQuery, ro => ro.Id, re => re.RoomId, (ro, re) => new { Room = ro, Reservations = re })
                .Where(x => !x.Reservations.Any())
                .Select(x => x.Room);

            return roomsQuery;
        }
    }
}
