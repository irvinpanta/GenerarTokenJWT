using System.Collections.Generic;

namespace TokenJWT.Entity
{
    public class Rol : BaseEntity
    {
        public Rol()
        {
            Empleados = new HashSet<Empleado>();
        }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
