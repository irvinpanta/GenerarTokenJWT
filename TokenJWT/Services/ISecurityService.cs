using System.Threading.Tasks;
using TokenJWT.Entity;
using TokenJWT.Security;

namespace TokenJWT.Services
{
    public interface ISecurityService
    {
        Task<Empleado> GetUserCredentials(UserLogin login);
    }
}
