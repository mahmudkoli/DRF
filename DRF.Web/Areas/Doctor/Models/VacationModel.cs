using DRF.Entities;
using DRF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRF.Web.Areas.Doctor.Models
{
    public class VacationModel : Vacation
    {
        public IEnumerable<Chamber> ChamberCollection { get; set; }

        private VacationService _vacationService;
        private ChamberService _chamberService;

        public VacationModel()
        {
            _vacationService = new VacationService();
            _chamberService = new ChamberService();

            ChamberCollection = _chamberService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
        }

        public VacationModel(int id) : this()
        {
            var existVacation = _vacationService.GetById(id);
            if (existVacation != null)
            {
                this.Id = existVacation.Id;
                this.ChamberId = existVacation.ChamberId;
                this.DoctorId = existVacation.DoctorId;
                this.StartDate = existVacation.StartDate;
                this.EndDate = existVacation.EndDate;
                this.Reason = existVacation.Reason;
            }
        }

        public bool Add()
        {
            this.DoctorId = AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id;
            return _vacationService.Add(this);
        }

        public IEnumerable<Vacation> GetAllVacations()
        {
            return _vacationService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
        }

        public IEnumerable<Vacation> GetAllVacations(int? chamber, DateTime? fromDate, DateTime? toDate)
        {
            return _vacationService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id, chamber, fromDate, toDate);
        }

        public IEnumerable<Chamber> GetAllChamberByDoctorId()
        {
            return _chamberService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
        }

        public bool Delete(int id)
        {
            return _vacationService.Delete(id);
        }

        public Vacation GetVacationById(int id)
        {
            return _vacationService.GetById(id);
        }

        public bool Update()
        {
            return _vacationService.Update(this);
        }
    }
}