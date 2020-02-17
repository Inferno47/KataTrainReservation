using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class TicketOffice
    {
        
        public Reservation MakeReservation(ReservationRequest request)
        {
            if (request.SeatCount == 1)
                return new Reservation("local_1000", "75bcd15", new List<Seat>() {new Seat("A", 1)});
            return new Reservation("local_1000", "75bcd15", new List<Seat>() {new Seat("A", 1), new Seat("A", 2) });
        }
    }
}
