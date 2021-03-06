using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace KataTrainReservation.TicketOfficeTest
{
    [TestFixture]
    public class TicketOfficeReservationInCoach
    {
        private TicketOffice _ticketOffice;

        [SetUp]
        public void Setup()
        {
            var trainData = new Mock<ISeat>();
            trainData.Setup(e => e.GetCoach("express_2000", "A")).Returns(Coach.Of(new List<Seat>() {
                Seat.Of("A" , 1, "75bcd14"),
                Seat.Of("A" , 2, "75bcd14"),
                Seat.Of("A" , 3, "75bcd14"),
                Seat.Of("A" , 4, "75bcd14"),
                Seat.Of("A" , 5, ""),
                Seat.Of("A" , 6, ""),
                Seat.Of("A" , 7, ""),
                Seat.Of("A" , 8, "")
            }));
            trainData.Setup(e => e.GetCoach("local_1000", "A")).Returns(Coach.Of(new List<Seat>() {
                Seat.Of("A" , 1, ""),
                Seat.Of("A" , 2, ""),
                Seat.Of("A" , 3, ""),
                Seat.Of("A" , 4, "")
            }));
            trainData.Setup(e => e.GetCoach("test_3000", "A")).Returns(Coach.Of(new List<Seat>() {
                Seat.Of("A" , 1, "75bcd14"),
                Seat.Of("A" , 2, "75bcd14"),
                Seat.Of("A" , 3, "75bcd14"),
                Seat.Of("A" , 4, "75bcd14")
            }));

            var reservationRegister = new Mock<IReservationRegister>();
            reservationRegister.Setup(e => e.Reserve(It.IsAny<Reservation>())).Returns(Result.WasSucces(null));

            var bookingReference = new Mock<IBookingReference>();
            bookingReference.Setup(e => e.GetBookingReference()).Returns("75bcd15");

            _ticketOffice = new TicketOffice(trainData.Object, reservationRegister.Object, bookingReference.Object);
        }

        [Test]
        public void Reserve1SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("local_1000", "75bcd15", new List<Seat>() {Seat.Of("A", 1, "")});
            Reservation result = _ticketOffice.MakeReservationInCoach(ReservationRequest.Of("local_1000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve2SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("local_1000", "75bcd15", new List<Seat>() { Seat.Of("A", 1, ""), Seat.Of("A", 2, "") });
            Reservation result = _ticketOffice.MakeReservationInCoach(ReservationRequest.Of("local_1000", 2));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve1SeatsInPartiallyReservedCoachReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("express_2000", "75bcd15", new List<Seat>() { Seat.Of("A", 5, "") });
            Reservation result = _ticketOffice.MakeReservationInCoach(ReservationRequest.Of("express_2000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve1SeatsInFullyBookedCoachReturnFailReservation()
        {
            Reservation expected = Reservation.Of("test_3000", "", new List<Seat>() {});
            Reservation result = _ticketOffice.MakeReservationInCoach(ReservationRequest.Of("test_3000", 1));

            Assert.AreEqual(expected, result);
        }
    }
}
