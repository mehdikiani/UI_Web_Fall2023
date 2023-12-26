using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Services
{
    public class RandomDataService : IRandomDataService
    {
        public string GetRandomString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
