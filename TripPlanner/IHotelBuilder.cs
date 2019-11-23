using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IHotelBuilder
    {
       public  Hotel CreateHotel(int numberOfRooms, int numberOfCustomers);
    }
}
