using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Reservation
    {
        public int Id { get; set; }
        private DateTime[] Dates;

        public Reservation() {
            Dates = new DateTime[2];
        }

        public void SetReservationStart(DateTime reservationStart) {
            Dates[0] = reservationStart;
        }
        public void SetReservationEnd(DateTime reservationEnd) {
            Dates[1] = reservationEnd;   
        }

        public DateTime[] ReservationDates() {
            return Dates;
        }

    }
}
