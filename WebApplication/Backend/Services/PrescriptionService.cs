using Model.MedicalExam;
using System;
using System.Collections.Generic;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    public class PrescriptionService
    {
        private IPrescriptionRepository iPrescriptionRepository;
        public PrescriptionService()
        {
            this.iPrescriptionRepository = new PrescriptionRepository();
        }

        public PrescriptionService(IPrescriptionRepository iPrescriptionRepository)
        {
            this.iPrescriptionRepository = iPrescriptionRepository;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get prescriptions by search
        ///</summary>
        ///<param name="searchedPersription"> search
        ///<param name="dateTimes"> search by date times
        ///</param>
        ///<returns>
        ///list of prescription DTO objects
        ///</returns>
        public List<SearchEntityDTO> GetSearchedPrescription(string searchedPersription, string dateTimes)
        {
            try
            {
                string[] search = searchedPersription.Split(";");
                string[] s = search[0].Split(",");
                List<Prescription> firstSearchedList = iPrescriptionRepository.GetPrescriptionsByProperty(Propeerty(search[0].Split(",")[2]), search[0].Split(",")[1], dateTimes, false);

                for (int i = 1; i < search.Length; i++)
                {
                    if (search[i].Split(",")[0].Equals("AND"))
                        firstSearchedList = OperationAND(firstSearchedList, iPrescriptionRepository.GetPrescriptionsByProperty(Propeerty(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else if (search[i].Split(",")[0].Equals("OR"))
                        firstSearchedList = OperationOR(firstSearchedList, iPrescriptionRepository.GetPrescriptionsByProperty(Propeerty(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else
                        firstSearchedList = OperationAND(firstSearchedList, iPrescriptionRepository.GetPrescriptionsByProperty(Propeerty(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, true));
                }
                return ConverToDTO(firstSearchedList);
            }
            catch (Exception e)
            {
                return ConverToDTO(iPrescriptionRepository.GetPrescriptionsByProperty(Propeerty(searchedPersription.Split(",")[2]), searchedPersription.Split(",")[1], dateTimes, false));
            }
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

        ///Tanja Drcelic RA124/2017 and Marija Vucetic RA157/2017
        /// <summary>
        ///Get searched prescriptions by AND operation
        ///</summary>
        ///<param name="firstSearchedList"> first list for operation
        ///<param name="secondSearchedList"> second list for operation
        ///</param>
        ///<returns>
        ///list of prescriptions
        ///</returns>
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
            {
                if (pReturnList.SerialNumber.Equals(serialNumber))
                    return false;
            }
            return true;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get searched prescriptions by OR operation
        ///</summary>
        ///<param name="firstSearchedList"> first list for operation
        ///<param name="secondSearchedList"> second list for operation
        ///</param>
        ///<returns>
        ///list of prescriptions
        ///</returns>
        private List<Prescription> OperationOR(List<Prescription> firstSearchedList, List<Prescription> secondSearchedList)
        {
            List<Prescription> returnList = firstSearchedList;

            foreach (Prescription psecond in secondSearchedList)
            {
                if (NotInResult(returnList, psecond.SerialNumber))
                    returnList.Add(psecond);
            }
            return returnList;
        }

        private List<SearchEntityDTO> ConverToDTO(List<Prescription> prescriptions)
        {
            if (prescriptions == null || prescriptions.Count == 0)
                return null;
            List<SearchEntityDTO> searchEntityDTOs = new List<SearchEntityDTO>();
            foreach (Prescription prescription in prescriptions)
            {
                string text = "";
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    text += "Medicine: " + medicineDosage.Medicine.GenericName + " - " + medicineDosage.Medicine.MedicineType.Type + " - " + medicineDosage.Amount + " - " + medicineDosage.Note + ";\n";
                searchEntityDTOs.Add(new SearchEntityDTO("Prescriprion", text, prescription.Date.ToString("dddd, MMMM dd yyyy")));
            }
            return searchEntityDTOs;
        }
    }
}
