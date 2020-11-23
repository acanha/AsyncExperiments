
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.numberConfigure = new System.Windows.Forms.Label();
            this.resultAwaiter = new System.Windows.Forms.Button();
            this.numberResultAwaiter = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.numberTaskRun = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.withoutElidingText = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.elidingText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "async void";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = ".Result";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Location = new System.Drawing.Point(138, 87);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(57, 15);
            this.number.TabIndex = 2;
            this.number.Text = "Number: ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = ".Result Configure";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numberConfigure
            // 
            this.numberConfigure.AutoSize = true;
            this.numberConfigure.Location = new System.Drawing.Point(183, 134);
            this.numberConfigure.Name = "numberConfigure";
            this.numberConfigure.Size = new System.Drawing.Size(54, 15);
            this.numberConfigure.TabIndex = 4;
            this.numberConfigure.Text = "Number:";
            // 
            // resultAwaiter
            // 
            this.resultAwaiter.Location = new System.Drawing.Point(41, 179);
            this.resultAwaiter.Name = "resultAwaiter";
            this.resultAwaiter.Size = new System.Drawing.Size(75, 23);
            this.resultAwaiter.TabIndex = 5;
            this.resultAwaiter.Text = "GetResult";
            this.resultAwaiter.UseVisualStyleBackColor = true;
            this.resultAwaiter.Click += new System.EventHandler(this.resultAwaiter_Click);
            // 
            // numberResultAwaiter
            // 
            this.numberResultAwaiter.AutoSize = true;
            this.numberResultAwaiter.Location = new System.Drawing.Point(158, 186);
            this.numberResultAwaiter.Name = "numberResultAwaiter";
            this.numberResultAwaiter.Size = new System.Drawing.Size(54, 15);
            this.numberResultAwaiter.TabIndex = 6;
            this.numberResultAwaiter.Text = "Number:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(41, 236);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "TaskRun";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // numberTaskRun
            // 
            this.numberTaskRun.AutoSize = true;
            this.numberTaskRun.Location = new System.Drawing.Point(158, 243);
            this.numberTaskRun.Name = "numberTaskRun";
            this.numberTaskRun.Size = new System.Drawing.Size(54, 15);
            this.numberTaskRun.TabIndex = 8;
            this.numberTaskRun.Text = "Number:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(41, 301);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Without Eliding";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // withoutElidingText
            // 
            this.withoutElidingText.AutoSize = true;
            this.withoutElidingText.Location = new System.Drawing.Point(158, 309);
            this.withoutElidingText.Name = "withoutElidingText";
            this.withoutElidingText.Size = new System.Drawing.Size(31, 15);
            this.withoutElidingText.TabIndex = 10;
            this.withoutElidingText.Text = "Text:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(41, 347);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(102, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "Eliding";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // elidingText
            // 
            this.elidingText.AutoSize = true;
            this.elidingText.Location = new System.Drawing.Point(158, 355);
            this.elidingText.Name = "elidingText";
            this.elidingText.Size = new System.Drawing.Size(31, 15);
            this.elidingText.TabIndex = 12;
            this.elidingText.Text = "Text:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elidingText);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.withoutElidingText);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.numberTaskRun);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.numberResultAwaiter);
            this.Controls.Add(this.resultAwaiter);
            this.Controls.Add(this.numberConfigure);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.number);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label numberConfigure;
        private System.Windows.Forms.Button resultAwaiter;
        private System.Windows.Forms.Label numberResultAwaiter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label numberTaskRun;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label withoutElidingText;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label elidingText;
    }
}

