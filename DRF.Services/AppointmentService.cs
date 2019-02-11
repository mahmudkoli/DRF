using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class AppointmentService
    {
        private AppointmentUnitOfWork _appointmentUnitOfWork;

        public AppointmentService()
        {
            _appointmentUnitOfWork = new AppointmentUnitOfWork(new DRFDbContext());
        }
    }
}
