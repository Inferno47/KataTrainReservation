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
        private readonly IBookingReference _booking;

        public TicketOffice(ISeat seat, IReservationRegister reservationRegister, IBookingReference booking)
        {
            _seat = seat;
            _reservationRegister = reservationRegister;
            _booking = booking;
        }

        public Reservation MakeReservation(ReservationRequest request)
        {
            var train = _seat.GetTrain(request.TrainId);
            var selectedFreeSeat = train.SelectFreeSeat(request.SeatCount);
            return Reservation.Of(request.TrainId, selectedFreeSeat.Count != 0 ? _booking.GetBookingReference() : "", selectedFreeSeat);
        }

        public Reservation MakeReservationInCoach(ReservationRequest request)
        {
            var seatInCoach = _seat.GetCoach(request.TrainId, "A");
            var selectedFreeSeat = seatInCoach.SelectFreeSeat(percentReserved => percentReserved < 70, request.SeatCount);

            if (HasSeatSelected(selectedFreeSeat))
            {
                var reservation = Reservation.Of(request.TrainId, _booking.GetBookingReference(), selectedFreeSeat);

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
