using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Models
{
    [Authorize(Roles = "Patient")]
    public static class AuthenticatedPatientUserModel
    {
        private static PatientService _patientService = new PatientService();
        public static User GetUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as DRF.Authentication.CustomPrincipal).Identity as DRF.Authentication.CustomIdentity;
            return authUser.User;
        }
        public static Entities.Patient GetPatientUserFromIdentity()
        {
            var authUser = (HttpContext.Current.User as DRF.Authentication.CustomPrincipal).Identity as DRF.Authentication.CustomIdentity;
            var authPatientUser = _patientService.GetByUserId(authUser.User.Id);
            return authPatientUser;
        }
    }
}