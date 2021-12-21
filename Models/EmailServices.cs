using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoralónElObrero.Models
{
    public class EmailServices : IEmailService
    {
        private readonly EmailServerConfiguration _emailConfiguration;

        public EmailServices(IOptions<EmailServerConfiguration> configuration)
        {
            _emailConfiguration = configuration.Value;
        }
        public async Task EnviarEmailAsync(ContactFormModel contact)
        {
            try
            {
                var mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress(contact.Nombre, _emailConfiguration.SmtpUserName));
                mensaje.To.Add(new MailboxAddress("", _emailConfiguration.SmtpUserName));
                mensaje.Subject = "Contacto";
                mensaje.Body = new TextPart("html")
                {
                    Text = contact.Mensaje + "<br/>" + "<br/>Nombre: " + contact.Nombre + "<br/>" +
                    "<br/>Telefono: " + contact.Telefono + "<br/>" + "<br/>Email: " + contact.Email

                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(_emailConfiguration.SmtpUserName, _emailConfiguration.SmtpPassword);
                    await client.SendAsync(mensaje);
                    await client.DisconnectAsync(true);


                }

            }
            catch (Exception)
            {

            }
        }
    }
}
