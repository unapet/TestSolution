using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Service
{
    public interface IEmailService
    {
        void SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);

        void SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    }
}