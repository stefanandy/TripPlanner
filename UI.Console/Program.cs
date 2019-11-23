using System;
using Business;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IHotelBuilder hotelBuilder = new HotelBuilder();
            var hotel = hotelBuilder.CreateHotel(100,399);
            System.Console.WriteLine("In Hotel sunt "+hotel.NumberOfRooms()+" camere");
            System.Console.WriteLine("In Hotel sunt " + hotel.NumberOfCustomers() + " clienti");
        }
    }
}
