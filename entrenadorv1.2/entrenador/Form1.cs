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
    public partial class Form1 : Form

    {

        MySqlConnection sql = new MySqlConnection("DataBase=entrenador;Data Source=trainer.jjcblanco.com.ar;UserId=tinobreg;Password='tintin77'");
        MySqlDataAdapter data;
        DataSet set;
        public Form1()
        {
            InitializeComponent();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Faltan completar campos");
            }
            else
            {
                try
                {
                    sql.Open();
                }
                catch
                {
                    MessageBox.Show("No se ha podido iniciar sesion en la base de datos");
                }
                #region SQL
                if (sql.State == ConnectionState.Open)
                {
                    set = new DataSet();
                    data = new MySqlDataAdapter(String.Format("select user, password from user where user='{0}' and password='{1}'", user.Text, pass.Text), sql);
                    data.Fill(set, "user");
                    DataRow DR;
                    if (set.Tables["user"].Rows.Count > 0)
                    {
                        DR = set.Tables["user"].Rows[0];
                        if (pass.Text == DR["password"].ToString() && user.Text == DR["user"].ToString())
                        {
                            MessageBox.Show("Logueo correcto");
                            sql.Close();
                            Funciones x = new Funciones();
                            x.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                        sql.Close();
                    }
                }
                #endregion
            }
        }

        
    }
}
