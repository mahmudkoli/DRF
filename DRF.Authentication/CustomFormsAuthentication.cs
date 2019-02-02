using DRF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace DRF.Authentication
{
    public static class CustomFormsAuthentication
    {
        public static bool Login(User user, bool remember)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string data = js.Serialize(user);
                int timeout = remember ? 525600 : 30; // 525600 min = 1 year

                var ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now,
                    DateTime.Now.AddMinutes(timeout), remember, data);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
