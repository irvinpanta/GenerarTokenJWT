using System.Threading.Tasks;
using TokenJWT.Entity;
using TokenJWT.Repository;
using TokenJWT.Security;

namespace TokenJWT.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<Empleado> GetUserCredentials(UserLogin login)
        {
            var response = await _securityRepository.GetUserCredentials(login);
            return response;
        }
    }
}
