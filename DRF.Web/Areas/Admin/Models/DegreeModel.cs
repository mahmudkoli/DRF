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
    }
}