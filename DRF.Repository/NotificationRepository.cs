﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class NotificationRepository : Repository<Notification>
    {
        private DRFDbContext _context;

        public NotificationRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
