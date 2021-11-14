using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Chala.backend.Infrastructure.Utils
{
    public class StaticFunctions
    {
        public static string GenerateJwtToken(Guid Id)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(Constants.jwtExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void CreateTestMessage2(string server)
        {
            string to = "m_love_1999@hotmail.com";
            string from = "Chala.Application@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            SmtpClient client = new SmtpClient(server);
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }

        public static void SendVerificationCodeToUserEmail(string email, string firstName, string verificationCode)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "Chala.Application@gmail.com",
                    Password = "Kittany1999#"
                }
            };
            MailAddress FromEmail = new MailAddress("Chala.Application@gmail.com", "Chala Corporation");
            MailAddress ToEmail = new MailAddress(email, firstName);
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Chala Verification Code For Email",
                Body = $"<h1>Your Verification code is {verificationCode}</h1>",
                //IsBodyHtml = true,
            };
            Message.To.Add(email);

            //MailMessage Message = new MailMessage("Chala.Application@gmail.com", email, "Chala Verification Code For Email", $"Your Verification code is {verificationCode}");
            try
            {
                client.Send(Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
