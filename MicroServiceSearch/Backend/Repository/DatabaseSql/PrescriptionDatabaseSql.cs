using System;
using System.Collections.Generic;
using System.Linq;
using MicroServiceSearch.Backend.Model;
using MicroServiceSearch.Backend.Repository.Generic;
using MicroServiceSearch.Backend.Util;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class PrescriptionDatabaseSql : GenericMsSearchDatabaseSql<Prescription>, IPrescriptionRepository
    {
        public PrescriptionDatabaseSql()
        {
        }

        public PrescriptionDatabaseSql(MsSearchDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Prescription> GetAll()
        {
            return DbContext.Prescription
                .Include(p => p.MedicineDosage)
                .ToList();
        }

        public override Prescription GetById(string id)
        {
            return GetAll().Where(p=>p.SerialNumber.Equals(id)).ToList()[0];
        }
        public List<Prescription> GetPrescriptionsBetweenDates(DateTime[] datetimes)
        {
          return GetAll()
                .Where(t => t.Date > datetimes[0] && t.Date < datetimes[1])
                .ToList();
        }


        public List<Prescription> GetPrescriptionsBetweenDatesByMedicineName(DateTime[] dateTimes, string medicineName)
        {
            var prescriptions = GetPrescriptionsBetweenDates(dateTimes);
            var retVal =new  List<Prescription>();
            foreach (var prescription in prescriptions)
                foreach (var medicineDosage in prescription.MedicineDosage)
                {
                    var medicine = HttpRequest.GetMedicineByIdAsync(medicineDosage.MedicineSerialNumber).Result;
                    if (medicine.Name.ToUpper().Contains(medicineName.ToUpper()))
                    {
                        retVal.Add(prescription);
                        break;
                    }
                }
            return retVal;
        }

        public List<Prescription> GetPrescriptionsBetweenDatesByMedicineType(DateTime[] dateTimes, string medicineType)
        {
            var prescriptions = GetPrescriptionsBetweenDates(dateTimes);
            var retVal = new List<Prescription>();
            foreach (var prescription in prescriptions)
                foreach (var medicineDosage in prescription.MedicineDosage)
                {
                    var medicine = HttpRequest.GetMedicineByIdAsync(medicineDosage.MedicineSerialNumber).Result;
                    if (medicine.MedicineType.ToUpper().Contains(medicineType.ToUpper()))
                    {
                        retVal.Add(prescription);
                        break;
                    }
                }
            return retVal;
        }


        public List<Prescription> GetPrescriptionsBetweenDatesByMedicineTypeNegation(DateTime[] dateTimes, string medicineType)
        {
            var prescriptions = GetPrescriptionsBetweenDates(dateTimes);
            var retVal = new List<Prescription>();
            var find = false;
            foreach (var prescription in prescriptions)
            {
                foreach (var medicineDosage in prescription.MedicineDosage)
                {
                    var medicine = HttpRequest.GetMedicineByIdAsync(medicineDosage.MedicineSerialNumber).Result;
                    if (medicine.MedicineType.ToUpper().Contains(medicineType.ToUpper()))
                    {
                        find = true;
                        break;
                    }
                }
                if(find)retVal.Add(prescription);
                find = true;
            }
                return retVal;
        }
        public List<Prescription> GetPrescriptionsBetweenDatesByMedicineNameNegation(DateTime[] dateTimes, string medicineName)
        {
            var prescriptions = GetPrescriptionsBetweenDates(dateTimes);
            var retVal = new List<Prescription>();
            var find = false;
            foreach (var prescription in prescriptions)
            {
                foreach (var medicineDosage in prescription.MedicineDosage)
                {
                    var medicine = HttpRequest.GetMedicineByIdAsync(medicineDosage.MedicineSerialNumber).Result;
                    if (medicine.Name.ToUpper().Contains(medicineName.ToUpper()))
                    {
                        find = true;
                        break;
                    }
                }
                if (find) retVal.Add(prescription);
                find = true;
            }
            return retVal;
        }
        public List<Prescription> GetPrescriptionsBetweenDatesByAll(DateTime[] dateTimes, string value)
        {
            var prescriptions = GetPrescriptionsBetweenDates(dateTimes);
            var retVal = new List<Prescription>();
            foreach (var prescription in prescriptions)
                foreach (var medicineDosage in prescription.MedicineDosage)
                {
                    var medicine = HttpRequest.GetMedicineByIdAsync(medicineDosage.MedicineSerialNumber).Result;
                    if (medicine.MedicineType.ToUpper().Contains(value.ToUpper()) || medicine.Name.ToUpper().Contains(value.ToUpper()))
                    {
                        retVal.Add(prescription);
                        break;
                    }
                }
            return retVal;
        }
        public List<Prescription> GetPrescriptionsBetweenDatesByAllNegation(DateTime[] dateTimes, string value)
        {
            var prescriptions = GetPrescriptionsBetweenDates(dateTimes);
            var retVal = new List<Prescription>();
            var find = false;
            foreach (var prescription in prescriptions)
            {
                foreach (var medicineDosage in prescription.MedicineDosage)
                    if (medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()) || medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                    {
                        find = true;
                        break;
                    }
                if (find) retVal.Add(prescription);
                find = true;
            }
            return retVal;
        }
    }
}