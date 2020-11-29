using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class MedicineReportService
    {
        private MedicineReportRepository medicineReportRepository;

        public MedicineReportService()
        {
            this.medicineReportRepository = new MedicineReportRepository();
        }

        public void AddPrescription()
        {
            medicineReportRepository.AddPrescription();
        }

        public List<MedicineReport> GetAll()
        {
            return medicineReportRepository.GetAll();
        }

        public List<MedicineReport> GetByDateInterval(TimeInterval timeInterval)
        {
            List<MedicineReport> result = new List<MedicineReport>();

            foreach(MedicineReport m in GetAll())
            {
                if(m.date >= timeInterval.Start && m.date <= timeInterval.End)
                {
                    result.Add(m);
                }
            }
            return result;
        }
    }
}
