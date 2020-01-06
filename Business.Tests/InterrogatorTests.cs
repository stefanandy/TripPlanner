using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripPlanner;

namespace Business.Tests
{
    /*
     *
     * Write a class Interrogator which receives in its constructor as parameter a Hotel instance.
     * Implement in this class the method with the following characteristics:
     * * The signature is: string[] GetReservationConflicts()
     * * It iterates all room reservations and check if there are incompatible ones (Reservations made for the same room in the same day).
     * * It returns for each conflict the following error message "The room {RoomId} is included in Reservations: {the Ids of reservations in conflict} in the date {Date when conflict occurs}"
     */


    [TestClass]
    public class InterrogatorTests
    {
        private IInterrogator interrogator;

        [TestMethod]
        public void GetReservationConflicts_Has_Conflicts()
        {
            Room firstRoom = new Room();
            Reservation reservationOnFirstRoom = new Reservation();
            Reservation anotherReservationOnFirstRoom = new Reservation();

            // create a Hotel instance with Rooms and Reservations from above
            // create an Interrogator
            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(1,0);

            reservationOnFirstRoom.SetReservationStart(DateTime.Now);
            reservationOnFirstRoom.SetReservationEnd(DateTime.Now);
            reservationOnFirstRoom.RoomNumber = 1;
            reservationOnFirstRoom.Id = 1;

            anotherReservationOnFirstRoom.SetReservationStart(DateTime.Now);
            anotherReservationOnFirstRoom.SetReservationEnd(DateTime.Now);
            anotherReservationOnFirstRoom.RoomNumber = 1;
            anotherReservationOnFirstRoom.Id = 2;

            firstRoom.RoomNumber = 1;

            hotel.AddRoom(firstRoom);

            hotel.AddReservation(reservationOnFirstRoom);
            hotel.AddReservation(anotherReservationOnFirstRoom);

            interrogator = new Interrogator(hotel);

            string[] actualValue = interrogator.GetReservationConflicts();
            DateTime expectedDate = DateTime.Now; // this value can be changed
            string[] expected = new[]
            {
                $"The room {firstRoom.RoomNumber} has multiple reservations: " +
                $"{reservationOnFirstRoom.Id},{anotherReservationOnFirstRoom.Id} " +
                $"on the same date {expectedDate}"
            };
            CollectionAssert.AreEqual(expected, actualValue);
        }

        [TestMethod]
        public void GetReservationConflicts_Has_No_Conflicts()
        {
            Room firstRoom = new Room();
            Reservation reservationOnFirstRoom = new Reservation();
            Reservation anotherReservationOnFirstRoom = new Reservation();

            // create a Hotel instance with Rooms and Reservations from above
            // create an Interrogator

            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            reservationOnFirstRoom.SetReservationStart(new DateTime(2014,04,05));
            reservationOnFirstRoom.SetReservationEnd(new DateTime(2014,04,06));
            reservationOnFirstRoom.RoomNumber = 1;
            reservationOnFirstRoom.Id = 1;

            anotherReservationOnFirstRoom.SetReservationStart(new DateTime(2012,03,02));
            anotherReservationOnFirstRoom.SetReservationEnd(new DateTime(2012, 03, 04));
            anotherReservationOnFirstRoom.RoomNumber = 1;
            anotherReservationOnFirstRoom.Id = 2;

            firstRoom.RoomNumber = 1;

            hotel.AddRoom(firstRoom);

            hotel.AddReservation(reservationOnFirstRoom);
            hotel.AddReservation(anotherReservationOnFirstRoom);

            

            interrogator = new Interrogator(hotel);

            string[] actualValue = interrogator.GetReservationConflicts();
            string[] expected = new string[0];
            CollectionAssert.AreEqual(expected, actualValue);
        }



        [TestMethod]
        public void FindByName_1_Is_Found()
        {
            // Arrange an hotel with customers
            // Create interrogator with the hotel

            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            Customer customer = new Customer();
            customer.LastName= "Andrei";

            hotel.AddCustomer(customer);


            string customerName = "Andrei"; // replace value

            interrogator = new Interrogator(hotel);
            Customer[] customers = interrogator.FindByName(customerName);

            Assert.AreEqual(1, customers.Length);
        }

        [TestMethod]
        public void FindByName_2_Are_Found()
        {
            // Arrange an hotel with customers
            // Create interrogator with the hotel

            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            Customer customer = new Customer();
            customer.LastName = "Andrei";

            hotel.AddCustomer(customer);
            hotel.AddCustomer(customer);

            string customerName = "Andrei"; // replace value

            interrogator = new Interrogator(hotel);

            Customer[] customers = interrogator.FindByName(customerName);

            Assert.AreEqual(2, customers.Length);
        }

        [TestMethod]
        public void FindByName_Not_Found()
        {
            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            Customer customer = new Customer();
            customer.LastName = "Andrei";

            hotel.AddCustomer(customer);


            interrogator = new Interrogator(hotel);
            string customerName = "Unknown Name";
            Customer[] customers = interrogator.FindByName(customerName);



            Assert.AreEqual(0, customers.Length);
        }

        [TestMethod]
        public void FindFirstCustomersGroupedByCountry()
        {
            // Arrange an hotel with customers
            // Create interrogator with the hotel
            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            DataImporter importer = new DataImporter();

            string filePath = @"../../../../TripPlanner/inputCustomers.csv";
            Customer[] customersFromCsv = importer.ReadCustomers(filePath);

            for (int i = 0; i < customersFromCsv.Length; i++) {
                hotel.AddCustomer(customersFromCsv[i]);
            }
            interrogator = new Interrogator(hotel);
            Customer[] customers = interrogator.FindFirstCustomersGroupedByCountry();
            int expectedNumberOfCustomers = 10;
            Assert.AreEqual(expectedNumberOfCustomers, customers.Length);
        }


       
    }
}


  

