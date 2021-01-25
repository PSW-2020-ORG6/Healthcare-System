using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Dto
{
    public class AddressDto
    {
        public string Id { get; set; }
        public string Street { get; set; }

        public AddressDto()
        {
        }
        public AddressDto(Address address)
        {
            Id = address.SerialNumber;
            Street = address.Street;
        }
    }
}
