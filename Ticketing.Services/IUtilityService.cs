using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Services
{
    public interface IUtilityService
    {
        string HashPassword(string password, string salt);
        string Sha256(string clear);
    }
}
