using Registro_Roles.DAL;
using Registro_Roles.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Roles.BLL
{
    public class aPermisosBLL
    {
        public static bool Guardar(aPermiso permiso)
        {
            if (!Existe(permiso.RolId))
                return Insertar(permiso);
            else
                return Modificar(permiso);
        }

        private static bool Existe(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.aPermiso.Any(x => x.RolId == RolId);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(aPermiso permiso)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.aPermiso.Add(permiso);//Agrega el registro.
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(aPermiso permiso)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM aPermisosDetalle WHERE RolId ={permiso.RolId}");
                foreach (var item in permiso.aPermisosDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(permiso).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static aPermiso Buscar(int RolId)
        {
            Contexto contexto = new Contexto();
            aPermiso permiso;
            try
            {
                permiso = contexto.aPermiso.Where(x => x.RolId == RolId)
                    .Include(y => y.aPermisosDetalle).ThenInclude(z => z.Permiso)
                    .SingleOrDefault();//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return permiso;
        }

        public static bool Eliminar(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(RolId);
                if (item != null)
                {
                    contexto.aPermiso.Remove(item);
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static List<aPermiso> GetList(Expression<Func<aPermiso, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<aPermiso> lista = new List<aPermiso>();

            try
            {
                lista = contexto.aPermiso.Where(criterio).Include(X => X.aPermisosDetalle).ThenInclude(z => z.Permiso).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }


    }
}