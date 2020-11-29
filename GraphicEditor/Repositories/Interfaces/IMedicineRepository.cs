using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Repositories.Interfaces
{
    interface IMedicineRepository
    {
        List<MedicineGEA> GetAllMedicines();
        List<MedicineGEA> GetMedicinesByName(string name);

    }
}
