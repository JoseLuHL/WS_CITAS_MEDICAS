using System;
using System.Collections.Generic;

namespace WS_CITAS_MEDICAS.Models
{
    public partial class Horarios
    {
        public int Id { get; set; }
        public int Medicoid { get; set; }
        public DateTime Fechaatencion { get; set; }
        public TimeSpan Inicioatencion { get; set; }
        public TimeSpan Finatencion { get; set; }
        public bool? Activo { get; set; }
        public DateTime Fecharegistro { get; set; }
        public string Usuarioregistro { get; set; }
        public DateTime? Fechamodificacion { get; set; }
        public string Usuariomodificacion { get; set; }

        public virtual Medicos Medico { get; set; }
    }
}
