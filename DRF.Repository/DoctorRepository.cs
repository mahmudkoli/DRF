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
    public class DoctorRepository : Repository<Doctor>
    {
        private DRFDbContext _context;
        public DoctorRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }

        public Doctor GetByUserId(int userId)
        {
            return base.Get(x => x.UserId == userId).FirstOrDefault();
        }

        public void DoctorChamberRelationsDeleteRange(IEnumerable<DoctorChamberRelation> entities)
        {
            _context.DoctorChamberRelations.RemoveRange(entities);
        }
        public void DoctorDegreeRelationsDeleteRange(IEnumerable<DoctorDegreeRelation> entities)
        {
            _context.DoctorDegreeRelations.RemoveRange(entities);
        }
        public void DoctorSpecialtyRelationsDeleteRange(IEnumerable<DoctorSpecialtyRelation> entities)
        {
            _context.DoctorSpecialtyRelations.RemoveRange(entities);
        }

        public IEnumerable<Doctor> GetAllDoctors(string area, string specialty, string name)
        {
            var doctors = (IEnumerable<Doctor>)_context.Doctors;
            doctors = string.IsNullOrEmpty(area)
                ? doctors
                : doctors.Where(x => x.DoctorChamberRelations.Any( y => 
                                         y.Chamber.Area.Name.ToLower().Contains(area.ToLower())));

            doctors = string.IsNullOrEmpty(specialty)
                ? doctors
                : doctors.Where(x => x.DoctorSpecialtyRelations.Any(y =>
                                        y.Specialty.Name.ToLower().Contains(specialty.ToLower())));

            doctors = string.IsNullOrEmpty(name)
                ? doctors
                : doctors.Where(x => x.User.Name.ToLower().Contains(name.ToLower()));

            return doctors;
        }
    }
}
