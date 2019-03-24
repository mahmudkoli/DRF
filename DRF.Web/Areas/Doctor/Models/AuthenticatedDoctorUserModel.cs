using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Doctor.Models
{
    [Authorize(Roles = "Doctor")]
    public static class AuthenticatedDoctorUserModel
    {
        private static DoctorService _doctorService = new DoctorService();
        public static User GetUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as DRF.Authentication.CustomPrincipal).Identity as DRF.Authentication.CustomIdentity;
            return authUser.User;
        }
        public static Entities.Doctor GetDoctorUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as DRF.Authentication.CustomPrincipal).Identity as DRF.Authentication.CustomIdentity;
            var authDoctorUser = _doctorService.GetByUserId(authUser.User.Id);
            return authDoctorUser;
        }

        public static bool IsExistDoctor()
        {
            return GetDoctorUserFromIdentity() != null;
        }
    }
}