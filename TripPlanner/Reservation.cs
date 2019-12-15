using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RoomNumber { get; set; }

        private DateTime start, end;

        public int NumberOfPersons { get; set; }

        

        public Reservation() { }

        public Reservation(string line) {
            var values = line.Split(',');


            Id = Int32.Parse(values[0]);
            ClientId = Int32.Parse(values[1]);
            RoomNumber = Int32.Parse(values[2]);
            start = DateTime.Parse(values[3], System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            end = DateTime.Parse(values[4], System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            NumberOfPersons = Int32.Parse(values[5]);
          
        }

        public Reservation(DateTime reservationStart, DateTime reservationEnd) {
            start = reservationStart;
            end = reservationEnd;
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

        public DateTime EndDate()
        {
            return end;
        }

        public bool Compare(Reservation reservation)
        {
            if (RoomNumber == reservation.RoomNumber && StartDate().Date == reservation.StartDate().Date)
            {
                return true;
            }
            return false;
        }

    }
}
