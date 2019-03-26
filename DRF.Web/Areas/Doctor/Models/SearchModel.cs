using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using PagedList;

namespace DRF.Web.Areas.Doctor.Models
{
    public class AppointmentSearchModel
    {
        public int? AppointmentStatus { get; set; }
        public int? LastDays { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Appointment> AppointmentCollection { get; set; }

        public AppointmentSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }

    public class ScheduleSearchModel
    {
        public int? Chamber { get; set; }
        public int? Day { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Schedule> ScheduleCollection { get; set; }
        public IEnumerable<Chamber> ChamberCollection { get; set; }

        public ScheduleSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }

    public class VacationSearchModel
    {
        public int? Chamber { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Vacation> VacationCollection { get; set; }
        public IEnumerable<Chamber> ChamberCollection { get; set; }

        public VacationSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}