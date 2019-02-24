using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class AppointmentRepository : Repository<Appointment>
    {
        private DRFDbContext _context;
        public AppointmentRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllByDoctorId(int id)
        {
            return base.Get(x => x.DoctorId == id);
        }

        public IEnumerable<Appointment> GetAllByDoctorIdWithStatus(int id, int status)
        {
            return base.Get(x => x.DoctorId == id && x.AppointmentStatus == status);
        }

        public Patient GetLastAppointmentRequestPatientByDoctorId(int doctorId)
        {
            return base.Get(x => x.DoctorId == doctorId).OrderByDescending(y => y.CreatedAt).Select(t => t.Patient).FirstOrDefault();
        }
    }
}
