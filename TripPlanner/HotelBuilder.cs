using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class HotelBuilder:IHotelBuilder
    {
        Hotel hotel;

        public Hotel CreateHotel(int numberOfRooms,int numberOfCustomers) {
            hotel = new Hotel();
            SetNumberOfRooms(numberOfRooms, hotel);
            SetNumberOfCustomers(numberOfCustomers, hotel);
            return hotel;
        }

        private void SetNumberOfRooms(int numberOfRooms, Hotel hotel) {
            for (int i = 0; i < numberOfRooms; i++) {
                hotel.AddRoom(new Room());
            }
        }

        private void SetNumberOfCustomers(int numberOfCustomers,  Hotel hotel) {
            for (int i = 0; i < numberOfCustomers; i++)
            {
                hotel.AddCustomer(new TripPlanner.Customer());
            }
        }

        
    }
}
