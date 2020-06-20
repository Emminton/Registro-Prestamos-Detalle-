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
    public class PersonaBLL
    {
        public static bool Guardar(Persona persona)
        {
            if (!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }
        public static bool Insertar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Personas.Add(persona);
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

        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var persona = db.Personas.Find(id);

                if (persona != null)
                {
                    db.Personas.Remove(persona);//remueve la entidad
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

        public static Persona Buscar(int id)
        {
            Contexto db = new Contexto();
            Persona persona = new Persona();

            try
            {
                persona = db.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return persona;
        }
        public static bool Existe(int id)//determina si existe una persona
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Personas.Any(p => p.PersonaId == id);
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
        public static List<Persona> GetPersonas()
        {
            List<Persona> lista = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Personas.ToList();
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

        public static List<Persona> GetList(Expression<Func<Persona, bool>> criterio)
        {
            List<Persona> lista = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Personas.Where(criterio).ToList();
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
