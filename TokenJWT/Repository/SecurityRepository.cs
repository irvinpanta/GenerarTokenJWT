using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenJWT.Entity;
using TokenJWT.Security;

namespace TokenJWT.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly DataContext _context;
        public SecurityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Empleado> GetUserCredentials(UserLogin login)
        {
            var sql = from empleado in _context.Empleados
                      join roles in _context.Roles on empleado.Rol equals roles.Id
                      select new Empleado
                      {
                          Id = empleado.Id,
                          Documento = empleado.Documento,
                          Nombres = empleado.Nombres,
                          Apellidos = empleado.Apellidos,
                          Roles = new Rol
                          {
                              Descripcion = roles.Descripcion,
                          }
                      };

            var response = await sql.FirstOrDefaultAsync(x =>
                                    x.Documento == login.User);
            return response;
        }
    }
}
