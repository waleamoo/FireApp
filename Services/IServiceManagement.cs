namespace FireApp.Services; 

public interface IServiceManagement
{
    void SendEmail();
    void UpdatedDatabase();
    void GenerateMerchandise();
    void SyncData();
}