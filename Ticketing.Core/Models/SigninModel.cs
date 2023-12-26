using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Models
{
    public class SigninModel
    {
        public SigninModel(int userId,string username,string firstName,string lastName,bool isPersist=false)
        {
            UserId = userId;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            IsPersist = isPersist;
        }

        public int UserId { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsPersist { get; }
    }
}
