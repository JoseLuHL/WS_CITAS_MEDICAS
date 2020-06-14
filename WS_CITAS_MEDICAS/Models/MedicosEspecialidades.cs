using System;
using System.Collections.Generic;

namespace WS_CITAS_MEDICAS.Models
{
    public partial class MedicosEspecialidades
    {
        public int Id { get; set; }
        public int Medicoid { get; set; }
        public int Especialidadid { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public DateTime? Fechamodificacion { get; set; }
        public string Usuarioregistro { get; set; }
        public string Usuariomodificacion { get; set; }
        public bool? Activo { get; set; }

        public virtual Especialidades Especialidad { get; set; }
        public virtual Medicos Medico { get; set; }
    }
}
