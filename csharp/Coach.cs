using System;
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

        public int TotalSeat() => _seats.Count;

        public int HowManyReservedSeat() => _seats.Count(e => e.BookingReference != "");

        private int HowManyPercentReserved(int requiredNumberOfSeat) => (HowManyReservedSeat() + requiredNumberOfSeat) * 100 / _seats.Count;

        private List<Seat> FreeSeatsInCoach() => _seats.Where(e => e.BookingReference == "").ToList();

        private List<Seat> GetRequiredNumberListSeat(int requiredNumberOfSeat) => FreeSeatsInCoach().GetRange(0, requiredNumberOfSeat);

        public List<Seat> SelectFreeSeat(Func<int, bool> f, int requiredNumberOfSeat) => !f(HowManyPercentReserved(requiredNumberOfSeat)) ? new List<Seat>() : GetRequiredNumberListSeat(requiredNumberOfSeat);
    }
}