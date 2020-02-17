using System.Collections.Generic;
using System.Linq;

namespace KataTrainReservation.TicketOfficeTest
{
    public class Coach
    {
        private readonly List<Seat> _seats;

        public Coach(List<Seat> seats)
        {
            _seats = seats;
        }

        private int HowManyReservedSeat()
        {
            return _seats.Count(e => e.BookingReference != "");
        }

        public List<Seat> ChooseSeats(ReservationRequest request)
        {
            List<Seat> seats = new List<Seat>();

            if ((HowManyReservedSeat() + request.SeatCount) * 100 / _seats.Count > 70)
                return seats;

            List<Seat> freeSeatsInCoach = _seats.Where(e => e.BookingReference == "").ToList();
            for (var i = 0; i < request.SeatCount; i++) seats.Add(freeSeatsInCoach[i]);
            return seats;
        }
    }
}