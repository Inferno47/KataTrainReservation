using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace KataTrainReservation.TicketOfficeTest
{
    [TestFixture]
    public class TicketOfficeReservationInTrain
    {
        private TicketOffice _ticketOffice;

        [SetUp]
        public void Setup()
        {
            var trainData = new Mock<ISeat>();
            trainData.Setup(e => e.GetInTrain("local_1000")).Returns(new Train(new List<Seat>()
            {
                Seat.Of("A" , 1, ""),
                Seat.Of("A" , 2, ""),
                Seat.Of("A" , 3, ""),
                Seat.Of("A" , 4, ""),
                Seat.Of("B" , 1, ""),
                Seat.Of("B" , 2, ""),
                Seat.Of("B" , 3, ""),
                Seat.Of("B" , 4, ""),
                Seat.Of("C" , 1, ""),
                Seat.Of("C" , 2, ""),
                Seat.Of("C" , 3, ""),
                Seat.Of("C" , 4, ""),
            }));
            trainData.Setup(e => e.GetInTrain("express_2000")).Returns(new Train(new List<Seat>()
            {
                Seat.Of("A" , 1, "75bcd14"),
                Seat.Of("A" , 2, "75bcd14"),
                Seat.Of("A" , 3, "75bcd14"),
                Seat.Of("A" , 4, "75bcd14"),
                Seat.Of("A" , 5, ""),
                Seat.Of("A" , 6, ""),
                Seat.Of("A" , 7, ""),
                Seat.Of("A" , 8, ""),
                Seat.Of("B" , 1, ""),
                Seat.Of("B" , 2, ""),
                Seat.Of("B" , 3, ""),
                Seat.Of("B" , 4, ""),
                Seat.Of("B" , 5, ""),
                Seat.Of("B" , 6, ""),
                Seat.Of("B" , 7, ""),
                Seat.Of("B" , 8, ""),
                Seat.Of("C" , 1, ""),
                Seat.Of("C" , 2, ""),
                Seat.Of("C" , 3, ""),
                Seat.Of("C" , 4, ""),
                Seat.Of("C" , 5, ""),
                Seat.Of("C" , 6, ""),
                Seat.Of("C" , 7, ""),
                Seat.Of("C" , 8, ""),
            }));

            var reservationRegister = new Mock<IReservationRegister>();
            reservationRegister.Setup(e => e.Reserve(It.IsAny<Reservation>())).Returns(Result.WasSucces(null));
            _ticketOffice = new TicketOffice(trainData.Object, reservationRegister.Object);
        }

        [Test]
        public void Reserve1SeatsInEmptyTrainReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("local_1000", "75bcd15", new List<Seat>() {Seat.Of("A", 1, "")});
            Reservation result = _ticketOffice.MakeReservation(ReservationRequest.Of("local_1000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve1SeatsInPartiallyReservedTrainReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("express_2000", "75bcd15", new List<Seat>() { Seat.Of("A", 5, "") });
            Reservation result = _ticketOffice.MakeReservation(ReservationRequest.Of("express_2000", 1));

            Assert.AreEqual(expected, result);
        }
    }
}
