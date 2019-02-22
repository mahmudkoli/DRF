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
        public int AppointmentStatus { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Appointment> AppointmentCollection { get; set; }

        public AppointmentSearchModel()
        {
            Page = 1;
            PageSize = 5;
        }
    }
}