using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DRF.Common
{
    public static class CustomEmail
    {
        public static bool SendVerificationLinkEmail(string email, string activationCode, string emailFor = "VerifyAccount")
        {
            try
            {
                var verifyUrl = "/User/" + emailFor + "/" + activationCode;
                var link = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, verifyUrl);

                var fromEmail = new MailAddress(Secret.Email, "Mahmud Koli");
                var toEmail = new MailAddress(email);
                var fromEmailPassword = Secret.EmailPassword; // Replace with actual password

                string subject = "";
                string body = "";
                if (emailFor == "VerifyAccount")
                {
                    subject = "Your account is successfully created!";
                    body = "<br/><br/>We are excited to tell you that your account is" +
                           " successfully created. Please click on the below link to verify your account" +
                           " <br/><br/><a href='" + link + "'>" + link + "</a> ";
                }
                else if (emailFor == "ResetPassword")
                {
                    subject = "Reset Password";
                    body = "Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
                           "<br/><br/><a href=" + link + ">Reset Password link</a>";
                }

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
                };

                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })

                smtp.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
