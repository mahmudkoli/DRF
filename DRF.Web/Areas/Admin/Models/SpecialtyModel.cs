using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class SpecialtyModel
    {
        private SpecialtyService _specialtyService;

        public SpecialtyModel()
        {
            _specialtyService = new SpecialtyService();
        }

        public IEnumerable<Specialty> GetAll()
        {
            return _specialtyService.GetAll();
        }

        public IEnumerable<Specialty> GetAll(string name, byte? status)
        {
            return _specialtyService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _specialtyService.ChangeStatus(id);
        }

        public bool AddOrUpdate(int newSpecialtyId, string newSpecialtyName, string newSpecialtyDisease, string newSpecialtyDetails)
        {
            var specialty = new Specialty()
            {
                Id = newSpecialtyId,
                Name = newSpecialtyName,
                Disease = newSpecialtyDisease,
                Details = newSpecialtyDetails
            };

            return _specialtyService.AddOrUpdate(specialty);
        }
    }
}