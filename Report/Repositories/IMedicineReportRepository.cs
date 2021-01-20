﻿using Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Repositories
{
    public interface IMedicineReportRepository
    {
        public List<MedicineReport> GetAll();
        void AddPrescription();
    }
}
