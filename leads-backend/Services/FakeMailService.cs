namespace leads_backend.Services
{
    public class FakeMailService
    {
        public static void SendMail(string email, string message)
        {
            Console.WriteLine($"Sending mail to {email} with message: {message}");
        }
    }
}
