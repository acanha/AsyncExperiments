using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AsyncStandardLibrary
{
    public class CompilerGeneratedStateMachine
    {
        [StructLayout(LayoutKind.Auto)]
        [CompilerGenerated]
        private struct PrintAndWaitStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;
            public TimeSpan delay;
            private TaskAwaiter taskAwaiter;

            private void MoveNext()
            {
                int num = this.state;

                try
                {
                    TaskAwaiter awaiter;
                    switch (num)
                    {
                        default:
                            goto MethodStart;
                        case 0:
                            goto FirstAwaitContinuation;
                        case 1:
                            goto SecondAwaitContinuation;
                    }
                MethodStart:
                    Console.WriteLine("Before first delay");
                    awaiter = Task.Delay(this.delay).GetAwaiter();
                    if (awaiter.IsCompleted)
                    {
                        goto GetFirstAwaitResult;
                    }
                    this.state = num = 0;
                    this.taskAwaiter = awaiter;
                    this.builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                    return;

                FirstAwaitContinuation:
                    awaiter = this.taskAwaiter;
                    this.taskAwaiter = default(TaskAwaiter);
                    this.state = num = -1;

                GetFirstAwaitResult:
                    awaiter.GetResult();
                    Console.WriteLine("Between delays");
                    TaskAwaiter awaiter2 = Task.Delay(this.delay).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto GetSecondAwaitResult;
                    }
                    this.state = num = 1;
                    this.taskAwaiter = awaiter2;
                    this.builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                    return;

                SecondAwaitContinuation:
                    awaiter2 = this.taskAwaiter;
                    this.taskAwaiter = default(TaskAwaiter);
                    this.state = num = -1;

                GetSecondAwaitResult:
                    awaiter2.GetResult();
                    Console.WriteLine("After second delay");
                }
                catch (Exception exception)
                {
                    this.state = -2;
                    this.builder.SetException(exception);
                    return;
                }

                this.state = -2;
                this.builder.SetResult();
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

        [AsyncStateMachine(typeof(PrintAndWaitStateMachine))]
        public Task PrintAndWait(TimeSpan delay)
        {
            PrintAndWaitStateMachine stateMachine = default(PrintAndWaitStateMachine);
            stateMachine.delay = delay;
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            AsyncTaskMethodBuilder builder = stateMachine.builder;
            builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }
    }
}
