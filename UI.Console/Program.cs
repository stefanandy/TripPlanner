using System;
using Business;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string roomsFilePath = @"C:\Users\Lejer\source\repos\AnimalsHomework\TripPlanner\inputRooms.csv";
           

            DataImporter importer = new DataImporter();

            List<Room> rooms = importer.ReadRooms(roomsFilePath).Cast<Room>().ToList();

            ReservationAggregator aggregator = new ReservationAggregator();

            var groupedReservations = aggregator.ReservationsGroupedByRooms(rooms);

            var lines = aggregator.DisplayGroupedReservations(groupedReservations);

            foreach (var line in lines)
            {
                System.Console.WriteLine(line);
            }
            
        }
    }
}
