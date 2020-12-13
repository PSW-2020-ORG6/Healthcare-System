// File:    BedReservationDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class BedReservationDTO

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Dto
{
    public abstract class BedReservationDto
    {
        public Bed Bed { get; set; }
        public Patient Patient { get; set; }
        public TimeInterval TimeInterval { get; set; }
    }
}