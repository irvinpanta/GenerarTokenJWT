using System.Threading.Tasks;
using TokenJWT.Entity;
using TokenJWT.Security;

namespace TokenJWT.Repository
{
    public interface ISecurityRepository
    {
        Task<Empleado> GetUserCredentials(UserLogin login);
    }
}
