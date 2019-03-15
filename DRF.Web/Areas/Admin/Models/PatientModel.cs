using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class PatientModel
    {
        private PatientService _patientService;

        public PatientModel()
        {
            _patientService = new PatientService();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientService.GetAll();
        }
    }
}