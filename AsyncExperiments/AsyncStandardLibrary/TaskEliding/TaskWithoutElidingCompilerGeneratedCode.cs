using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AsyncStandardLibrary
{
    public class TaskWithoutElidingCompilerGeneratedCode
    {
        [StructLayout(LayoutKind.Auto)]
        [CompilerGenerated]
        private struct ElidingStateMachine : IAsyncStateMachine
        {
            public int firstState;

            public AsyncTaskMethodBuilder<string> builder;

            private HttpClient httpClient;

            private TaskAwaiter<string> taskAwaiter;

            private void MoveNext()
            {
                int num = firstState;
                string result;
                try
                {
                    if (num != 0)
                    {
                        httpClient = new HttpClient();
                    }
                    try
                    {
                        TaskAwaiter<string> awaiter;
                        if (num != 0)
                        {
                            awaiter = httpClient.GetStringAsync("https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1").GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                num = (firstState = 0);
                                taskAwaiter = awaiter;
                                builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                return;
                            }
                        }
                        else
                        {
                            awaiter = taskAwaiter;
                            taskAwaiter = default(TaskAwaiter<string>);
                            num = (firstState = -1);
                        }
                        result = awaiter.GetResult();
                    }
                    finally
                    {
                        if (num < 0 && httpClient != null)
                        {
                            ((IDisposable) httpClient).Dispose();
                        }
                    }
                }
                catch (Exception exception)
                {
                    firstState = -2;
                    builder.SetException(exception);
                    return;
                }
                firstState = -2;
                builder.SetResult(result);
            }

            void IAsyncStateMachine.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                this.MoveNext();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                builder.SetStateMachine(stateMachine);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }

        [AsyncStateMachine(typeof(ElidingStateMachine))]
        public Task<string> GetWithKeywordsAsync()
        {
            ElidingStateMachine stateMachine = default(ElidingStateMachine);
            stateMachine.builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine.firstState = -1;
            AsyncTaskMethodBuilder<string> builder = stateMachine.builder;
            builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }
    }
}
