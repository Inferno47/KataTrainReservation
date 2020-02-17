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
            List<Seat> seats = new List<Seat>();
            for (var i = 1; i <= request.SeatCount; i++) seats.Add(new Seat("A", i));

            return new Reservation("local_1000", "75bcd15", seats);
        }
    }
}
