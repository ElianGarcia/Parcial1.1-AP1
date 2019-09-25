using Parcial1._1_AP1.UI.Consultas;
using Parcial1._1_AP1.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1._1_AP1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EvaluacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEvaluaciones registro = new rEvaluaciones();
            registro.MdiParent = this;
            registro.Show();
        }

        private void EvaluacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cEvaluaciones consulta = new cEvaluaciones();
            consulta.MdiParent = this;
            consulta.Show();
        }
    }
}
