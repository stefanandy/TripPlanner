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
                    if (reservations[i].Compare(reservations[j]) ) {

                        Array.Resize(ref reservationConflicts, reservationConflicts.Length + 1);
                        reservationConflicts[reservationConflicts.Length - 1] = new String($"The room {reservations[i].RoomNumber} has multiple reservations: " +
                        $"{reservations[i].Id},{reservations[j].Id} " + $"on the same date {reservations[i].StartDate()}");
                        reservations.RemoveAt(j);
                    }
                }
                
            }
                    
            return reservationConflicts;
        }

        public Customer[] FindByName(string keyword) {

            List<Customer> customers = hotel.Customers()
                .Where(a => a.FirstName == keyword || a.LastName == keyword)
                .ToList();

            return customers.ToArray();

        } 


    

        public Customer[] FindFirstCustomersGroupedByCountry() {

            List<Customer> customers = new List<Customer>();

            var orderedCustomers = hotel.Customers().GroupBy(x => x.Country)
                        .Select(x => x.OrderBy(x => x.FirstAccomodation).Take(10))
                        .ToList();

            foreach (var c in orderedCustomers[0])
            {
                customers.Add(c);
            }

            return customers.ToArray();
        }

    }
}
