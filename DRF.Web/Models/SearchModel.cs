using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using PagedList;

namespace DRF.Web.Models
{
    public class DoctorSearchModel
    {
        public string AreaName { get; set; }
        public string SpecialtyName { get; set; }
        public string DoctorName { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Doctor> DoctorCollection { get; set; }

        public DoctorSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}