using health_clinic_class_diagram.Backend.Model.Util;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;

namespace HealthClinicBackend.Backend.Controller
{
    public class HospitalLogInController
    {
        private readonly HospitalLogInService _hospitalLogInService;

        public HospitalLogInController()
        {
            _hospitalLogInService = new HospitalLogInService();
        }

        public TypeOfUser GetUserType(string jmbg, string password)
        {
            return _hospitalLogInService.GetUserType(jmbg, password);
        }
    }
}
