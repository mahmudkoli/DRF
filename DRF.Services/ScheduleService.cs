using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class ScheduleService
    {
        private ScheduleUnitOfWork _scheduleUnitOfWork;

        public ScheduleService()
        {
            _scheduleUnitOfWork = new ScheduleUnitOfWork(new DRFDbContext());
        }
    }
}
