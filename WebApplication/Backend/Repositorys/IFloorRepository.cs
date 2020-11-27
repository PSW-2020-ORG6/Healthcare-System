using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IFloorRepository
    {
        List<Floor> GetFloors(String sqlDml);
        List<Floor> GetAllFloors();
    }
}
