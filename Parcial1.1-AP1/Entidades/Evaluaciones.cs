using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial1._1_AP1.Entidades
{
    public class Evaluaciones
    {
        [Key]
        public int IDEvaluacion { get; set; }
        public string Estudiante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }

        public Evaluaciones(int iDEvaluacion, string estudiante, DateTime fecha, decimal valor, decimal logrado, decimal perdido)
        {
            IDEvaluacion = iDEvaluacion;
            Estudiante = estudiante ?? throw new ArgumentNullException(nameof(estudiante));
            Fecha = fecha;
            Valor = valor;
            Logrado = logrado;
            Perdido = perdido;
        }

        public Evaluaciones()
        {

        }
    }
}
