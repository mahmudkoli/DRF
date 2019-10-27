using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class NotificationUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private NotificationRepository _notificationRepository;
        public NotificationUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _notificationRepository = new NotificationRepository(_context);
        }

        public NotificationRepository NotificationRepository => _notificationRepository;

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
