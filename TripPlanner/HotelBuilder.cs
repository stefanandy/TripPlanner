using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class HotelBuilder:IHotelBuilder
    {
        Hotel hotel;

        public Hotel CreateHotel(int numberOfRooms,int numberOfCustomers) {
            hotel = new Hotel(numberOfRooms,numberOfCustomers);
            return hotel;
        }
    }
}
