using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using MicroServiceSearch.Backend.DTO;

namespace MicroServiceSearch.Backend.Services
{
    public class PrescriptionService
    {
        private IPrescriptionRepository _prescriptionRepository=new PrescriptionDatabaseSql();
        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            this._prescriptionRepository = prescriptionRepository;
        }

        public PrescriptionService()
        {
        }

        /// <summary>
        ///Get prescriptions by search
        ///</summary>
        ///<param name="searchedPersription"> search
        ///<param name="dateTimes"> search by date times
        ///</param>
        ///<returns>
        ///list of prescription DTO objects
        ///</returns>
        public List<SearchEntityDTO> GetSearchedPrescription(string searchedPersription, DateTime[] dateTimes)
        {
            try
            {
                string[] search = searchedPersription.Split(";");
                string[] s = search[0].Split(",");
                List<Prescription> firstSearchedList = GetPrescriptionsByProperty(Propeerty(search[0].Split(",")[2]), search[0].Split(",")[1], dateTimes, false);

                for (int i = 1; i < search.Length; i++)
                {
                    if (search[i].Split(",")[0].Equals("AND"))
                        firstSearchedList = OperationAND(firstSearchedList, GetPrescriptionsByProperty(Propeerty(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else if (search[i].Split(",")[0].Equals("OR"))
                        firstSearchedList = OperationOR(firstSearchedList, GetPrescriptionsByProperty(Propeerty(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else
                        firstSearchedList = OperationAND(firstSearchedList, GetPrescriptionsByProperty(Propeerty(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, true));
                }
                return searchEntityDTO.ConverPrescriptionToDTO(firstSearchedList);
            }
            catch (Exception e)
            {
                return searchEntityDTO.ConverPrescriptionToDTO(GetPrescriptionsByProperty(Propeerty(searchedPersription.Split(",")[2]), searchedPersription.Split(",")[1], dateTimes, false));
            }
        }

        private List<Prescription> GetPrescriptionsByProperty(SearchProperty property, string value, DateTime[] dateTimes, bool not)
        {
            List<Prescription> prescriptions = _prescriptionRepository.GetPrescriptionsBetweenDates(dateTimes);
            if (!not && property.Equals(SearchProperty.All))
                return GetPrescriptionsByAllProperties(value, prescriptions);
            else if (not && property.Equals(SearchProperty.All))
                return GetPrescriptionsByAllPropertiesNegation(value, prescriptions);
            else if (!not && property.Equals(SearchProperty.MedicineName))
                return GetPrescriptionsByMedicineName(value, prescriptions);
            else if (not && property.Equals(SearchProperty.MedicineName))
                return GetPrescriptionsByMedicineNameNegation(value, prescriptions);
            else if (!not && property.Equals(SearchProperty.MedicineType))
                return GetPrescriptionsByMedicineType(value, prescriptions);
            else
                return GetPrescriptionsByMedicineTypeNegation(value, prescriptions);
        }

        private SearchProperty Propeerty(string property)
        {
            if (property.Equals("All"))
                return SearchProperty.All;
            else if (property.Equals("Medicine name"))
                return SearchProperty.MedicineName;
            else
                return SearchProperty.MedicineType;
        }

        private List<Prescription> OperationAND(List<Prescription> firstSearchedList, List<Prescription> secondSearchedList)
        {
            List<Prescription> returnList = new List<Prescription>();
            foreach (Prescription pfirst in firstSearchedList)
            {
                foreach (Prescription psecond in secondSearchedList)
                {
                    if (pfirst.SerialNumber.Equals(psecond.SerialNumber))
                    {
                        if (NotInResult(returnList, pfirst.SerialNumber))
                        {
                            returnList.Add(pfirst);
                            break;
                        }
                    }
                }
            }
            return returnList;
        }

        private bool NotInResult(List<Prescription> returnList, string serialNumber)
        {
            foreach (Prescription pReturnList in returnList)
                if (pReturnList.SerialNumber.Equals(serialNumber))
                    return false;
            return true;
        }

        private List<Prescription> OperationOR(List<Prescription> firstSearchedList, List<Prescription> secondSearchedList)
        {
            List<Prescription> returnList = firstSearchedList;
            foreach (Prescription psecond in secondSearchedList)
                if (NotInResult(returnList, psecond.SerialNumber))
                    returnList.Add(psecond);
            return returnList;
        }

        private List<Prescription> GetPrescriptionsByAllProperties(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    if (medicineDosage.MedicineNameContains(value))
                    {
                        resultList.Add(prescription);
                        break;
                    }
            return resultList;
        }

        private List<Prescription> GetPrescriptionsByAllPropertiesNegation(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    if (!medicineDosage.MedicineNameContains(value) && !medicineDosage.MedicineTypeContains(value))
                        resultList.Add(prescription);
            return resultList;
        }


        private List<Prescription> GetPrescriptionsByMedicineName(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    if (medicineDosage.MedicineNameContains(value))
                        resultList.Add(prescription);
            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineNameNegation(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    if (!medicineDosage.MedicineNameContains(value))
                    {
                        resultList.Add(prescription);
                        break;
                    }
            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineType(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    if (medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                    {
                        resultList.Add(prescription);
                        break;
                    }
            return resultList;
        }

        private List<Prescription> GetPrescriptionsByMedicineTypeNegation(string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    if (!medicineDosage.MedicineTypeContains(value))
                    {
                        resultList.Add(prescription);
                        break;
                    }
            return resultList;
        }
    }
}