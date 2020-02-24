using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business
{
   public interface IInterrogator
    {
        public string[] GetReservationConflicts();
        public Customer[] FindByName(string keyword);
        public Customer[] FindFirstCustomersGroupedByCountry();
        public List<Reservation> SortReservationByDate(List<Reservation> reservations);
        public List<List<Reservation>> DetectOverlaps(List<Reservation> reservations);
        public List<Reservation> AdjustReservations(List<Reservation> initialReservations, List<Reservation> reservationsToFit);

    }
}
