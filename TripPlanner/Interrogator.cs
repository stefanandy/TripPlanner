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

        public List<Reservation> SortReservationByDate(List<Reservation> reservations)
        {
            reservations.Sort((x,y)=>x.StartDate().Date
                                      .CompareTo(y.StartDate().Date));
            return reservations;
        }

        public List<List<Reservation>> DetectOverlaps(List<Reservation> reservations)
        {
            List<List<Reservation>> overlaps = new List<List<Reservation>>();

            foreach (var reservation in reservations)
            {
                var overlapped = reservations.Where(x => x != reservation && 
                                 reservations.Any(y => x != y && 
                                 x.AreOverlapped(y))).
                                 ToList();

                overlaps.Add(overlapped);
            }

            return overlaps;
        }

        public List<Reservation> AdjustReservations(List<Reservation> initialReservations, List<Reservation> reservationsToFit)
        {
           return  initialReservations.Concat(reservationsToFit).ToList();
        }
    }
}
