namespace KataTrainReservation
{
    public interface ISeat
    {
        Coach GetCoach(string train, string coach);
        Train GetTrain(string train);
    }
}