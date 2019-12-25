using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Business
{
    public class ReservationAggregator : IReservationAggregator
    {
        private List<Reservation> reservations;

        public ReservationAggregator(List<Reservation> _reservations)
        {
            reservations = _reservations;
        }

        public ReservationAggregator() { }

        public List<string> DisplayGroupedReservations(Dictionary<Room, List<Reservation> > rooms)
        {
            List<string> grouped = new List<string>();

            foreach (KeyValuePair<Room,List<Reservation>> room in rooms)
            {
                StringBuilder line = new StringBuilder();
                line.Append($"Room {room.Key.RoomNumber} has the following reservations: ");

                foreach (var reservation in room.Value)
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
            try
            {
                Dictionary<Room, List<Reservation>> reservationsGroupedByRooms = new Dictionary<Room, List<Reservation>>();

                foreach (var room in rooms)
                {
                    List<Reservation> reservationsIdenticalRoom = new List<Reservation>();

                    foreach (var reservation in reservations)
                    {
                        if (room.RoomNumber == reservation.RoomNumber)
                        {
                            reservationsIdenticalRoom.Add(reservation);
                            reservations.Remove(reservation);
                        }
                    }
                    reservationsGroupedByRooms.Add(room, reservationsIdenticalRoom);
                }

                return reservationsGroupedByRooms;

            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }
           
        }
    }
}
