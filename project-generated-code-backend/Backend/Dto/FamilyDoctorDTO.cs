using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Dto
{
    public class FamilyDoctorDTO
    {
        private string name;
        private string surname;
        private string specialization;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Specialization { get => specialization; set => specialization = value; }
    }
}
