using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Hotel
    {
        private List<TripPlanner.Customer> customers;
        private List<Room> rooms;

        public Hotel() {
            InitializeRooms();
            InitializeCustomers();
        }


        private void InitializeRooms() {
           rooms = new List<Room>();
        }

        private void InitializeCustomers() {
            customers = new List<TripPlanner.Customer>();
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


    }
}
