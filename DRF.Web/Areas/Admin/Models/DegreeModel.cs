using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class DegreeModel
    {
        private DegreeService _degreeService;

        public DegreeModel()
        {
            _degreeService = new DegreeService();
        }

        public IEnumerable<Degree> GetAll()
        {
            return _degreeService.GetAll();
        }
        public IEnumerable<Degree> GetAll(string name, byte? status)
        {
            return _degreeService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _degreeService.ChangeStatus(id);
        }

        public bool AddOrUpdate(int newDegreeId, string newDegreeName, string newDegreeDetails)
        {
            var degree = new Degree()
            {
                Id = newDegreeId,
                Name = newDegreeName,
                Details = newDegreeDetails
            };

            return _degreeService.AddOrUpdate(degree);
        }
    }
}