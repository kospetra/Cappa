using AnimalHotelSystem.Database.Repository.Repositories;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.RepositoryInterface;
using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Application.Services
{
    public class ReservationService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IToyRepository _toyRepository;

        public ReservationService()
        {
            _animalRepository = new AnimalRepository();
            _roomRepository = new RoomRepository();
            _reservationRepository = new ReservationRepository();
            _toyRepository = new ToyRepository();
        }

        public void CreateRoomReservation(FormNewReservation formNewReservation)
        {
            var room = _roomRepository.GetRoomById(formNewReservation.RoomId);

            var animal = _animalRepository.GetAnimalById(formNewReservation.AnimalId);
            if(animal == null)
            {
                throw new Exception("Animal does not exist");
            }

            var toys = _toyRepository.GetToysById(formNewReservation.ToyIds);

            var reservation = new Reservation(formNewReservation.FromDate, formNewReservation.ToDate, animal, toys);

            room.AddNewReservation(reservation);

            _roomRepository.UpdateRoom(room);
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public List<Animal> GetAllAnimals()
        {
            return _animalRepository.GetUsersAnimals();
        }

        internal int AddNewAnimal(FormAnimal animalData)
        {
            var animal = new Animal(animalData.Type, animalData.Name, animalData.Age,animalData.Length,
                animalData.Height, animalData.Weight, animalData.Alergies, animalData.OwnerName, animalData.OwnerSurname);
            return _animalRepository.AddUserAnimal(animal);
        }
    }
}
