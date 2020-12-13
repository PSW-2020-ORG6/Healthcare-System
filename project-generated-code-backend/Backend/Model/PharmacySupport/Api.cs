using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.PharmacySupport
{
    public class Api : Entity
    {
        public string Key { get; set; }
        public string PharmacyName { get; set; }
        public string Url { get; set; }

        public bool Subscribed { get; set; }

        public Api()
        {
        }

        public Api(string key, string pharmacyName, string url)
        {
            Key = key;
            PharmacyName = pharmacyName;
            Url = url;
        }
    }
}