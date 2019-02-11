﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class ChamberService
    {
        private ChamberUnitOfWork _chamberUnitOfWork;

        public ChamberService()
        {
            _chamberUnitOfWork = new ChamberUnitOfWork(new DRFDbContext());
        }
    }
}