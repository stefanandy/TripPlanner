using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business
{
    public class Hotel
    {
        private List<Customer> customers;
        private List<Room> rooms;
        private List<Reservation> reservations;

        public Hotel() {
            rooms = new List<Room>();
            customers = new List<Customer>();
            reservations = new List<Reservation>();
        }



        public List<Room> Rooms() {
            return rooms;
        }

        public List<Reservation> Reservations() {
            return reservations;
        }
        public List<Customer> Customers()
        {
            return customers;
        }


        public int NumberOfRooms()
        {
            return rooms.Count;
        }

        public int NumberOfCustomers()
        {
            return customers.Count;
        }


        public void AddRoom(Room room) {
            rooms.Add(room);
        }

        public void AddCustomer(TripPlanner.Customer customer) {
            customers.Add(customer);
        }

        public void AddReservation(Reservation reservation) {
            reservations.Add(reservation);
        }


    }
}
