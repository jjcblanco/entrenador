////////////////////////////////////////////////////////////////////////////
////                                                                     ////
////                                                                    ////
////    This aplication shows how to use Microsoft WinUSB driver with   ////
////    a PIC 18F2550. Information has been extracted from MSDN:        ////
////                                                                    ////
////    - How to Use WinUSB to Communicate with a USB Device:           ////
////    http://www.microsoft.com/whdc/device/connect/WinUsb_HowTo.mspx  ////
////    - WinUSB:                                                       ////
////    http://msdn2.microsoft.com/en-us/library/aa476426.aspx          ////
////    - WinUSB User-Mode Client Support Routines:                     ////
////    http://msdn2.microsoft.com/en-us/library/aa476437.aspx          ////
////                                                                    ////
////    PicWinUSB is offered AS-IS and without warranty of any kind.    ////
////    You cannot copy, distribute or sell this code.                  ////
////                                                                    ////
////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PicWinUSB;

namespace PicWinUSB
{
    public partial class Entrenadormain : Form
    {
        public IntPtr iHandle;     // global device handle definition

        PicWinUSBAPI picwinusbapi = new PicWinUSBAPI();
        
        public Entrenadormain()
        {
            Guid InterfaceGuid = new  Guid("31415926-5358-9793-2384-626433832795"); // .Inf defined Guid
                        
            InitializeComponent();
            iHandle = picwinusbapi.Init_PicWinUSB(InterfaceGuid);
            //textBox1.Text = iHandle.ToString();
        }

        private void led_Click(object sender, EventArgs e)
        {
            bool bres;
            byte[] sdBuffer = new byte[2];           // Define send DataBuffer size

            sdBuffer[0] = 0x00;    //Mode
            sdBuffer[1] = 0x01;    //Led
            
            bres = picwinusbapi.Write_PicWinUSB(iHandle, sdBuffer);
        }
        
        private void adc_Click(object sender, EventArgs e)
        {
            bool bres;
            byte[] sdBuffer = new byte[1];           // Define send DataBuffer size
            byte[] rdBuffer = new byte[2];           // Define recieve DataBuffer size

            sdBuffer[0] = 0x01;    //Mode

            bres = picwinusbapi.Write_PicWinUSB(iHandle, sdBuffer);
            bres = picwinusbapi.Read_PicWinUSB(iHandle, rdBuffer);

            if (rdBuffer[0] == 1)
            {
                adcBar.Value = (int)(rdBuffer[1] * 100 / 254);
            }
        }

    
       

        private void button1_Click(object sender, EventArgs e)
        {
            bool bres;
            byte[] sdBuffer = new byte[2];           // Define send DataBuffer size
            byte i=0;
            
       
            
            sdBuffer[0] = 0x02;    //Mode
            sdBuffer[1] = i;
            bres = picwinusbapi.Write_PicWinUSB(iHandle, sdBuffer);
            i++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Guid InterfaceGuid = new Guid("31415926-5358-9793-2384-626433832795"); // .Inf defined Guid
            iHandle = picwinusbapi.Init_PicWinUSB(InterfaceGuid);
            textBox1.Text = iHandle.ToString();
        }

        private void Entrenadormain_Load(object sender, EventArgs e)
        {

        }
    }
}
