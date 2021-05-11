using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP2_Grupo4
{
    public partial class Login : Form
    {
        int intentos = 3;
        string contraseña;
        //VistaClienteFiltrar ingresoCliente = new VistaClienteFiltrar();
        ControlPanelClient ingresoCliente = new ControlPanelClient();
        //VistaAdminUsuarios ingresoAdmin = new VistaAdminUsuarios();
        ControlPanelAdmin ingresoAdmin = new ControlPanelAdmin();
        public Login()
        {
            InitializeComponent();
            new db("");
        }
        string id_nuevo()
        {
            var ids = new db("usuarios").Abrir().Select(x => x[0]).ToList();
            return ids.Count == 1 ? "0" : (int.Parse(ids[ids.Count - 1]) + 1).ToString();
        }
        db usuarios = new db("usuarios");
        string id;
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader lectura;
            string user = textBox1.Text;
            string pass = textBox2.Text;
            string cadena;
            bool encontrado = false;
            string[] campos = new string[5];
            char[] separador = { ',' };
            bool adm = true;

            try
            {
                lectura = File.OpenText(Application.StartupPath+"db/usuarios.txt");
                cadena = lectura.ReadLine();
                while (cadena != null && encontrado == false)
                {
                    campos = cadena.Split(separador);
                    if (campos[1].Equals(user))
                    {
                        if (campos[2].Equals(pass))
                        {
                            if (campos[3].Equals(adm))
                            {
                                encontrado = true;
                                ingresoAdmin.Show();
                                this.Hide();
                                MessageBox.Show("Bienvenido Admin "+user);

                            }
                            else
                            {
                                encontrado = true;
                                ingresoCliente.Show();
                                this.Hide();
                                MessageBox.Show("Bienvenido Cliente "+user);
                            }
                        }
                        else
                        {
                            MessageBox.Show("contraseña incorrecta");
                            cadena = lectura.ReadLine();
                        }
                    }
                    else
                    {
                        cadena = lectura.ReadLine();
                    }
                }
                if (encontrado == false)
                {
                    MessageBox.Show("usuario incorrecto");
                }
            }
            catch
            {
                MessageBox.Show("error");
            }

            //validar si el usuario está correcto

            //si es válido y es cliente moverse a la VistaCliente
            /*string user = textBox1.Text;
            string password = textBox2.Text;
            string tempurl = "D:\\usuario\\xampp\\htdocs\\TP2-Grupo4\\usuarios\\" + user + ".txt"; ;
            if (File.Exists(tempurl))
            {
                contraseña = File.ReadAllText(tempurl);
                if (password.Equals(contraseña))
                {
                    ingresoAdmin.Show();
                    //ingresoCliente.Show();
                    this.Hide();
                    MessageBox.Show("Bienvenido usuario.");
                }
                else
                {
                    intentos--;
                    if (intentos == 0)
                    {
                        //acá hay que bloquear al usuario
                        MessageBox.Show("Usuario bloqueado, contacte con un administrador para desbloquear el usuario.");
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta, le quedan " + intentos + " intentos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("El usuario no está registrado, por favor vuelva a intentarlo.");
            }*/
            //newMDIChild2.Show();

            //si es válido y es admin moverse a la VistaAdmin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bloqueado = false;
            id = id_nuevo();
            try
            {
                usuarios.Insertar(new List<string>() { id, textBox1.Text, textBox2.Text, (checkBox1.Checked).ToString(), (bloqueado).ToString() });
                MessageBox.Show("Se ha registrado exitosamente.");
            }
            catch
            {
                MessageBox.Show("¡Error al ingresar los datos!");
            }
            /*string user = textBox1.Text;
            string password = textBox2.Text;
            string tempurl = "D:\\usuario\\xampp\\htdocs\\TP2-Grupo4\\usuarios\\" + user + ".txt";
            if (File.Exists(tempurl))
            {
                MessageBox.Show("Usuario ya registrado.");
            }
            else
            {
                File.WriteAllText(tempurl, password);
                MessageBox.Show("Se ha registrado exitosamente.");
                textBox1.Text = "";
                textBox2.Text = "";
            }*/
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.LightGray;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA";
                textBox2.ForeColor = Color.DimGray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControlPanelClient cambiarFormulario = new ControlPanelClient();
            cambiarFormulario.Show();
            this.Hide();
        }
    }
}
