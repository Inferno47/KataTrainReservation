using System.Collections.Generic;
using System.Linq;

namespace KataTrainReservation
{
    public class Coach
    {
        public static Coach Of(List<Seat> seats)
        {
            return new Coach(seats);
        }

        private readonly List<Seat> _seats;

        private Coach(List<Seat> seats)
        {
            _seats = seats;
        }

        private int HowManyReservedSeat() => _seats.Count(e => e.BookingReference != "");

        private int HowManyPercentReserved(int newSeatCount) => (HowManyReservedSeat() + newSeatCount) * 100 / _seats.Count;

        private bool IsMore70PercentReserved(int newSeatCount) => HowManyPercentReserved(newSeatCount) > 70;

        private List<Seat> FreeSeatsInCoach() => _seats.Where(e => e.BookingReference == "").ToList();

        public List<Seat> SelectSeat(int newSeatCount)
        {
            List<Seat> seats = new List<Seat>();

            if (IsMore70PercentReserved(newSeatCount))
                return seats;

            List<Seat> freeSeatsInCoach = FreeSeatsInCoach();

            for (var i = 0; i < newSeatCount; i++) seats.Add(freeSeatsInCoach[i]);
            return seats;
        }
    }
}