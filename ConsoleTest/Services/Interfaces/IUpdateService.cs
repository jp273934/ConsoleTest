namespace ConsoleTest.Services.Interfaces
{
    public interface IUpdateService
    {
        void UpdateRow(long apiNumber, int tankNumber, int fieldNumber, string fieldValue);
    }
}
