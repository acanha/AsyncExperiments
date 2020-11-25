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
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown.Value = Result.GetNumberAsync(numericUpDown.Value).Result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown.Value = Result.GetNumberWithConfigureAwaitAsync(numericUpDown.Value).Result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = $"Time: {DateTime.UtcNow.ToString("HH:mm:ss")}";
        }

        #region Tests
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var asyncVoid = new AsyncVoid();
        //    asyncVoid.CallAsyncVoid();
        //}
        //private void resultAwaiter_Click(object sender, EventArgs e)
        //{
        //    numberResultAwaiter.Text = $"Number:  {Result.GetNumberAsync().GetAwaiter().GetResult()}";
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    string text = string.Empty;
        //    Task.Run(() => text = $"Number:  {Result.GetNumberAsync().Result}");
        //    numberTaskRun.Text = text;
        //}

        //private async void button5_Click(object sender, EventArgs e)
        //{
        //    withoutElidingText.Text = $"Text:  {await Result.GetWithKeywordsAsync()}";
        //}

        //private async void button6_Click(object sender, EventArgs e)
        //{
        //    elidingText.Text = $"Text:  {await Result.GetElidingKeywordsAsync()}";
        //}
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var number = await Result.GetNumberAsync(numericUpDown.Value).ConfigureAwait(false);
            numericUpDown.Value = number;
        }
    }
}
