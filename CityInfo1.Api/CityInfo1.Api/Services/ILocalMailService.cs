using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo1.Api.Services
{
    public interface ILocalMailService
    {
        void Send(string subject, string message);
    }
}
