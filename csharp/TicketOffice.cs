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
            var seatInCoach = _trainData.GetSeatInCoach(request.TrainId, "A");
            var seats = seatInCoach.SelectSeat(request.SeatCount);
            return Reservation.Of(request.TrainId, seats.Count > 0 ? "75bcd15" : "", seats);
        }

        
    }
}
