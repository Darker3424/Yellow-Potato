using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIBDATOS;

namespace LabSesionEFLIBCLASES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = ClsApli01.ListarPedidos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dtpFechaInicio.Value > dtpFechaFinal.Value)
            {
                MessageBox.Show("La fecha de inicio es mayor a la fecha final");
            }
            else
            {
                dataGridView1.DataSource = ClsApli01.PedidosporRangoFechas(
                    dtpFechaInicio.Value, dtpFechaFinal.Value);
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
    }
}
