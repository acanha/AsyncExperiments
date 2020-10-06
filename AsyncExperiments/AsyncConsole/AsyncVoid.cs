namespace AsyncConsole
{
    using System;
    using System.Threading.Tasks;

    public class AsyncVoid
    {
        public async void CallAsyncVoid()
        {
            try
            {
                Console.WriteLine("Before throw exception");
                await Task.Delay(1);
                ThrowException();
            }
            catch (Exception ex)
            {
                //This line will never be reached
                Console.WriteLine($"Exception: {ex.Message}" );
            }
        }

        private async void ThrowException()
        {
            await Task.Delay(1);
            throw new Exception("My exception");
        }
    }
}
