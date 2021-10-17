namespace ConsoleTest.Services.Interfaces
{
    public interface IReadService
    {
        void ReadData();
        void ReadDataRow(long ApiNumber, int tankNumber = 0);
    }
}
