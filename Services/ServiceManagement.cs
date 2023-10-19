namespace FireApp.Services;

public class ServiceManagement : IServiceManagement
{
    public void GenerateMerchandise()
    {
        Console.WriteLine($"Generate merchandise: Long runnig task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void SendEmail()
    {
        Console.WriteLine($"Email Sent: Short runnig task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void SyncData()
    {
        Console.WriteLine($"Sync Data: Short runnig task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void UpdatedDatabase()
    {
        Console.WriteLine($"Update Database: Short runnig task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

    }
}