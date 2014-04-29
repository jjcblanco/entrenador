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
    public partial class Login : Form

    {

        //MySqlConnection sql = new MySqlConnection("DataBase=entrenador;Data Source=jjcblanco.com.ar;UserId=tinobreg;Password='tintin77'");
        Conexion sql = new Conexion();
        MySqlDataAdapter data;
        DataSet set;
        
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Faltan completar campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    sql.OpenSql();
                }
                catch
                {
                    MessageBox.Show("No se ha podido iniciar sesion en la base de datos","Notificación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                #region SQL
                if (sql.Status() == ConnectionState.Open)
                {
                    set = new DataSet();
                    data = new MySqlDataAdapter(String.Format("select id,user, password from user where user='{0}' and password='{1}'", user.Text, pass.Text), sql.ConexSql());
                    data.Fill(set, "user");
                    DataRow DR;
                    if (set.Tables["user"].Rows.Count > 0)
                    {
                        DR = set.Tables["user"].Rows[0];
                        if (pass.Text == DR["password"].ToString() && user.Text == DR["user"].ToString())
                        {
                            Inicio ini = new Inicio();
                            ini.IdNum = DR["id"].ToString();
                            MessageBox.Show("Logueo correcto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql.CloseSql();
                            
                            this.Hide();
                            
                            ini.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sql.CloseSql();
                    }
                }
                #endregion
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro rg = new Registro();
            rg.Show();

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        
    }
}
