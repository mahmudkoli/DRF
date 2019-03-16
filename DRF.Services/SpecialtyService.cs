using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Common;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class SpecialtyService
    {
        private SpecialtyUnitOfWork _specialtyUnitOfWork;

        public SpecialtyService()
        {
            _specialtyUnitOfWork = new SpecialtyUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Specialty> GetAll()
        {
            return _specialtyUnitOfWork.SpecialtyRepository.GetAll();
        }

        public IEnumerable<string> GetAllSpecialtyName(string term)
        {
            return _specialtyUnitOfWork.SpecialtyRepository.Get(x => x.Name.ToLower().Contains(term.ToLower()))
                .Select(y => y.Name);
        }

        public IEnumerable<Specialty> GetAll(string name, byte? status)
        {
            var data = _specialtyUnitOfWork.SpecialtyRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var specialty = _specialtyUnitOfWork.SpecialtyRepository.GetById(id);
            specialty.Status = specialty.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            specialty.UpdatedAt = DateTime.Now;
            return _specialtyUnitOfWork.Save();
        }

        public bool AddOrUpdate(Specialty specialty)
        {
            if (specialty.Id == 0)
            {
                var newSpecialty = new Specialty()
                {
                    Name = specialty.Name,
                    Disease = specialty.Disease,
                    Details = specialty.Details,
                    Status = (byte)CustomEnum.Status.Active,
                    CreatedAt = DateTime.Now
                };
                _specialtyUnitOfWork.SpecialtyRepository.Add(newSpecialty);
            }
            else
            {
                var existSpecialty = _specialtyUnitOfWork.SpecialtyRepository.GetById(specialty.Id);
                existSpecialty.Name = specialty.Name;
                existSpecialty.Disease = specialty.Disease;
                existSpecialty.Details = specialty.Details;
                existSpecialty.UpdatedAt = DateTime.Now;
                _specialtyUnitOfWork.SpecialtyRepository.Update(existSpecialty);
            }

            return _specialtyUnitOfWork.Save();
        }
    }
}
