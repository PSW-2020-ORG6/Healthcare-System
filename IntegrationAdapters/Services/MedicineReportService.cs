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

        public List<MedicineReport> GetByDateInterval(List<MedicineReport> reports, TimeInterval timeInterval)
        {
            List<MedicineReport> result = new List<MedicineReport>();
            reports = GetAll();

            foreach(MedicineReport m in reports)
            {
                if(m.Date >= timeInterval.Start && m.Date <= timeInterval.End)
                {
                    result.Add(m);
                }
            }
            return result;
        }
    }
}
