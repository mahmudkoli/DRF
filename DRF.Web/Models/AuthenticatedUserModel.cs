using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Models
{
    [Authorize]
    public static class AuthenticatedUserModel
    {
        public static User GetUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as DRF.Authentication.CustomPrincipal).Identity as DRF.Authentication.CustomIdentity;
            return authUser.User;
        }
    }
}