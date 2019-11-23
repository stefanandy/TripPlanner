using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Hotel
    {
        TripPlanner.Customer[] customerCollection;
        Room[] roomCollection;

        public Hotel(int numberOfRooms, int numberOfCustomers) {
            InitializeRooms(numberOfRooms);
            InitializeCustomers(numberOfCustomers);
        }

        public int NumberOfRooms()
        {
            return roomCollection.Length;
        }

        public int NumberOfCustomers()
        {
            return customerCollection.Length;
        }


        void InitializeRooms(int numberOfRooms)
        {
            roomCollection = new Room[numberOfRooms];

            for(int i=0;i< numberOfRooms; i++)
            {
                roomCollection[i] = new Room();
            }
        }

        void InitializeCustomers(int numberOfCustomers)
        {
            customerCollection = new TripPlanner.Customer[numberOfCustomers];

            for (int i = 0; i < numberOfCustomers; i++)
            {
                customerCollection[i] = new TripPlanner.Customer();
            }
        }


    }
}
