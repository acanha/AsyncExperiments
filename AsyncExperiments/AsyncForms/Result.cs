namespace AsyncForms
{
    using System.Threading.Tasks;

    public class Result
    {
        public static async Task<int> GetNumberAsync()
        {
            await Task.Delay(5);
            return 5;  
        }
    }
}
