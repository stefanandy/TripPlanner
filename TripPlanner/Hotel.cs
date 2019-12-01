﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Hotel
    {
        private List<TripPlanner.Customer> customers;
        private List<Room> rooms;
        private List<Reservation> reservations;

        public Hotel() {
            InitializeRooms();
            InitializeCustomers();
            InitializeReservations();
        }



        public List<Room> Rooms() {
            return rooms;
        }

        public List<Reservation> Reservations() {
            return reservations;
        }

        private void InitializeReservations() {
            reservations = new List<Reservation>();
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

        public void AddReservation(Reservation reservation) {
            reservations.Add(reservation);
        }


    }
}
