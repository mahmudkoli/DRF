using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace DRF.Web.Areas.Admin.Models
{
    public class DoctorSearchModel
    {
        public string AreaName { get; set; }
        public string SpecialtyName { get; set; }
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.Doctor> DoctorCollection { get; set; }

        public DoctorSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
    public class PatientSearchModel
    {
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.Patient> PatientCollection { get; set; }

        public PatientSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
    public class ChamberSearchModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.Chamber> ChamberCollection { get; set; }

        public ChamberSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
    public class AreaSearchModel
    {
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.Area> AreaCollection { get; set; }

        public AreaSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
    public class CitySearchModel
    {
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.City> CityCollection { get; set; }

        public CitySearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
    public class DegreeSearchModel
    {
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.Degree> DegreeCollection { get; set; }

        public DegreeSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
    public class SpecialtySearchModel
    {
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IPagedList<Entities.Specialty> SpecialtyCollection { get; set; }

        public SpecialtySearchModel()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}