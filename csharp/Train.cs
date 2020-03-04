using System.Collections.Generic;
using System.Linq;

namespace KataTrainReservation
{
    public class Train
    {
        private readonly List<Coach> _coaches;

        public static Train Of(List<Seat> seats)
        {
            List<Coach> coaches = seats.GroupBy(e => e.Coach).Select(grouping => Coach.Of(grouping.ToList())).ToList();

            return new Train(coaches);
        }

        private Train(List<Coach> coaches)
        {
            _coaches = coaches;
        }

        public List<Seat> SelectFreeSeat(int requiredNumberOfSeat)
        {
            var selectedFreeSeat = new List<Seat>();

            var ReservedSeatsInTrain = _coaches.Sum(coach => coach.HowManyReservedSeat());
            var TotalSeatsInTrain = _coaches.Sum(coach => coach.TotalSeat());
            if ((ReservedSeatsInTrain + requiredNumberOfSeat) * 100 / TotalSeatsInTrain >= 70)
                return selectedFreeSeat;

            selectedFreeSeat = _coaches
                .Select(x => x.SelectFreeSeat(percentReserved => percentReserved < 70, requiredNumberOfSeat))
                .FirstOrDefault(x=> x.Count !=0 );

            return selectedFreeSeat ?? new List<Seat>();
        }
    }
}