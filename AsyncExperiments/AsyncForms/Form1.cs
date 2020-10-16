namespace AsyncForms
{
    using System;
    using System.Threading.Tasks;
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

        private void resultAwaiter_Click(object sender, EventArgs e)
        {
            numberResultAwaiter.Text = $"Number:  {Result.GetNumberAsync().GetAwaiter().GetResult()}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = string.Empty;
            Task.Run(() => text = $"Number:  {Result.GetNumberAsync().Result}");
            numberTaskRun.Text = text;
        }
    }
}
