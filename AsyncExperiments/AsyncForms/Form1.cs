namespace AsyncForms
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var asyncVoid = new AsyncVoid();
            asyncVoid.CallAsyncVoid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number.Text = $"Number:  {Result.GetNumberAsync().Result}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numberConfigure.Text = $"Number:  {Result.GetNumberWithConfigureAwaitAsync().Result}";
        }
    }
}
