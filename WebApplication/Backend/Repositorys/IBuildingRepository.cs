using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IBuildingRepository
    {
        List<Building> GetBuildings(String sqlDml);
        List<Building> GetAllBuildings();
        List<Building> GetBuildingsByName(string name);
    }
}
