using Parcial1._1_AP1.Entidades;
using Parcial1._1_AP1.DAL;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Parcial1._1_AP1.BLL
{
    public class EvaluacionesBLL
    {
        public static bool Guardar(Evaluaciones evaluacion)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Evaluacion.Add(evaluacion) != null)
                {
                    realizado = db.SaveChanges() > 0;
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

            return realizado;
        }

        public static bool Eliminar(int Id)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                var evaluaciones = db.Evaluacion.Find(Id);
                db.Entry(evaluaciones).State = EntityState.Deleted;
                realizado = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return realizado;
        }

        public static Evaluaciones Buscar(int Id)
        {
            Evaluaciones evaluaciones = new Evaluaciones();
            Contexto db = new Contexto();

            try
            {
                evaluaciones = db.Evaluacion.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return evaluaciones;
        }

        public static bool Modificar(Evaluaciones evaluacion)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                realizado = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return realizado;
        }

        public static List<Evaluaciones> GetList(Expression<Func<Evaluaciones, bool>> evaluacion)
        {
            List<Evaluaciones> Lista = new List<Evaluaciones>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Evaluacion.Where(evaluacion).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}
