using AnimalHotelSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Test
{
    [TestClass]
    public class RoomTest
    {
        private static Animal CreateCat()
        {
            return new Animal(TypeOfAnimal.Cat, Faker.Name.First(), 2, 2, 2 , 2, string.Empty, 
                Faker.Name.First(), Faker.Name.Last());
        }


        private static Animal CreateDog()
        {
            return new Animal(TypeOfAnimal.Dog, Faker.Name.First(), 2, 2, 2, 2, string.Empty,
                Faker.Name.First(), Faker.Name.Last());
        }

        private static Animal CreateParrot()
        {
            return new Animal(TypeOfAnimal.Parrot, Faker.Name.First(), 2, 2, 2, 2, string.Empty,
                Faker.Name.First(), Faker.Name.Last());
        }

        private static DogRoom CreateDogRoom()
        {
            return new DogRoom(Faker.Company.Name(), Faker.RandomNumber.Next(10, 15), Faker.RandomNumber.Next(10, 15), 
                Faker.RandomNumber.Next(18, 32));
        }
        private static CatRoom CreateCatRoom()
        {
            return new CatRoom(Faker.Company.Name(), Faker.RandomNumber.Next(10, 15), Faker.RandomNumber.Next(10, 15),
                Faker.RandomNumber.Next(18, 32));
        }
        private static ParrotRoom CreateParrotRoom()
        {
            return new ParrotRoom(Faker.Company.Name(), Faker.RandomNumber.Next(10, 15), Faker.RandomNumber.Next(10, 15), 
                Faker.RandomNumber.Next(1, 5), Faker.RandomNumber.Next(1, 5), Faker.RandomNumber.Next(1, 5),
                Faker.RandomNumber.Next(18, 32));
        }

        private static Reservation CreateReservation(Animal animal, DateTime currentDate)
        {
            return new Reservation(currentDate, currentDate.AddDays(2), animal, new List<Toy>());
        }

        [TestMethod]
        public void CreatingDogRoomAndCatReservationShouldFail()
        {
            var dogRoom = CreateDogRoom();

            var animal = CreateCat();

            var currentDate = DateTime.Now;
            var reservation = CreateReservation(animal, currentDate);

            void Action() { dogRoom.AddNewReservation(reservation); }

            Assert.ThrowsException<Exception>(Action);
        }

        
        [TestMethod]
        public void CreatingSmallRoomAndPuttingBigCatShouldFail()
        {
            var catRoom = new CatRoom("Cat", 0.0, 0.0, 21);

            var animal = CreateCat();

            var currentDate = DateTime.Now;
            var reservation = CreateReservation(animal, currentDate);

            void Action() { catRoom.AddNewReservation(reservation); }
            
            Assert.ThrowsException<Exception>(Action);

        }

        [TestMethod]
        public void CreatingSmallRoomAndPuttingBigDogShouldFail()
        {
            var dogRoom = new DogRoom("Dog", 0.0, 0.0, 21);

            var animal = CreateDog();

            var currentDate = DateTime.Now;
            var reservation = CreateReservation(animal, currentDate);

            void Action() { dogRoom.AddNewReservation(reservation); }

            Assert.ThrowsException<Exception>(Action);

        }

        [TestMethod]
        public void CreatingSmallRoomAndPuttingBigPArrotShouldFail()
        {
            var parrotRoom = new ParrotRoom("Parrot", 1.0, 1.0, 21, 0.0, 0.0, 0.0);

            var animal = CreateParrot();

            var currentDate = DateTime.Now;
            var reservation = CreateReservation(animal, currentDate);

            void Action() { parrotRoom.AddNewReservation(reservation); }

            Assert.ThrowsException<Exception>(Action);

        }

        [TestMethod]
        public void CreatingTwoReservationsOnSameDatesShouldFail()
        {
            var catRoom = CreateCatRoom();

            var animal = CreateCat();

            var currentDate = DateTime.Now;
            var reservation1 = CreateReservation(animal, currentDate);
            var reservation2 = CreateReservation(animal, currentDate);

            void Action() { catRoom.AddNewReservation(reservation1);
                catRoom.AddNewReservation(reservation2);
            }

            Assert.ThrowsException<Exception>(Action);
        }

        [TestMethod]
        public void AddingReservationShouldSucceed()
        {
            var catRoom = CreateCatRoom();

            var animal = CreateCat();

            var currentDate = DateTime.Now;
            var reservation1 = new Reservation(currentDate, currentDate.AddDays(1), animal, new List<Toy>());
            var reservation2 = new Reservation(currentDate.AddDays(2), currentDate.AddDays(3), animal, new List<Toy>());

            catRoom.AddNewReservation(reservation1);
            catRoom.AddNewReservation(reservation2);

            Assert.AreEqual(2, catRoom.Reservations.Count);
        }
    }
}
