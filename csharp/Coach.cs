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

        private int HowManyPercentReserved(int requiredNumberSeat) => (HowManyReservedSeat() + requiredNumberSeat) * 100 / _seats.Count;

        private List<Seat> FreeSeatsInCoach() => _seats.Where(e => e.BookingReference == "").ToList();

        private List<Seat> GetRequiredNumberListSeat(int requiredNumberSeat) => FreeSeatsInCoach().GetRange(0, requiredNumberSeat);

        public List<Seat> SelectSeat(int requiredNumberSeat)
        {
            var MaxReservedSeat = 70;
            if (HowManyPercentReserved(requiredNumberSeat) > MaxReservedSeat)
                return new List<Seat>();

            return GetRequiredNumberListSeat(requiredNumberSeat);
        }
    }
}