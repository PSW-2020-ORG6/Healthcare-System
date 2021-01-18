﻿using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class ProcedureTypeDTO
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public ProcedureTypeDTO() { }
        public ProcedureTypeDTO(ProcedureType procedureType)
        {
            Specialization = HttpRequest.GetSpecializationByIdAsync(procedureType.SpecializationSerialNumber).Result.Name;
            Name = procedureType.Name;
        }
    }
}
