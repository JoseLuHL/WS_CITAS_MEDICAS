using System;
using System.Collections.Generic;

namespace WS_CITAS_MEDICAS.Models
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            MedicosEspecialidades = new HashSet<MedicosEspecialidades>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public DateTime? Fechamodificacion { get; set; }
        public string Usuarioregistro { get; set; }
        public string Usuariomodificacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<MedicosEspecialidades> MedicosEspecialidades { get; set; }
    }
}
