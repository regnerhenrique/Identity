using System.Threading.Tasks;

namespace GamerCave.Identity.Domain.Interface.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
