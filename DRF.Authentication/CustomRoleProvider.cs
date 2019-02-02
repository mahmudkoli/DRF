using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using System.Web.Caching;

namespace DRF.Authentication
{
    public class CustomRoleProvider : RoleProvider
    {
        // customize ...
        private int _cacheTimeOutInMinute = 30;
        private DRFDbContext _context;

        public CustomRoleProvider()
        {
            _context = new DRFDbContext();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        // customize ...
        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            // check cache 
            var cacheKey = string.Format("{0}_role", username);

            if (HttpRuntime.Cache[cacheKey] != null)
            {
                return (string[])HttpRuntime.Cache[cacheKey];
            }

            var roles = new string[] { };
            var users = _context.Users.Where(x => x.Email.Equals(username)).ToList();
            roles = users.Select(y => y.UserRole.Role).ToArray<string>();

            if (roles.Count() > 0)
            {
                HttpRuntime.Cache.Insert(cacheKey, roles, null,
                    DateTime.Now.AddMinutes(_cacheTimeOutInMinute), Cache.NoSlidingExpiration);
            }

            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        // customize ...
        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
