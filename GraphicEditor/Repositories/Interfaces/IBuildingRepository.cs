using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        List<Building> GetBuildings(String sqlDml);
        List<Building> GetAllBuildings();
        Building GetBuildingById(String sqlDml);
        Building GetBuildingByName(String sqlDml);
        Building GetBuildingByColor(String sqlDml);
        Building GetBuildingByShape(String sqlDml);
    }
}
