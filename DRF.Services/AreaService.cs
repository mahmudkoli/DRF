using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class AreaService
    {
        private AreaUnitOfWork _areaUnitOfWork;

        public AreaService()
        {
            _areaUnitOfWork = new AreaUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Area> GetAll()
        {
            return _areaUnitOfWork.AreaRepository.GetAll();
        }

        public IEnumerable<string> GetAllAreaName(string term)
        {
            return _areaUnitOfWork.AreaRepository.Get(x => x.Name.ToLower().Contains(term.ToLower()))
                .Select(y => y.Name);
        }
    }
}
