namespace KataTrainReservation
{
    public interface ITrainData
    {
        Coach GetSeatInCoach(string train, string coach);
    }
}