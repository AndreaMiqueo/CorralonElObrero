using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoralónElObrero.Models
{
    public class EmailServerConfiguration
    {

        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpSsl { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }

    }
}
