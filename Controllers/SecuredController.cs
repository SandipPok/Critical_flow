using Critical_Flow.Models;

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Critical_Flow.Controllers
{
    public class SecuredController : Controller
    {
        [Authorize]
        public IActionResult Critical()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(Message messageObj)
        {
            try
            {
                var message = new MimeMessage();
                var bodyBuilder = new BodyBuilder();

                // from
                message.From.Add(new MailboxAddress("Bureau", "email"));
                // to
                message.To.Add(new MailboxAddress("Recipient", messageObj.MailTo));

                message.Subject = messageObj.Subject;
                bodyBuilder.HtmlBody = messageObj.MessageBody;
                message.Body = bodyBuilder.ToMessageBody();

                var client = new SmtpClient();

                client.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("Email", "Password");
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception ex) { }

            return Redirect("/");
        }
    }
}