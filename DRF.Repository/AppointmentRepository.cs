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
            return base.Get(x => x.DoctorId == id).OrderByDescending(y => y.CreatedAt);
        }

        public IEnumerable<Appointment> GetAllByDoctorIdWithStatus(int doctorId, int status)
        {
            return base.Get(x => x.DoctorId == doctorId && x.AppointmentStatus == status).OrderByDescending(y => y.UpdatedAt);
        }

        public IEnumerable<Appointment> GetAllByPatientId(int patientId)
        {
            return base.Get(x => x.PatientId == patientId).OrderByDescending(y => y.CreatedAt);
        }

        public IEnumerable<Appointment> GetAllByPatientIdWithStatus(int patientId, int status)
        {
            return base.Get(x => x.PatientId == patientId && x.AppointmentStatus == status).OrderByDescending(y => y.UpdatedAt);
        }
    }
}
