using DRF.Common;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Services
{
    public class VacationService
    {
        private VacationUnitOfWork _vacationUnitOfWork;

        public VacationService()
        {
            _vacationUnitOfWork = new VacationUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationUnitOfWork.VacationRepository.GetAll();
        }

        public bool Add(Vacation entity)
        {
            try
            {
                var newEntity = new Vacation()
                {
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    DoctorId = entity.DoctorId,
                    ChamberId = entity.ChamberId,
                    Reason = entity.Reason
                };
                _vacationUnitOfWork.VacationRepository.Add(newEntity);
                return _vacationUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool ChangeStatus(int id)
        {
            var vacation = _vacationUnitOfWork.VacationRepository.GetById(id);
            vacation.Status = vacation.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            vacation.UpdatedAt = DateTime.Now;
            return _vacationUnitOfWork.Save();
        }
    }
}
