﻿using Microsoft.EntityFrameworkCore;
using Registro_Detalle_Aplicada_2.DALL;
using Registro_Detalle_Aplicada_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Registro_Detalle_Aplicada_2.BLL
{
    public class MoraBLL
    {
        public static bool Guardar(Mora mora)
        {
            if (!Existe(mora.MoraId))
                return Insertar(mora);
            else
                return Modificar(mora);
        }
        public static bool Insertar(Mora mora)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Moras.Add(mora);
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

        public static bool Modificar(Mora mora)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM MoraDetalle Where MoraId = {mora.MoraId}");

                foreach (var item in mora.MoraDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(mora).State = EntityState.Modified;
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

        public static Mora Buscar(int id)
        {
            Contexto db = new Contexto();
            Mora mora = new Mora();

            try
            {
                mora = db.Moras.Where(m => m.MoraId == id).Include(m => m.MoraDetalle).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return mora;
        }
        public static bool Existe(int id)//determina si existe una Mora
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Moras.Any(m => m.MoraId == id);
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

        public static List<Mora> GetMoras()
        {
            List<Mora> lista = new List<Mora>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Moras.ToList();
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

        public static List<Mora> GetList(Expression<Func<Mora, bool>> criterio)
        {
            List<Mora> lista = new List<Mora>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Moras.Where(criterio).ToList();
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
