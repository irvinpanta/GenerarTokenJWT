using System;

namespace TokenJWT.Entity
{
    public class Empleado : BaseEntity
    {
        public Empleado()
        {}

        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public byte? Activo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public int? Rol { get; set; }
        public DateTime? FecSistema { get; set; }

        public virtual Rol Roles { get; set; }
    }
}
