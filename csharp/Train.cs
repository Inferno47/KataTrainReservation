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
    }
}