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

        private async void button1_Click(object sender, EventArgs e)
        {
            // BAD CODE: the ConfigureAwait(false) will make the continuation of this method to run 
            // on a thread from the thread pool and not the UI thread, which will cause an error because the 
            // numericUpDown needs to run on the UI thread. 
            var number = await Result.GetNumberAsync(numericUpDown.Value).ConfigureAwait(false);
            numericUpDown.Value = number;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // BAD CODE: This will cause a deadlock on the UI thread which will freeze the app.
            numericUpDown.Value = Result.GetNumberAsync(numericUpDown.Value).Result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // BAD CODE: This is still bad code but will work since the method has a ConfigureAwait(false)
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
    }
}
