using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace entrenador
{
    public partial class Funciones : Form
    {
        public Funciones()
        {
            InitializeComponent();
        }

        private void Funciones_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
   Modos modos = new Modos();
            modos.Show();

            this.Hide();
        }
    }
}
