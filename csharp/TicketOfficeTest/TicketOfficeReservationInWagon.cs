using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace KataTrainReservation.TicketOfficeTest
{
    [TestFixture]
    public class TicketOfficeReservationInCoach
    {
        private Mock<ITrainData> _trainData;

        [SetUp]
        public void Setup()
        {
            _trainData = new Mock<ITrainData>();
            _trainData.Setup(e => e.GetSeatInCoach("express_2000", "A")).Returns(Coach.Of(new List<Seat>() {
                Seat.Of("A" , 1, "75bcd14"),
                Seat.Of("A" , 2, "75bcd14"),
                Seat.Of("A" , 3, "75bcd14"),
                Seat.Of("A" , 4, "75bcd14"),
                Seat.Of("A" , 5, ""),
                Seat.Of("A" , 6, ""),
                Seat.Of("A" , 7, ""),
                Seat.Of("A" , 8, "")
            }));

            _trainData.Setup(e => e.GetSeatInCoach("local_1000", "A")).Returns(Coach.Of(new List<Seat>() {
                Seat.Of("A" , 1, ""),
                Seat.Of("A" , 2, ""),
                Seat.Of("A" , 3, ""),
                Seat.Of("A" , 4, "")
            }));

            _trainData.Setup(e => e.GetSeatInCoach("test_3000", "A")).Returns(Coach.Of(new List<Seat>() {
                Seat.Of("A" , 1, "75bcd14"),
                Seat.Of("A" , 2, "75bcd14"),
                Seat.Of("A" , 3, "75bcd14"),
                Seat.Of("A" , 4, "75bcd14")
            }));
        }

        [Test]
        public void Reserve1SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("local_1000", "75bcd15", new List<Seat>() {Seat.Of("A", 1, "")});
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("local_1000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve2SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("local_1000", "75bcd15", new List<Seat>() { Seat.Of("A", 1, ""), Seat.Of("A", 2, "") });
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("local_1000", 2));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve1SeatsInPartiallyReservedCoachReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("express_2000", "75bcd15", new List<Seat>() { Seat.Of("A", 5, "") });
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("express_2000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve1SeatsInFullyBookedCoachReturnFailReservation()
        {
            Reservation expected = Reservation.Of("test_3000", "", new List<Seat>() {});
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("test_3000", 1));

            Assert.AreEqual(expected, result);
        }
    }
}
