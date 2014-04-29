using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace entrenador
{
    class Conexion
    {
        public Conexion() { }
        MySqlConnection sql = new MySqlConnection("DataBase=entrenador;Data Source=jjcblanco.com.ar;UserId=tinobreg;Password='tintin77'");
        public MySqlConnection ConexSql()
        {
            return sql;
        }
        public void OpenSql()
        {
            
            sql.Open(); 
            
        }

        public void CloseSql() 
        {
            sql.Close();
        }

        public System.Data.ConnectionState Status()
        {
            return sql.State;
        }
    }
}
