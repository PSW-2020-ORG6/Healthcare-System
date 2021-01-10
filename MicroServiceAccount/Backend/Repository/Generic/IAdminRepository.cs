

using MicroServiceAccount.Backend.Model;

namespace MicroServiceAccount.Backend.Repository.Generic
{
    public interface IAdminRepository : IGenericMsAccountRepository<Admin>
    {
        //5555555555555555555555555555555555555555
        Admin GetAdminByUserNameAndPassword(string email, string password);
    }
}
