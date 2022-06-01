using AnimalHotelSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AnimalHotelSystem.Test
{
    [TestClass]
    public class ReservationTest
    {
        private static Animal CreateCat()
        {
            return new Animal(TypeOfAnimal.Cat, Faker.Name.First(), Faker.RandomNumber.Next(100), Faker.RandomNumber.Next(100),
                Faker.RandomNumber.Next(100), Faker.RandomNumber.Next(100), string.Empty, Faker.Name.First(), Faker.Name.Last());
        }

        [TestMethod]
        public void CreatingReservationWithIncorectDatesShouldThrowException()
        {
            var animal = CreateCat();

            var currentDate = DateTime.Now;
            var pastDate = currentDate.AddDays(-1);

            void Action() { new Reservation(currentDate, pastDate, animal, new List<Toy>()); }

            Assert.ThrowsException<Exception>(Action);
        }

        [TestMethod]
        public void CreatingReservationWithInvalidToyTypeShouldThrowException()
        {
            var dogToy = new Toy("Toy", TypeOfAnimal.Dog);

            var animal = CreateCat();

            void Action() { new Reservation(DateTime.Now, DateTime.Now.AddDays(1), animal, new List<Toy> { dogToy }); }

            Assert.ThrowsException<Exception>(Action);
        }

        [TestMethod]
        public void CreatingValidReservationShouldSucceed()
        {
            var catToy = new Toy("Toy", TypeOfAnimal.Cat);

            var animal = CreateCat();

            var currentDate = DateTime.Now;
            var futureDate = currentDate.AddDays(1);

            var reservation = new Reservation(currentDate, futureDate, animal, new List<Toy> { catToy });

            Assert.IsNotNull(reservation);
            Assert.AreEqual(currentDate, reservation.FromDate);
            Assert.AreEqual(futureDate, reservation.ToDate);
            Assert.AreEqual(1, reservation.Toys.Count);
        }
    }
}
