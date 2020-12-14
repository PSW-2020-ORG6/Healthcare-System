using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class BedController
    {
        public BedService bedService;

        public BedController()
        {
            bedService = new BedService();
        }

        public Bed GetById(string id)
        {
            return bedService.GetById(id);
        }

        public List<Bed> GetByName(string name)
        {
            return bedService.GetByName(name);
        }

        public List<Bed> GetAll()
        {
            return bedService.GetAll();
        }

        public void EditBed(Bed bed)
        {
            bedService.EditBed(bed);
        }

        public void NewBed(Bed bed)
        {
            bedService.NewBed(bed);
        }

        public void DeleteBed(Bed bed)
        {
            bedService.DeleteBed(bed);
        }
    }
}
