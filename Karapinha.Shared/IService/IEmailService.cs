using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}

