using System.Collections.Generic;
using System.Linq;

namespace KataTrainReservation
{
    public class Train
    {
        private readonly List<Coach> _coaches;

        public static Train Of(List<Seat> seats)
        {
            List<Coach> coaches = seats.GroupBy(e => e.Coach).Select(grouping => Coach.Of(grouping.ToList(), MaxSeatReservation.Of(70))).ToList();

            return new Train(coaches);
        }

        private Train(List<Coach> coaches)
        {
            _coaches = coaches;
        }

        public List<Seat> SelectFreeSeat(int requiredNumberOfSeat)
        {
            return _coaches.First().SelectFreeSeat(requiredNumberOfSeat);
        }
    }
}