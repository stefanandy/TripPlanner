using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Room
    {
        public int Id { get; set; }
       private List<Reservation> reservations;

        public Room() {
            reservations = new List<Reservation>();
        }


        public List<Reservation> GetReservations() {
            return reservations;
        }

        public void AddReservation(Reservation reservation) {
            reservations.Add(reservation);
        }

    }
}
