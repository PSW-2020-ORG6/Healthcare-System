using MedicineUsage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineUsage.Services
{
    public interface ISftpService
    {
        public void GenerateFile(List<MedicineReport> medicineReports, string fileName);
        public bool SendFile(string fileName);
        public bool DownloadFile(string fileName);
    }
}
