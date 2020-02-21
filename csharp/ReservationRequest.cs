using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class ReservationRequest
    {
        public static ReservationRequest Of(string trainId, int seatCount)
        {
            return new ReservationRequest(trainId, seatCount);
        }

        public string TrainId { get; private set; }
        public int SeatCount { get; private set; }

        private ReservationRequest(string trainId, int seatCount)
        {
            this.TrainId = trainId;
            this.SeatCount = seatCount;
        }
    }
}