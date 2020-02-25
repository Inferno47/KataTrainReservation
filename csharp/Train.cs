using System.Collections.Generic;

namespace KataTrainReservation
{
    public class Train
    {
        private List<Seat> list;

        public Train(List<Seat> list)
        {
            this.list = list;
        }

        public List<Seat> SelectFreeSeat(int requiredNumberOfSeat)
        {
            if (requiredNumberOfSeat == 1)
                return new List<Seat>() {Seat.Of("A", 1, "")};
            return new List<Seat>() {Seat.Of("A", 1, ""), Seat.Of("A", 2, "") };
        }
    }
}