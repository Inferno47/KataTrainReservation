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

        private int HowManyReservedSeat() => _seats.Count(e => e.BookingReference != "");

        private List<Seat> FreeSeatsInCoach() => _seats.Where(e => e.BookingReference == "").ToList();

        private bool isMore70PercentReserved(ReservationRequest request) => (HowManyReservedSeat() + request.SeatCount) * 100 / _seats.Count > 70;

        public List<Seat> ChooseSeats(ReservationRequest request)
        {
            List<Seat> seats = new List<Seat>();

            if (isMore70PercentReserved(request))
                return seats;

            List<Seat> freeSeatsInCoach = FreeSeatsInCoach();

            for (var i = 0; i < request.SeatCount; i++) seats.Add(freeSeatsInCoach[i]);
            return seats;
        }
    }
}