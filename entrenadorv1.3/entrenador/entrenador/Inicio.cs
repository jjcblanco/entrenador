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
    public partial class Inicio : Form
    {
        Conexion sql = new Conexion();
        MySqlDataAdapter data;
        DataSet set;
        MySqlCommandBuilder cmd;
        DataRow dr;
        public String IdNum;
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                sql.OpenSql();
            }
            catch
            {
                MessageBox.Show("Problemas de conexion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (sql.Status() == ConnectionState.Open)
            {
                data = new MySqlDataAdapter(String.Format("select name, surname from user where id = '{0}'",IdNum),sql.ConexSql());
                set = new DataSet();
                data.Fill(set, "user");
                if (set.Tables["user"].Rows.Count > 0)
                { 
                    dr = set.Tables["user"].Rows[0];
                    name.Text = dr["name"].ToString();
                    last.Text = dr["surname"].ToString();
                    name.Visible = true;
                    last.Visible = true;
                    sql.CloseSql();
                }

            }
            }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resul = MessageBox.Show("¿Desea cerrar sesion?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.Yes)
            {
                Login lg = new Login();
                lg.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("¿Desea cerrar sesion?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
        }
        } 
    }
