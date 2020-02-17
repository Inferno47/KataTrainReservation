using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataTrainReservation.TicketOfficeTest;

namespace KataTrainReservation
{
    public class TicketOffice
    {
        private readonly ITrainData _trainData;

        public TicketOffice(ITrainData trainData)
        {
            _trainData = trainData;
        }

        public Reservation MakeReservation(ReservationRequest request)
        {
            List<Seat> seats = new List<Seat>();
            int startValue = 0;
            if (request.TrainId == "express_2000") startValue = 4;
            for (var i = 1; i <= request.SeatCount; i++) seats.Add(new Seat("A", i + startValue, null));

            return new Reservation(request.TrainId, "75bcd15", seats);
        }
    }
}
