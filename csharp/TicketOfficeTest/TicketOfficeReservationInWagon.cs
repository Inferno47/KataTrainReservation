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
            _trainData.Setup(e => e.GetSeatInCoach("express_2000", "A")).Returns(new List<Seat>() {
                new Seat("A" , 1, "75bcd14"),
                new Seat("A" , 2, "75bcd14"),
                new Seat("A" , 3, "75bcd14"),
                new Seat("A" , 4, "75bcd14"),
                new Seat("A" , 5, ""),
                new Seat("A" , 6, ""),
                new Seat("A" , 7, ""),
                new Seat("A" , 8, "")
            });

            _trainData.Setup(e => e.GetSeatInCoach("local_1000", "A")).Returns(new List<Seat>() {
                new Seat("A" , 1, ""),
                new Seat("A" , 2, ""),
                new Seat("A" , 3, ""),
                new Seat("A" , 4, "")
            });
        }

        [Test]
        public void reserve1SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = new Reservation("local_1000", "75bcd15", new List<Seat>() {new Seat("A", 1, "")});
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("local_1000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void reserve2SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = new Reservation("local_1000", "75bcd15", new List<Seat>() { new Seat("A", 1, ""), new Seat("A", 2, "") });
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("local_1000", 2));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void reserve1SeatsInPartiallyReservedCoachReturnSuccessReservation()
        {
            Reservation expected = new Reservation("express_2000", "75bcd15", new List<Seat>() { new Seat("A", 5, "") });
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("express_2000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void reserve1SeatsInFullyBookedCoachReturnSuccessReservation()
        {
            Reservation expected = new Reservation("test_3000", "", new List<Seat>() {});
            TicketOffice ticketOffice = new TicketOffice(_trainData.Object);
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("test_3000", 1));

            Assert.AreEqual(expected, result);
        }
    }
}
