using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TripPlanner;

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
           
            string[] reservationConflicts=new string[0];

            
            List<Reservation> reservations =hotel.Reservations();


            for (int i = 0; i < reservations.Count; i++)
            {
                for (int j=i+1 ; j < reservations.Count; j++)
                {
                    if (Compare(reservations[i],reservations[j]) ) {

                        Array.Resize(ref reservationConflicts, reservationConflicts.Length + 1);
                        reservationConflicts[reservationConflicts.Length - 1] = new String($"The room {reservations[i].RoomId} has multiple reservations: " +
                        $"{reservations[i].Id},{reservations[j].Id} " + $"on the same date {reservations[i].ReservationDates().ElementAt(0)}");
                        reservations.RemoveAt(j);
                    }
                }
                
            }
                    
            return reservationConflicts;
        }

        private bool Compare(Reservation first, Reservation second) {
            if (first.RoomId == second.RoomId && first.ReservationDates().ElementAt(0).Date==second.ReservationDates().ElementAt(0).Date) {
                return true;
            }
            return false;
        }

        public Customer[] FindByName(string keyword) { //returns all users which have a Name or Surname that matches the provided keyword.

            List<Customer> customers = hotel.Customers().Where(a => a.FirstName == keyword || a.LastName == keyword).ToList();

            return customers.ToArray();

        } 


        public Customer[] FindCustomersGroupedByCountry() { //returns a list with the first 10 customers from each distinct country, sorted by the First accomodation date
            Customer[] c=new Customer[10];

            return c;
        }
        public Customer[] FindFirstCustomersGroupedByCountry() {

            Customer[] c = new Customer[1];

            return c;
        }

    }
}
