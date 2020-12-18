using HealthClinicBackend.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This class does connection with MySQL database patient and address tables
    /// </summary>
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly PatientDatabaseSql _patientRepository;
        private readonly PhysicianDatabaseSql _physicianRepository;

        public RegistrationRepository()
        {
            _patientRepository = new PatientDatabaseSql();
            _physicianRepository = new PhysicianDatabaseSql();
        }

        ////Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Adds new row into patient table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<param name="patient"> Patient type object
        ///</param>
        public bool AddPatient(Patient patient)
        {
            _patientRepository.Save(patient);
            return true;
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get id from feedbacks table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///id if exists,else false
        ///</returns>
        public String GetPatientId(string sqlDml)
        {
            //TODO: delete this please
            return "";
            // connection.Open();
            // MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            // MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            // string id = "";
            // while (sqlReader.Read())
            // {
            //     id = (string) sqlReader[0];
            // }
            //
            // connection.Close();
            // return id;
        }

        public bool IsPatientIdValid(string patientId)
        {
            return true;
            // return _patientRepository.IsPatientIdValid(patientId);
        }

        ////Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Update row into patient table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<param name="patientId"> String type object
        ///</param>
        public bool ConfirmEmailUpdate(string patientId)
        {
            // This is business logic that should be executed in service layer
            // Repository should only be called to update data
            var patient = _patientRepository.GetByJmbg(patientId);
            patient.EmailConfirmed = true;
            _patientRepository.Update(patient);
            return true;
        }

        public List<FamilyDoctorDto> GetAllGeneralPracticePhysicians()
        {
            // TODO: use real physician object! services and especially repositories do not care about the appearance of your web app
            return _physicianRepository.GetGeneralPractitioners()
                .Select(gp => new FamilyDoctorDto
                    {Name = gp.Name, Surname = gp.Surname, Specialization = gp.Specialization[0].Name})
                .ToList();
        }
    }
}