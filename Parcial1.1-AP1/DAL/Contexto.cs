using Parcial1._1_AP1.Entidades;
using System.Data.Entity;

namespace Parcial1._1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Evaluaciones> Evaluacion { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
