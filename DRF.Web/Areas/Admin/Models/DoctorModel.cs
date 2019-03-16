﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class DoctorModel
    {
        private DoctorService _doctorService;

        public DoctorModel()
        {
            _doctorService = new DoctorService();
        }

        public IEnumerable<Entities.Doctor> GetAll()
        {
            return _doctorService.GetAll();
        }

        public IEnumerable<Entities.Doctor> GetAll(string name, byte? status)
        {
            return _doctorService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _doctorService.ChangeStatus(id);
        }
    }
}