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
    }
}
