namespace PicWinUSB
{
    partial class Entrenadormain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entrenadormain));
            this.led = new System.Windows.Forms.Button();
            this.adc = new System.Windows.Forms.Button();
            this.adcBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // led
            // 
            this.led.Location = new System.Drawing.Point(12, 120);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(75, 23);
            this.led.TabIndex = 0;
            this.led.Text = "Toggle LED";
            this.led.UseVisualStyleBackColor = true;
            this.led.Click += new System.EventHandler(this.led_Click);
            // 
            // adc
            // 
            this.adc.Location = new System.Drawing.Point(12, 149);
            this.adc.Name = "adc";
            this.adc.Size = new System.Drawing.Size(75, 23);
            this.adc.TabIndex = 3;
            this.adc.Text = "Read ADC";
            this.adc.UseVisualStyleBackColor = true;
            this.adc.Click += new System.EventHandler(this.adc_Click);
            // 
            // adcBar
            // 
            this.adcBar.Location = new System.Drawing.Point(93, 149);
            this.adcBar.Name = "adcBar";
            this.adcBar.Size = new System.Drawing.Size(119, 23);
            this.adcBar.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(296, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "Conectar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Entrenadormain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 183);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adcBar);
            this.Controls.Add(this.adc);
            this.Controls.Add(this.led);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Entrenadormain";
            this.Text = "Entrenador";
            this.Load += new System.EventHandler(this.Entrenadormain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button led;
        private System.Windows.Forms.Button adc;
        private System.Windows.Forms.ProgressBar adcBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

