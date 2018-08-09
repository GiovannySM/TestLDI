namespace TestLDI.Services
{
    public interface IDBContextConfiguration
    {
        string DataBaseName { get; set; }

        bool InstallDBContext();
    }
}