using System.Net.Mail;
using System.Threading.Tasks;

namespace LearningService.WebApplication.Helpers
{
    public static class MailNotification
    {
        public static async Task SendEmail(string receiver, string title, string content)
        {
            var email = new MailMessage
            {
                Subject = title,
                Body = content,
                IsBodyHtml = true
            };
            email.To.Add(new MailAddress(receiver));
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(email);
            }
        }
    }
}
