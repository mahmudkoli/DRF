using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class UserUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private UserRepository _userRepository;
        public UserUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        public UserRepository UserRepository { get { return _userRepository; } }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
