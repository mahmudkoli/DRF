using DRF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Models
{
    [Authorize(Roles = "Admin")]
    public static class AuthenticatedAdminUserModel
    {
        public static User GetUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as DRF.Authentication.CustomPrincipal).Identity as DRF.Authentication.CustomIdentity;
            return authUser.User;
        }
    }
}