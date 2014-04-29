using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicWinUSB
{
    public partial class FrmSplash : Form
    {
        public FrmSplash(int segundos)
        {
            //
            // Necesario para admitir el diseñador de Windows Forms
            //

            InitializeComponent();

            timer1.Interval = segundos * 1000;    // pasamos de segundos a milisegundos

            if (!timer1.Enabled)
                timer1.Enabled = true;    // Activamos el Timer si no esta Enabled (Activado)

            //
            // TODO: Agregar código de constructor después de llamar a InitializeComponent
            //
            
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            //FrmSplash f1 = new FrmSplash(5);
            //f1.ShowDialog(this);     
            //f1.Dispose();
            //Application.Run(new Entrnadormain());
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();     // Se para el timer.
            Entrenadormain frm2 = new Entrenadormain();
            frm2.Show();
            this.Close();
        }
    }
}
