using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DRF.Entities;
using DRF.Services;
using WebGrease.Css.Extensions;

namespace DRF.Web.Areas.Doctor.Models
{
    public class ScheduleModel
    {
        [Required]
        [Display(Name = "Chamber")]
        public int ChamberId { get; set; }
        public IEnumerable<Chamber> ChamberCollection { get; set; }
        public IEnumerable<Schedule> ScheduleCollection { get; set; }

        private ScheduleService _scheduleService;
        private ChamberService _chamberService;

        public ScheduleModel()
        {
            _scheduleService = new ScheduleService();
            _chamberService = new ChamberService();

            ChamberCollection = _chamberService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _scheduleService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
        }

        public bool Add()
        {
            this.ScheduleCollection.ForEach(x =>
            {
                x.ChamberId = this.ChamberId;
                x.DoctorId = AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id;
            });

            return _scheduleService.AddRange(this.ScheduleCollection);
        }
    }
}