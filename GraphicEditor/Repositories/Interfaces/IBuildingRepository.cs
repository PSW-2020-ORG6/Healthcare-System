using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        List<Building> GetBuildings(String sqlDml);
        List<Building> GetAllBuildings();
    }
}
