using Model.Hospital;
using Model.MedicalExam;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class PrescriptionRepository: IPrescriptionRepository
    {
        private MySqlConnection connection;
        public PrescriptionRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=Tanjaa;password=TanjaaD");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }

        public List<Prescription> GetPrescriptions(string sqlDml)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Prescription> prescriptions = new List<Prescription>();
            while (sqlReader.Read())
            {
                Prescription entity = new Prescription();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Date = (DateTime)sqlReader[1];
                entity.Notes = (string)sqlReader[2];
                prescriptions.Add(entity);
            }
            connection.Close();
            foreach (Prescription prescription in prescriptions)
            {
                prescription.MedicineDosage = GetMedicineDosage("Select medicinedosages.SerialNumber,medicinedosages.Note,medicinedosages.Amount,medicines.SerialNumber,medicines.GenericName,medicines.CopyrightName,medicinetypes.SerialNumber,medicinetypes.Type  from medicinedosages,medicines,medicinetypes where medicinedosages.PrescriptionSerialNumber like '" + prescription.SerialNumber + "' and medicinedosages.MedicineSerialNumber like medicines.SerialNumber and medicines.MedicineTypeSerialNumber like medicinetypes.SerialNumber");
            }
            return prescriptions;
        }


        public List<MedicineDosage> GetMedicineDosage(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<MedicineDosage> resultList = new List<MedicineDosage>();
            while (sqlReader.Read())
            {
                MedicineDosage entity = new MedicineDosage();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Amount = (double)sqlReader[2];
                entity.Note = (string)sqlReader[1];
                entity.Medicine = new Medicine {SerialNumber= (string)sqlReader[3],GenericName= (string)sqlReader[4],CopyrightName= (string)sqlReader[5],MedicineType=new MedicineType {SerialNumber= (string)sqlReader[6],Type= (string)sqlReader[7] } };
                entity.Medicine.SerialNumber = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }
        public List<Prescription> GetPrescriptionsByProperty(string property, string value, string dateTimes)
        {
            List<Prescription> prescriptions = GetPrescriptions("Select * from prescriptions where Date between "+dateTimes);
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (property.Equals("All"))
                    {
                        if (medicineDosage.Medicine.GenericName.Contains(value.ToUpper()) || medicineDosage.Medicine.MedicineType.Type.Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                    else if (property.Equals("Medicine name"))
                    {
                        if (medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                    else
                    {
                        if (medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                }
            }
            return resultList;
        }
    }
}
