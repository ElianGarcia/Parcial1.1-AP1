using Parcial1._1_AP1.BLL;
using Parcial1._1_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1._1_AP1.UI.Registros
{
    public partial class rEvaluaciones : Form
    {
        public rEvaluaciones()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            EvaluacionIDnumericUpDown.Value = 0;
            EstudiantetextBox.Text = "";
            FechadateTimePicker.Value = DateTime.Now;
            PerdidotextBox.Text = "";
            ValortextBox.Text = "";
            LogradotextBox.Text = "";
        }

        private Evaluaciones LlenaClase()
        {
            Evaluaciones evaluacion = new Evaluaciones();
            evaluacion.IDEvaluacion = (int)EvaluacionIDnumericUpDown.Value;
            evaluacion.Estudiante = EstudiantetextBox.Text;
            evaluacion.Fecha = FechadateTimePicker.Value;
            evaluacion.Perdido = Convert.ToDecimal(PerdidotextBox.Text);
            evaluacion.Valor = Convert.ToDecimal(ValortextBox.Text);
            evaluacion.Logrado = Convert.ToDecimal(LogradotextBox.Text);

            return evaluacion;
        }

        private void LlenarCampos(Evaluaciones evaluacion)
        {
            EvaluacionIDnumericUpDown.Value = evaluacion.IDEvaluacion;
            EstudiantetextBox.Text = evaluacion.Estudiante;
            FechadateTimePicker.Value = evaluacion.Fecha;
            PerdidotextBox.Text = evaluacion.Perdido.ToString();
            ValortextBox.Text = evaluacion.Valor.ToString();
            LogradotextBox.Text = evaluacion.Logrado.ToString();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int Id;
            int.TryParse(EvaluacionIDnumericUpDown.Value.ToString(), out Id);

            try
            {
                Evaluaciones evaluacion = EvaluacionesBLL.Buscar(Id);

                if (evaluacion != null)
                {
                    LlenarCampos(evaluacion);
                }
                else
                    MessageBox.Show("Evaluacion no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Validar()
        {
            bool realizado = true;

            if (string.IsNullOrWhiteSpace(EstudiantetextBox.Text))
            {
                errorProvider.SetError(EstudiantetextBox, "El campo Estudiante no debe estar vacio");
                EstudiantetextBox.Focus();
                realizado = false;
            }
            if (string.IsNullOrWhiteSpace(ValortextBox.Text) && ValortextBox.Text != "-")
            {
                errorProvider.SetError(ValortextBox, "El campo Valor no debe estar vacio \n El campo Valor no debe ser menor que 0");
                ValortextBox.Focus();
                realizado = false;
            }
            if (string.IsNullOrWhiteSpace(LogradotextBox.Text) && LogradotextBox.Text != "-")
            {
                errorProvider.SetError(LogradotextBox, "El campo Logrado no debe estar vacio \n El campo Logrado no debe ser menor que 0");
                LogradotextBox.Focus();
                realizado = false;
            }

            return realizado;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private bool Existe()
        {
            Evaluaciones e = EvaluacionesBLL.Buscar((int)EvaluacionIDnumericUpDown.Value);

            return (e != null);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Evaluaciones evaluacion = new Evaluaciones();
            bool realizado = false;

            if (!Validar())
                return;

            try
            {
                evaluacion = LlenaClase();

                if (EvaluacionIDnumericUpDown.Value == 0)
                {
                    realizado = EvaluacionesBLL.Guardar(evaluacion);
                }
                else
                {
                    if (!Existe())
                    {
                        MessageBox.Show("No se puede modificar porque no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    realizado = EvaluacionesBLL.Modificar(evaluacion);
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (realizado)
            {
                LimpiarCampos();
                MessageBox.Show("Guardado exitosamente!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogradotextBox_TextChanged(object sender, EventArgs e)
        {
            decimal valor = 0;
            decimal logrado = 0;

            if (!string.IsNullOrWhiteSpace(ValortextBox.Text) && ValortextBox.Text != "-")
            {
                valor = decimal.Parse(ValortextBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(LogradotextBox.Text) && LogradotextBox.Text != "-")
            {
                logrado = decimal.Parse(LogradotextBox.Text);
            }

            decimal perdido = valor - logrado;

            PerdidotextBox.Text = perdido.ToString();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int Id;
            int.TryParse(EvaluacionIDnumericUpDown.Value.ToString(), out Id);

            try
            {
                if (EvaluacionesBLL.Buscar(Id) != null)
                {
                    if (EvaluacionesBLL.Eliminar(Id))
                    {
                        MessageBox.Show("Eliminada Correctamente", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar porque no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValortextBox_TextChanged(object sender, EventArgs e)
        {
            decimal valor = 0;
            decimal logrado = 0;

            if (!string.IsNullOrWhiteSpace(ValortextBox.Text) && ValortextBox.Text != "-")
            {
                valor = decimal.Parse(ValortextBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(LogradotextBox.Text) && LogradotextBox.Text != "-")
            {
                logrado = decimal.Parse(LogradotextBox.Text);
            }

            decimal perdido = valor - logrado;

            PerdidotextBox.Text = perdido.ToString();
        }
    }
}
