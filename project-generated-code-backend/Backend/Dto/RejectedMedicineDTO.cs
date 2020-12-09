// File:    RejectedMedicineDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RejectedMedicineDTO

using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Dto
{
    public class RejectedMedicineDto
    {
        public string Reason { get; set; }
        public Medicine Medicine { get; set; }
    }
}