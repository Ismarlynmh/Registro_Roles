using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Roles.Entidades
{
    public class aPermiso
    {
        [Key]
        public int RolId { get; set; }
        public string Descripción { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("RolId")]
        public virtual List<aPermisosDetalle> aPermisosDetalle { get; set; } = new List<aPermisosDetalle>();
    }
}
