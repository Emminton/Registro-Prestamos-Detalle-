using Microsoft.EntityFrameworkCore;
using Registro_Detalle_Aplicada_2.DALL;
using Registro_Detalle_Aplicada_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Registro_Detalle_Aplicada_2.BLL
{
    public class PrestamoBLL
    {
        public static bool Guardar(Prestamo prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }
        private static bool AfectarBalanceAlInsertarModificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;

                db.Personas.Find(prestamo.PersonaId).Balance = prestamo.Balance;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Insertar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Prestamos.Add(prestamo);

                AfectarBalanceAlInsertarModificar(prestamo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(prestamo).State = EntityState.Modified;

                AfectarBalanceAlInsertarModificar(prestamo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }    
        public static bool Eliminar(int id, int personaId)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var prestamo = db.Prestamos.Find(id);

                if (prestamo != null)
                {
                    db.Prestamos.Remove(prestamo);//remueve la entidad
                    var Eliminar = db.Personas.Find(personaId).Balance = 0;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Prestamo Buscar(int id)
        {
            Contexto db = new Contexto();
            Prestamo prestamo = new Prestamo();

            try
            {
                prestamo = db.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return prestamo;
        }
        public static bool Existe(int id)//determina si existe un Prestamo
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Prestamos.Any(p => p.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static List<Prestamo> GetPrestamos()
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Prestamos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> criterio)
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
