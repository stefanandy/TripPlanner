using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Tests
{
    [TestClass]
    public class ReservationAggregatorTest
    {
        private readonly string filePath = @"C:\Users\Lejer\source\repos\AnimalsHomework\TripPlanner\inputReservations.csv";
        private IReservationAggregator reservationAggregator;

        [TestMethod]
        public void ReservationsGroupByRooms_ForOneRoom_ShouldReturn_OneItem()
        {
            IDataImporter importer = new DataImporter();
            var reservations = importer.ReadReservations(filePath).ToList();

            reservationAggregator = new ReservationAggregator(reservations);

            List<Room> rooms = new List<Room>(); 
            var room = new Room();

            rooms.Add(room);

            int expected = 1; 
            Assert.AreEqual(expected, reservationAggregator.ReservationsGroupedByRooms(rooms).Count);
        }

        [TestMethod]
        public void ReservationsGroupByRooms_ForTwoRooms_ShouldReturn_TwoItems()
        {
            IDataImporter importer = new DataImporter();
            var reservations = importer.ReadReservations(filePath).ToList();

            reservationAggregator = new ReservationAggregator(reservations);

            List<Room> rooms = new List<Room>(); 
            var firstRoom = new Room();
            var secondRoom = new Room();

            rooms.Add(firstRoom);
            rooms.Add(secondRoom);

            int expected = 2;
            Assert.AreEqual(expected, reservationAggregator.ReservationsGroupedByRooms(rooms).Count);
        }

        [TestMethod]
        public void ReservationsGroupByRooms_Null_ShouldThrowException()
        {
            IDataImporter importer = new DataImporter();
            var reservations = importer.ReadReservations(filePath).ToList();

            reservationAggregator = new ReservationAggregator(reservations);

            List<Room> rooms = null; // do not change
            Assert.ThrowsException<ArgumentNullException>(() => reservationAggregator.ReservationsGroupedByRooms(rooms)); // do not change
        }

        [TestMethod]
        public void DisplayGroupedReservations_For2Rooms_ShouldReturn_2Items()
        {
           
            reservationAggregator = new ReservationAggregator();

            Dictionary<Room, List<Reservation>> groupedReservations = new Dictionary<Room, List<Reservation>>();

            var firstRoomReservations = new List<Reservation>();
            var secondRoomReservations = new List<Reservation>();

            for (int i = 0; i < 5; i++) {
                firstRoomReservations.Add(new Reservation());
                secondRoomReservations.Add(new Reservation());
            }

            var firstRoom = new Room();
            var secondRoom = new Room();

            groupedReservations.Add(firstRoom, firstRoomReservations);
            groupedReservations.Add(secondRoom, secondRoomReservations);

            int expected = 2;

            Assert.AreEqual(expected, reservationAggregator.DisplayGroupedReservations(groupedReservations).Count);
        }
    }
}
