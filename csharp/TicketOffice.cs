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
        private readonly ISeat _seat;
        private readonly IReservationRegister _reservationRegister;

        public TicketOffice(ISeat seat, IReservationRegister reservationRegister)
        {
            _seat = seat;
            _reservationRegister = reservationRegister;
        }

        public Reservation MakeReservation(ReservationRequest request)
        {
            var seatInTrain = _seat.GetInTrain(request.TrainId);
            var selectFreeSeat = seatInTrain.SelectFreeSeat(request.SeatCount);
            return Reservation.Of(request.TrainId, selectFreeSeat.Count != 0 ? "75bcd15" : "", selectFreeSeat);
        }

        public Reservation MakeReservationInCoach(ReservationRequest request)
        {
            var seatInCoach = _seat.GetInCoach(request.TrainId, "A");
            var selectedFreeSeat = seatInCoach.SelectFreeSeat(percentReserved => percentReserved < 70, request.SeatCount);

            if (HasSeatSelected(selectedFreeSeat))
            {
                var reservation = Reservation.Of(request.TrainId, "75bcd15", selectedFreeSeat);

                var reserve = _reservationRegister.Reserve(reservation);
                if (reserve.IsSuccess())
                    return reservation;
            }

            return EmptyReservation(request.TrainId);
        }

        private static bool HasSeatSelected(List<Seat> selectedFreeSeat) => selectedFreeSeat.Count != 0;

        private static Reservation EmptyReservation(string trainId) => Reservation.Of(trainId, "", new List<Seat>());
    }
}
