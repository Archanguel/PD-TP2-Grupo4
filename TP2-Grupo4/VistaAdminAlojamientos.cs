using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace TP2_Grupo4
{
    public partial class VistaAdminAlojamientos : Form
    {
        public VistaAdminAlojamientos()
        {
            InitializeComponent();
            new db("");
            new db("alojamientos").VerEnDGV(dataGridView1, new db("alojamientos").Abrir());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VistaAdminReservas cambiarFormulario = new VistaAdminReservas();
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
        string id_nuevo()
        {
            var ids = new db("alojamientos").Abrir().Select(x => x[0]).ToList();
            return ids.Count == 1 ? "0" : (int.Parse(ids[ids.Count - 1]) + 1).ToString();
        }

        db alojamientos = new db("alojamientos");
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = id_nuevo();
            alojamientos.Insertar(new List<string>() { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text });
            alojamientos.VerEnDGV(dataGridView1, alojamientos.Abrir());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                alojamientos.Eliminar(id => id == textBox1.Text, 0);
                alojamientos.VerEnDGV(dataGridView1, alojamientos.Abrir());
            }
            catch
            {
                MessageBox.Show("No se puede eliminar esta fila.");
            }

            /*try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch
            {
                MessageBox.Show("No se puede eliminar esta fila.");
            }*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            alojamientos.Actualizar(id => id == textBox1.Text, 0, new List<string>() { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text });
            alojamientos.VerEnDGV(dataGridView1, alojamientos.Abrir());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCellCollection row = dataGridView1.Rows[e.RowIndex].Cells;
                textBox1.Text = Convert.ToString(row[0].Value);
                textBox2.Text = Convert.ToString(row[1].Value);
                textBox3.Text = Convert.ToString(row[2].Value);
                textBox4.Text = Convert.ToString(row[3].Value);
                textBox5.Text = Convert.ToString(row[4].Value);
                textBox6.Text = Convert.ToString(row[5].Value);
                textBox7.Text = Convert.ToString(row[6].Value);
                textBox8.Text = Convert.ToString(row[7].Value);
                textBox9.Text = Convert.ToString(row[8].Value);
                textBox10.Text = Convert.ToString(row[9].Value);
                textBox11.Text = Convert.ToString(row[10].Value);
            }
        }
    }
}
