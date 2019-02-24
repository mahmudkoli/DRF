using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Services;
using DRF.Web.Models;
using PagedList;

namespace DRF.Web.Controllers
{
    public class HomeController : Controller
    {
        private DoctorSearchModel _doctorSearchModel;
        private DoctorService _doctorService;

        public HomeController()
        {
            _doctorSearchModel = new DoctorSearchModel();
            _doctorService = new DoctorService();
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Search(DoctorSearchModel model)
        {
            model = model ?? new DoctorSearchModel();
            var doctors = _doctorService.GetAllDoctors(model.AreaName, model.SpecialtyName, model.DoctorName).ToList();
            model.DoctorCollection = doctors.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        public ActionResult DoctorDetailsInfo(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var doctor = _doctorService.GetById(id.Value);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}