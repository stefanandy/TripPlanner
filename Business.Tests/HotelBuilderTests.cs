using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;

namespace Business.Tests
{
    [TestClass]
    public class HotelBuilderTests
    {
        [TestMethod]
        public void Create_Hotel_With_40_Rooms_And_400_Customers()
        {
            IHotelBuilder hotelBuilder = new HotelBuilder();
            var hotel = hotelBuilder.CreateHotel(40,400);
            Assert.AreEqual(40, hotel.NumberOfRooms());
            Assert.AreEqual(400, hotel.NumberOfCustomers());
        }

        [TestMethod]
        public void Create_Hotel_With_100_Rooms_And_399_Customers()
        {
            IHotelBuilder hotelBuilder = new HotelBuilder();
            var hotel = hotelBuilder.CreateHotel(100, 399);
            Assert.AreEqual(100, hotel.NumberOfRooms());
            Assert.AreEqual(399, hotel.NumberOfCustomers());
        }
    }

   
}