namespace AsyncConsole
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            // Async void
            Console.WriteLine("Calling async void");
            var asyncVoid = new AsyncVoid();
            asyncVoid.CallAsyncVoid();
        }
    }
}
