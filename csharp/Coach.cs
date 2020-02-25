using System.Collections.Generic;
using System.Linq;

namespace KataTrainReservation
{
    public class Coach
    {
        public static Coach Of(List<Seat> seats, MaxSeatReservation maxReservedSeat)
        {
            return new Coach(seats, maxReservedSeat);
        }

        private readonly List<Seat> _seats;
        private readonly MaxSeatReservation _maxSeatReservation;

        private Coach(List<Seat> seats, MaxSeatReservation maxReservedSeat)
        {
            _seats = seats;
            _maxSeatReservation = maxReservedSeat;
        }

        private int HowManyReservedSeat() => _seats.Count(e => e.BookingReference != "");

        private int HowManyPercentReserved(int requiredNumberOfSeat) => (HowManyReservedSeat() + requiredNumberOfSeat) * 100 / _seats.Count;

        private List<Seat> FreeSeatsInCoach() => _seats.Where(e => e.BookingReference == "").ToList();

        private List<Seat> GetRequiredNumberListSeat(int requiredNumberOfSeat) => FreeSeatsInCoach().GetRange(0, requiredNumberOfSeat);

        public List<Seat> SelectFreeSeat(int requiredNumberOfSeat)
        {
            return HowManyPercentReserved(requiredNumberOfSeat) > _maxSeatReservation.MaxReservedSeat ? new List<Seat>() : GetRequiredNumberListSeat(requiredNumberOfSeat);
        }
    }
}