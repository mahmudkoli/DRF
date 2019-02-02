using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class UserRepository : Repository<User>
    {
        private DRFDbContext _context;
        public UserRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return base.Get(x => x.Email == email).FirstOrDefault();
        }

        public IEnumerable<UserRole> GetAllUserRoles()
        {
            return _context.UserRoles.Where(x => x.Role != "Admin");
        }
    }
}
