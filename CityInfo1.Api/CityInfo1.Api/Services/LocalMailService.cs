using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo1.Api.Services
{
    public class LocalMailService : ILocalMailService
    {
        //private string _mailTo = "admin@mycompany.com";
        //private string _mailFrom = "noreply@mycompany.com";

        private string _mailTo = Startup.configuration["MailTo"];
        private string _mailFrom = Startup.configuration["MailFrom"];

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");
            Debug.WriteLine($"Subject : {subject}");
            Debug.WriteLine($"Message : {message}");
        }
    }
}
