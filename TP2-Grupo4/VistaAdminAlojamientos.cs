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
            /*new db("");
            Directory.GetFiles(Application.StartupPath + "\\db\\", "*.txt").ToList().Select(Path.GetFileNameWithoutExtension).ToArray();
            db DataBase = new db("Alojamientos");
            List<List<string>> tabla = db.Abrir();
            db.VerEnDGV(dataGridView1, tabla);*/
        }

        DataTable table = new DataTable();
        private void VistaAdminAlojamientos_Load(object sender, EventArgs e)
        {
            table.Columns.Add("CODIGO", typeof(string));
            table.Columns.Add("CIUDAD", typeof(string));
            table.Columns.Add("BARRIO", typeof(string));
            table.Columns.Add("ESTRELLAS", typeof(int));
            table.Columns.Add("CANT_PERSONAS", typeof(int));
            table.Columns.Add("TV", typeof(bool));
            table.Columns.Add("Tipo", typeof(string));
            table.Columns.Add("PRECIO_X_PERSONA", typeof(double));
            table.Columns.Add("PRECIO_X_DIA", typeof(double));
            table.Columns.Add("HABITACIONES", typeof(int));
            table.Columns.Add("BAÑOS", typeof(int));

            dataGridView1.DataSource = table;
            dataGridView1.ReadOnly = false;
            getTextAlojamientos();
        }

        private void getTextAlojamientos()
        {
            // Cambiar ruta absoluta
            string[] lines = File.ReadAllLines(Application.StartupPath + "alojamientos.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split(',');
                string[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                try
                {
                    table.Rows.Add(row);
                }
                catch
                {
                    MessageBox.Show("Error en la carga de datos,"+"\n"+"se han ignorado datos incorrectos.");
                }
            }
        }
        private void setTextAlojamientos()
        {
            string[] lines = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text };
            using StreamWriter file = new StreamWriter("alojamientos.txt", true);
            int num = 0;
            foreach (string line in lines)
            {
                num++;
                if (num < 11)
                {
                    file.Write(line + ",");
                }
                else
                {
                    file.Write(line+"\n");
                    MessageBox.Show("Los datos se han cargado exitosamente.");
                }
            }
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

        private void button6_Click(object sender, EventArgs e)
        {
            //DataGridViewRow fila = new DataGridViewRow();
            //db.CrearTabla("Alojamientos", );

            /*DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dataGridView1);
            fila.Cells[0].Value = textBox1.Text;
            fila.Cells[1].Value = textBox2.Text;
            fila.Cells[2].Value = textBox3.Text;
            fila.Cells[3].Value = textBox4.Text;
            fila.Cells[4].Value = textBox5.Text;
            fila.Cells[5].Value = textBox6.Text;
            fila.Cells[6].Value = textBox7.Text;
            fila.Cells[7].Value = textBox8.Text;
            fila.Cells[8].Value = textBox9.Text;
            fila.Cells[9].Value = textBox10.Text;
            fila.Cells[10].Value = textBox11.Text;

            dataGridView1.Rows.Add(fila);*/
            setTextAlojamientos();
            textBox1.Text = "Código";
            textBox1.ForeColor = Color.LightGray;
            textBox2.Text = "Ciudad";
            textBox2.ForeColor = Color.LightGray;
            textBox3.Text = "Barrio";
            textBox3.ForeColor = Color.LightGray;
            textBox4.Text = "Estrellas";
            textBox4.ForeColor = Color.LightGray;
            textBox5.Text = "Can. Pers.";
            textBox5.ForeColor = Color.LightGray;
            textBox6.Text = "TV";
            textBox6.ForeColor = Color.LightGray;
            textBox7.Text = "Tipo";
            textBox7.ForeColor = Color.LightGray;
            textBox8.Text = "Precio Pers.";
            textBox8.ForeColor = Color.LightGray;
            textBox9.Text = "Precio Día";
            textBox9.ForeColor = Color.LightGray;
            textBox10.Text = "Habitaciones";
            textBox10.ForeColor = Color.LightGray;
            textBox11.Text = "Baños";
            textBox11.ForeColor = Color.LightGray;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch
            {
                MessageBox.Show("No se puede eliminar esta fila.");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Código")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Código";
                textBox1.ForeColor = Color.DimGray;
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Ciudad")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Ciudad";
                textBox2.ForeColor = Color.DimGray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Barrio")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Barrio";
                textBox3.ForeColor = Color.DimGray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Estrellas")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Estrellas";
                textBox4.ForeColor = Color.DimGray;
            }
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Can. Pers.")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Can. Pers.";
                textBox5.ForeColor = Color.DimGray;
            }
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "TV")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }
        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "TV";
                textBox6.ForeColor = Color.DimGray;
            }
        }
        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Tipo")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }
        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Tipo";
                textBox7.ForeColor = Color.DimGray;
            }
        }
        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Precio Pers.")
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }
        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Precio Pers.";
                textBox8.ForeColor = Color.DimGray;
            }
        }
        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "Precio Día")
            {
                textBox9.Text = "";
                textBox9.ForeColor = Color.Black;
            }
        }
        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "Precio Día";
                textBox9.ForeColor = Color.DimGray;
            }
        }
        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Text == "Habitaciones")
            {
                textBox10.Text = "";
                textBox10.ForeColor = Color.Black;
            }
        }
        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "Habitaciones";
                textBox10.ForeColor = Color.DimGray;
            }
        }
        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Text == "Baños")
            {
                textBox11.Text = "";
                textBox11.ForeColor = Color.Black;
            }
        }
        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox11.Text = "Baños";
                textBox11.ForeColor = Color.DimGray;
            }
        }
    }
}
