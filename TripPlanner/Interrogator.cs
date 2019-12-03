using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Interrogator: IInterrogator
    {
        Hotel hotel;
        

        public Interrogator(Hotel hotel) {
            this.hotel = hotel;
        }

        public string[] GetReservationConflicts()
        {
            List<Room> rooms = hotel.Rooms();
            int numberOfRooms = rooms.Count;

            string[] reservationConflicts=new string[] { };

            for (int i = 0; i < numberOfRooms; i++)
            {
                List<Reservation> reservations = rooms[i].GetReservations();
                int numberOfReservations = reservations.Count;


                for (int j = 0; j < numberOfReservations; j++) {

                    for (int k = 0; k < numberOfReservations; k++)
                    {
 
                        if (CompareReservations(reservations[j].ReservationDates(), reservations[k].ReservationDates())==false) {

                            Array.Resize(ref reservationConflicts, reservationConflicts.Length + 1);
                            reservationConflicts[reservationConflicts.Length - 1] = new String($"The room {rooms[i].Id} has multiple reservations: " +
                            $"{reservations[j].Id},{reservations[k].Id} " + $"on the same date {reservations[j].ReservationDates()[0]}");

                        }

                    }

                }
                
            }

            
            return reservationConflicts;
        }

        private bool CompareReservations(DateTime[] first, DateTime[] second) {

            if(first[0]==second[0] || first[1] == second[1] ) {

                return false;
            } 

            return true;
        }

    }
}
