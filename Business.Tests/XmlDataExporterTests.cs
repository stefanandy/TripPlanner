using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business.Tests
{
    [TestClass]
    public class XmlDataExporterTests
    {
        private readonly IXmlDataExport dataExporter = new XmlDataExport();

        [TestMethod]
        public void WriteCustomers()
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                customers.Add(new Customer { FirstName="Mr", LastName="Test"});
            }

            dataExporter.Write<Customer>("customer.xml",customers);
        }

        [TestMethod]
        public void WriteRooms()
        {
            List<Room> rooms = new List<Room>();

            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room { RoomNumber=1, MaxOccupants=2, DisabledFriendly=true});
            }

            dataExporter.Write<Room>("rooms.xml", rooms);
        }

        [TestMethod]
        public void WriteReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            for (int i = 0; i < 10; i++)
            {
                reservations.Add(new Reservation { ClientId=0,Id=1,RoomNumber=1});
            }

            dataExporter.Write<Reservation>("reservations.xml", reservations);
        }
    }
}
