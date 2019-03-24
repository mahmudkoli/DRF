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
        private VacationService _vacationService;
        private ChamberService _chamberService;

        public VacationModel()
        {
            _vacationService = new VacationService();
            _chamberService = new ChamberService();
        }

        public bool Add()
        {
            this.DoctorId = AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id;
            return _vacationService.Add(this);
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationService.GetAll();
        }
    }
}