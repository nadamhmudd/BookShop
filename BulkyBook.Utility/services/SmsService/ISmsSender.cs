namespace BulkyBook.Utility
{
    public interface ISmsSender
    {
        Task SendSMSAsync(string phoneNumber, string message);
    }
}