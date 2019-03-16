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
    public class DegreeService
    {
        private DegreeUnitOfWork _degreeUnitOfWork;

        public DegreeService()
        {
            _degreeUnitOfWork = new DegreeUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Degree> GetAll()
        {
            return _degreeUnitOfWork.DegreeRepository.GetAll();
        }

        public IEnumerable<Degree> GetAll(string name, byte? status)
        {
            var data = _degreeUnitOfWork.DegreeRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var degree = _degreeUnitOfWork.DegreeRepository.GetById(id);
            degree.Status = degree.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            degree.UpdatedAt = DateTime.Now;
            return _degreeUnitOfWork.Save();
        }

        public bool AddOrUpdate(Degree degree)
        {
            if (degree.Id == 0)
            {
                var newDegree = new Degree()
                {
                    Name = degree.Name,
                    Details = degree.Details,
                    Status = (byte)CustomEnum.Status.Active,
                    CreatedAt = DateTime.Now
                };
                _degreeUnitOfWork.DegreeRepository.Add(newDegree);
            }
            else
            {
                var existDegree = _degreeUnitOfWork.DegreeRepository.GetById(degree.Id);
                existDegree.Name = degree.Name;
                existDegree.Details = degree.Details;
                existDegree.UpdatedAt = DateTime.Now;
                _degreeUnitOfWork.DegreeRepository.Update(existDegree);
            }

            return _degreeUnitOfWork.Save();
        }
    }
}
