using AnimalHotelSystem.Model;
using System.Collections.Generic;

namespace AnimalHotelSystem.RepositoryInterface
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllCurrentReservations();
        List<Reservation> GetAllReservations();
    }
}
