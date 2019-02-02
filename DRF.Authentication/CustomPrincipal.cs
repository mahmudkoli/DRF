using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DRF.Authentication
{
    public class CustomPrincipal : IPrincipal
    {
        // customize ...
        private CustomIdentity _customIdentity;
        public CustomPrincipal(CustomIdentity customIdentity)
        {
            _customIdentity = customIdentity;
        }
        public IIdentity Identity => _customIdentity;

        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(role);
        }
    }
}
