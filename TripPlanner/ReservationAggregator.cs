using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Business
{
    public class ReservationAggregator : IReservationAggregator
    {
        public List<string> DisplayGroupedReservations(Dictionary<Room, List<Reservation> > rooms)
        {
            List<string> grouped = new List<string>();

            foreach (KeyValuePair<Room,List<Reservation>> item in rooms)
            {
                StringBuilder line = new StringBuilder();
                line.Append($"Room {item.Key.RoomNumber} has the following reservations: ");

                foreach (var reservation in item.Value)
                {
                    line.Append($"reservation {reservation.Id} with dates: {reservation.StartDate().Date} - {reservation.EndDate().Date}");
                    line.Append(Environment.NewLine);
                }
                grouped.Add(line.ToString());
            }

            return grouped;

        }

        public Dictionary<Room, List<Reservation>> ReservationsGroupedByRooms(List<Room> rooms)
        {
            IDataImporter importer = new DataImporter();

            string filePath = @"C:\Users\Lejer\source\repos\AnimalsHomework\TripPlanner\inputReservations.csv";
            List<Reservation> reservations = importer.ReadReservations(filePath).ToList();

            Dictionary<Room, List<Reservation>> dictionary = new Dictionary<Room, List<Reservation>>();

            for (int i = 0; i < rooms.Count; i++)
            {
                List<Reservation> reservationsIdenticalRoom = new List<Reservation>();
                
                for (int j = 0; j < reservations.Count; j++)
                {
                    
                    if (rooms[i].RoomNumber==reservations[j].RoomNumber) {
                        reservationsIdenticalRoom.Add(reservations[j]);
                        reservations.RemoveAt(j);
                    }
                }

                dictionary.Add(rooms[i], reservationsIdenticalRoom);

            }


            return dictionary;
        }
    }
}
