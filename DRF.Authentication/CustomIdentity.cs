using DRF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Authentication
{
    public class CustomIdentity : IIdentity
    {
        // customize ...
        private IIdentity _identity;
        private User _user;

        public CustomIdentity(User user)
        {
            _identity = new GenericIdentity(user.Email);
            _user = user;
        }
        public string Name => _identity.Name;

        public string AuthenticationType => _identity.AuthenticationType;

        public bool IsAuthenticated => _identity.IsAuthenticated;

        // customize ...
        public User User => _user;
    }
}
