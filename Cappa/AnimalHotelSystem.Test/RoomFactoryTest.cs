using AnimalHotelSystem.Application;
using AnimalHotelSystem.Application.Factories;
using AnimalHotelSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnimalHotelSystem.Test
{
    [TestClass]
    public class RoomFactoryTest
    {
        private FrameNewRoom GetNewRoomRequest()
        {
            return new FrameNewRoom
            {
                RoomNumber = Faker.Company.Name(),
                Length = Faker.RandomNumber.Next(100),
                Width = Faker.RandomNumber.Next(100),
                Temperative = Faker.RandomNumber.Next(30)
            };
        }

        [TestMethod]
        public void FactoryShouldCreateDogRoom()
        {
            var request = GetNewRoomRequest();
            request.AnimalType = TypeOfAnimal.Dog;

            var room = RoomFactory.CreateRoom(request);

            Assert.IsInstanceOfType(room, typeof(DogRoom));
        }

        [TestMethod]
        public void FactoryShouldCreateCatRoom()
        {
            var request = GetNewRoomRequest();
            request.AnimalType = TypeOfAnimal.Cat;

            var room = RoomFactory.CreateRoom(request);

            Assert.IsInstanceOfType(room, typeof(CatRoom));
        }

        [TestMethod]
        public void FactoryShouldCreateParrotRoom()
        {
            var request = GetNewRoomRequest();
            request.AnimalType = TypeOfAnimal.Parrot;
            request.CageLength = request.Length - 1;
            request.CageWidth = request.Width - 1;
            request.CageHeight = Faker.RandomNumber.Next(50);

            var room = RoomFactory.CreateRoom(request);

            Assert.IsInstanceOfType(room, typeof(ParrotRoom));
        }

        [TestMethod]
        public void CreatingRoomWithTooLargeCageLengthShouldFail()
        {
            var request = GetNewRoomRequest();
            request.AnimalType = TypeOfAnimal.Parrot;
            request.CageLength = request.Length + 1;
            request.CageWidth = request.Width - 1;
            request.CageHeight = Faker.RandomNumber.Next(50);

            void Action() { RoomFactory.CreateRoom(request); }

            Assert.ThrowsException<Exception>(Action);
        }

        [TestMethod]
        public void CreatingRoomWithTooLargeCageWidthShouldFail()
        {
            var request = GetNewRoomRequest();
            request.AnimalType = TypeOfAnimal.Parrot;
            request.CageLength = request.Length - 1;
            request.CageWidth = request.Width + 1;
            request.CageHeight = Faker.RandomNumber.Next(50);

            void Action() { RoomFactory.CreateRoom(request); }

            Assert.ThrowsException<Exception>(Action);
        }
    }
}
