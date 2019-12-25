using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IReservationAggregator
    {
        Dictionary<Room, List<Reservation>> ReservationsGroupedByRooms(List<Room> rooms);
        List<string> DisplayGroupedReservations(Dictionary<Room, List<Reservation>> rooms);
    }
}
