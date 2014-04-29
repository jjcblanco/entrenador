using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace entrenador
{
    public partial class Registro : Form
    {
        Conexion sql = new Conexion();
        MySqlDataAdapter data;        
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || last.Text == "" || user.Text == "" || pass1.Text == "" || pass2.Text == "")
            {
                MessageBox.Show("Faltan completar campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pass1.Text != pass2.Text)
            {
                check.Text = "Las contraseñas no coinciden";
                check.Visible = true;
            }
            else
            {
                try
                {
                    sql.OpenSql();
                }
                catch
                {
                    MessageBox.Show("No se ha podido iniciar sesion en la base de datos", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (sql.Status() == ConnectionState.Open)
                {
                    data = new MySqlDataAdapter(String.Format("Insert into user values('','{0}','{1}','{2}','{3}')", user.Text, pass1.Text, name.Text, last.Text), sql.ConexSql());
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    try
                    {
                        cmd.GetInsertCommand();
                    }
                    catch { }
                    
                    
                    DialogResult resul = MessageBox.Show("Su registro ha sido completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resul == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                        Login lg = new Login();
                        lg.Show();
                        sql.CloseSql();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pass1.UseSystemPasswordChar = false;
                pass1.Focus();

            }
            if(!checkBox1.Checked)
            {
                pass1.UseSystemPasswordChar = true;
                pass1.Focus();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                pass2.UseSystemPasswordChar = false;
                pass2.Focus();
            }
            if (!checkBox2.Checked)
            {
                pass2.UseSystemPasswordChar = true;
                pass2.Focus();
            }
        }
    }
}
