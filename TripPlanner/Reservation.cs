using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Reservation
    {
        public int Id { get; set; }
        private List<DateTime> Dates;

        public Reservation() {
            Dates = new List<DateTime>(1);
        }

        public void SetReservationStart(DateTime reservationStart) {
            Dates.Insert(0, reservationStart);
        }
        public void SetReservationEnd(DateTime reservationEnd) {
            Dates.Insert(1, reservationEnd);   
        }

        public List<DateTime> ReservationDates() {
            return Dates;
        }

    }
}
