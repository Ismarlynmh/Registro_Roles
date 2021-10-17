using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Roles.Entidades
{
    public class aPermisosDetalle
    {
        [Key]
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public virtual rPermiso Permiso { get; set; }

    }
}
