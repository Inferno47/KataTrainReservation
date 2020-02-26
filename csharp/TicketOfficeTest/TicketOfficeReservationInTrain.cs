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
            trainData.Setup(e => e.GetInTrain("empty_train")).Returns(Train.Of(new List<Seat>()
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

            trainData.Setup(e => e.GetInTrain("1coachReserved_train")).Returns(Train.Of(new List<Seat>()
            {
                Seat.Of("A" , 1, "75bcd14"),
                Seat.Of("A" , 2, "75bcd14"),
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

            var reservationRegister = new Mock<IReservationRegister>();
            reservationRegister.Setup(e => e.Reserve(It.IsAny<Reservation>())).Returns(Result.WasSucces(null));
            _ticketOffice = new TicketOffice(trainData.Object, reservationRegister.Object);
        }

        [Test]
        public void Reserve1SeatsInEmptyTrainReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("empty_train", "75bcd15", new List<Seat>() {Seat.Of("A", 1, "")});
            Reservation result = _ticketOffice.MakeReservation(ReservationRequest.Of("empty_train", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Reserve2SeatsInTrainWith1CoachReservedReturnSuccessReservation()
        {
            Reservation expected = Reservation.Of("1coachReserved_train", "75bcd15", new List<Seat>() { Seat.Of("B", 1, ""), Seat.Of("B", 2, "") });
            Reservation result = _ticketOffice.MakeReservation(ReservationRequest.Of("1coachReserved_train", 2));

            Assert.AreEqual(expected, result);
        }
    }
}

