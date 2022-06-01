using AnimalHotelSystem.Application.Factories;
using AnimalHotelSystem.Database.Repository.Repositories;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService()
        {
            _roomRepository = new RoomRepository();
        }

        public void CreateNewRoom(FrameNewRoom frameNewRoom)
        {
            var room = RoomFactory.CreateRoom(frameNewRoom);

            _roomRepository.AddRoom(room);
        }

        public List<Room> GetAllRoomsThatAreFree(DateTime fromDate, DateTime toDate)
        {
            return _roomRepository.GetAllFreeRoomsThisDate(fromDate, toDate);
        } 

    }
}
