using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Reservation
    {
        public int Id { get; set; }
        private DateTime start, end;

        public int RoomId { get; set; }

        public Reservation() {
            
        }

        public void SetReservationStart(DateTime reservationStart) {
            start = reservationStart;
        }
        public void SetReservationEnd(DateTime reservationEnd) {
            end = reservationEnd;
        }

        public DateTime StartDate() {
            return start;
        }

    }
}
