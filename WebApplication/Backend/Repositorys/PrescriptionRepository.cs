using Model.Hospital;
using Model.MedicalExam;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class PrescriptionRepository
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
        internal List<Prescription> GetAll()
        {
            return GetPrescriptions("Select * from prescriptions");
        }
        internal List<Prescription> GetPrescriptions(String sqlDml)
        {
            //sqlDml = "Select * from prescriptions where notes like 'Two per day-10 days'";
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Prescription> resultList = new List<Prescription>();
            while (sqlReader.Read())
            {
                Prescription entity = new Prescription();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Date = (DateTime)sqlReader[1];
                entity.Notes = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            foreach (Prescription prescription in resultList)
            {
                prescription.MedicineDosage = GetMedicineDosage("Select * from medicinedosages where PrescriptionSerialNumber like '" + prescription.SerialNumber + "'");
            }
            return resultList;
        }

        private List<MedicineDosage> GetMedicineDosage(String sqlDml)
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
                entity.Note = (string)sqlReader[3];
                entity.Medicine = new Medicine();
                entity.Medicine.SerialNumber = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            foreach (MedicineDosage medicineDosage in resultList)
            {
                medicineDosage.Medicine = GetMedicine("Select * from medicines where SerialNumber like '" + medicineDosage.Medicine.SerialNumber + "'");
            }
            return resultList;
        }
        private Medicine GetMedicine(String sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();

            Medicine entity = new Medicine();
            while (sqlReader.Read())
            {
                entity.SerialNumber = (string)sqlReader[0];
                entity.CopyrightName = (string)sqlReader[1];
                entity.GenericName = (string)sqlReader[2];
                entity.MedicineType = new MedicineType();
                entity.MedicineType.SerialNumber = (string)sqlReader[4];
            }
            connection.Close();
            entity.MedicineType.Type = GetMedicineType("Select type from medicinetypes where SerialNumber like '" + entity.MedicineType.SerialNumber + "'");

            return entity;
        }
        private string GetMedicineType(string sqlDml)
        {

            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            string type = (string)sqlReader[0];
            connection.Close();
            return type;

        }
        public List<Prescription> GetPrescriptionsByProperty(string property, string value,bool not)
        {
            List<Prescription> prescriptions = GetPrescriptions("Select prescriptions.SerialNumber,prescriptions.Date,prescriptions.Notes,medicinedosages.SerialNumber from prescriptions,medicinedosages,medicines,medicinetypes where medicines.MedicineTypeSerialNumber=medicinetypes.SerialNumber and medicinedosages.PrescriptionSerialNumber=prescriptions.SerialNumber and medicinedosages.MedicineSerialNumber=medicines.SerialNumber");
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (property.Equals("All"))
                    {
                        if (!not)
                        {
                            if (medicineDosage.Medicine.GenericName.Equals(value) || medicineDosage.Medicine.MedicineType.Type.Equals(value))
                                resultList.Add(prescription);
                        }
                        else
                        {
                            if (!medicineDosage.Medicine.GenericName.Equals(value) || !medicineDosage.Medicine.MedicineType.Type.Equals(value))
                                resultList.Add(prescription);
                        }
                    }
                    else if (property.Equals("Medicine name")) {
                        if (!not && medicineDosage.Medicine.GenericName.Equals(value))
                            resultList.Add(prescription);
                        else if (not && !medicineDosage.Medicine.GenericName.Equals(value))
                            resultList.Add(prescription);
                    }
                    else {
                        if (!not && medicineDosage.Medicine.MedicineType.Type.Equals(value))
                            resultList.Add(prescription);
                        else if(not && !medicineDosage.Medicine.MedicineType.Type.Equals(value))
                            resultList.Add(prescription);
                    }
                }
            }
            return resultList;
        }
    }
}
