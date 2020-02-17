namespace KataTrainReservation.TicketOfficeTest
{
    public interface ITrainData
    {
        Coach GetSeatInCoach(string train, string coach);
    }
}