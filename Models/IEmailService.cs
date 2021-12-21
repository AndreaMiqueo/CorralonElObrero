using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoralónElObrero.Models
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(ContactFormModel contact);
    }
}
