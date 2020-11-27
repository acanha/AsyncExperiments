
namespace AsyncForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = ".Result";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.time.Location = new System.Drawing.Point(21, 93);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(63, 28);
            this.time.TabIndex = 2;
            this.time.Text = "Time: ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = ".Result with ConfigureAwait(false)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(21, 137);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "ConfigureAwait(false)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 200);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.time);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button button1;
    }
}

