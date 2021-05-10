using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class VistaAdminReservas : Form
    {
        public VistaAdminReservas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VistaAdminAlojamientos cambiarFormulario = new VistaAdminAlojamientos();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VistaAdminUsuarios cambiarFormulario = new VistaAdminUsuarios();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login cambiarFormulario = new Login();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string a;
                string b;

                a = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                b = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                VistaAdminAlojamientos data = new VistaAdminAlojamientos();
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "Form1")
                    {
                        data = (VistaAdminAlojamientos)frm;
                        data.dataGridView1.Rows.Add(a, b);

                        this.Close();
                        break;
                    }
                }
            }*/
        }
    }
}
