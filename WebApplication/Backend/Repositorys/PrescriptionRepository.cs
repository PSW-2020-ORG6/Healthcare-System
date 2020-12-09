using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace WebApplication.Backend.Repositorys
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly PrescriptionDatabaseSql _prescriptionRepository;

        public PrescriptionRepository()
        {
            _prescriptionRepository = new PrescriptionDatabaseSql();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Create sqlDml for get prescriptions
        ///</summary>
        ///<param name="property"> search by property
        ///<param name="value"> search value
        ///<param name="dateTimes"> search by date times
        ///<param name="not"> search for negation
        ///</param>
        ///<returns>
        ///list of prescriptions
        ///</returns>
        public List<Prescription> GetPrescriptionsByProperty(SearchProperty property, string value, string dateTimes,
            bool not)
        {
            // TODO: parse dates:
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MaxValue;

            var prescriptions = _prescriptionRepository.GetAll()
                .Where(p => p.Date <= end)
                .Where(p => p.Date >= start)
                .ToList();

            if (!not && property.Equals(SearchProperty.All))
                return GetPrescriptionsByAllProperties(value, prescriptions);
            if (not && property.Equals(SearchProperty.All))
                return GetPrescriptionsByAllPropertiesNegation(value, prescriptions);
            if (!not && property.Equals(SearchProperty.MedicineName))
                return GetPrescriptionsByMedicineName(value, prescriptions);
            if (not && property.Equals(SearchProperty.MedicineName))
                return GetPrescriptionsByMedicineNameNegation(value, prescriptions);
            if (!not && property.Equals(SearchProperty.MedicineType))
                return GetPrescriptionsByMedicineType(value, prescriptions);
            return GetPrescriptionsByMedicineTypeNegation(value, prescriptions);
        }

        private List<Prescription> GetPrescriptionsByAllPropertiesNegation(string value,
            List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (!medicineDosage.Medicine.GenericName.Contains(value.ToUpper()) &&
                        !medicineDosage.Medicine.MedicineType.Type.Contains(value.ToUpper()))
                        resultList.Add(prescription);
                }
            }

            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineNameNegation(string value,
            List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (!medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(prescription);
                }
            }

            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineTypeNegation(string value,
            List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (!medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(prescription);
                }
            }

            return resultList;
        }

        private List<Prescription> GetPrescriptionsByAllProperties(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()) ||
                        medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(prescription);
                }
            }

            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineName(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(prescription);
                }
            }

            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineType(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(prescription);
                }
            }

            return resultList;
        }
    }
}