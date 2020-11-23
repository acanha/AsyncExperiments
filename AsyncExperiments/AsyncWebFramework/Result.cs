using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWebFramework
{
    public class Result
    {
        public async Task<int> GetNumberAsync()
        {
            await Task.Delay(5);
            return 5;
        }

        public async Task<int> GetNumberWithConfigureAwaitAsync()
        {
            await Task.Delay(5).ConfigureAwait(false);
            return 5;
        }
    }
}