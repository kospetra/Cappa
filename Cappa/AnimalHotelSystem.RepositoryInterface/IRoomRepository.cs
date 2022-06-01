using AnimalHotelSystem.Model;
using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.RepositoryInterface
{
    public interface IRoomRepository
    {
        Room GetRoomById(int inId);
        List<Room> GetAllFreeRoomsThisDate(DateTime fromDate, DateTime toDate);
        List<DogRoom> GetAllFreeDogRoomsThisDate(DateTime fromDate, DateTime toDate);
        List<CatRoom> GetAllFreeCatRoomsThisDate(DateTime fromDate, DateTime toDate);
        List<ParrotRoom> GetAllFreeParrotRoomsThisDate(DateTime fromDate, DateTime toDate);

        void AddRoom(Room inRoom);
        void UpdateRoom(Room inRoom);
        void DeleteRoom(int inId);
    }
}
