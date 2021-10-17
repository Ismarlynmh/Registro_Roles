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
    public class rPermisosBLL
    {
        public static bool Guardar(rPermiso Permiso)
        {
            if (!Existe(Permiso.RolId))
                return Insertar(Permiso);
            else
                return Modificar(Permiso);
        }

        private static bool Existe(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.rPermiso.Any(x => x.RolId == RolId);
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

        private static bool Insertar(rPermiso Permiso)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.rPermiso.Add(Permiso);
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

        private static bool Modificar(rPermiso Permiso)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(Permiso).State = EntityState.Modified;
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

        public static rPermiso Buscar(int RolId)
        {
            Contexto contexto = new Contexto();
            rPermiso Permiso;
            try
            {
                Permiso = contexto.rPermiso.Find(RolId);//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Permiso;
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
                    contexto.rPermiso.Remove(item);
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

        public static List<rPermiso> GetList(Expression<Func<rPermiso, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<rPermiso> lista = new List<rPermiso>();

            try
            {
                lista = contexto.rPermiso.Where(criterio).ToList();
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
