﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncWebFramework
{
    public class AsyncVoid
    {
        public async void CallAsyncVoid()
        {
            await Task.Delay(1);
        }

        public async void CallAsyncVoidWithException()
        {
            try
            {
                await Task.Delay(1);
                ThrowException();
            }
            catch (Exception ex)
            {
                //This line will never be reached
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async void ThrowException()
        {
            await Task.Delay(1);
            throw new Exception("My exception");
        }
    }
}