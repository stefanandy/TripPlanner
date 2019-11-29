using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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


            anotherReservationOnFirstRoom.SetReservationStart(DateTime.Now);
            anotherReservationOnFirstRoom.SetReservationEnd(DateTime.Now);

            firstRoom.AddReservation(reservationOnFirstRoom);
            firstRoom.AddReservation(anotherReservationOnFirstRoom);
            hotel.AddRoom(firstRoom);

            interrogator = new Interrogator(hotel);

            string[] actualValue = interrogator.GetReservationConflicts();
            DateTime expectedDate = DateTime.Now; // this value can be changed
            string[] expected = new[]
            {
                $"The room {firstRoom.Id} has multiple reservations: " +
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


            anotherReservationOnFirstRoom.SetReservationStart(new DateTime(2012,03,02));
            anotherReservationOnFirstRoom.SetReservationEnd(new DateTime(2012, 03, 04));

            firstRoom.AddReservation(reservationOnFirstRoom);
            firstRoom.AddReservation(anotherReservationOnFirstRoom);
            hotel.AddRoom(firstRoom);

            interrogator = new Interrogator(hotel);

            string[] actualValue = interrogator.GetReservationConflicts();
            string[] expected = new string[0];
            CollectionAssert.AreEqual(expected, actualValue);
        }
    }


}