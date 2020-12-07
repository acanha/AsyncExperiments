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

            stateMachine.builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }


        [StructLayout(LayoutKind.Auto)]
        [CompilerGenerated]
        private struct PrintAndWaitStateMachineFast : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;
            private TaskAwaiter<int> taskAwaiter;

            private void MoveNext()
            {
                int num = this.state;

                try
                {
                    TaskAwaiter<int> awaiter;
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
                    awaiter = Task.FromResult(5).GetAwaiter();
                    // Hot path optimization: if the task is completed, the state machine automatically moves to the next step
                    // This means that if all awaited tasks are already completed the entire state machine will stay on the stack.
                    if (awaiter.IsCompleted)
                    {
                        goto GetFirstAwaitResult;
                    }
                    this.state = num = 0;
                    this.taskAwaiter = awaiter;
                    // The following call will eventually cause boxing of the state machine.
                    this.builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                    return;

                FirstAwaitContinuation:
                    awaiter = this.taskAwaiter;
                    this.taskAwaiter = default(TaskAwaiter<int>);
                    this.state = num = -1;

                GetFirstAwaitResult:
                    awaiter.GetResult();
                    Console.WriteLine("Between delays");
                    TaskAwaiter<int> awaiter2 = Task.FromResult(5).GetAwaiter();
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
                    this.taskAwaiter = default(TaskAwaiter<int>);
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

        [AsyncStateMachine(typeof(PrintAndWaitStateMachineFast))]
        public Task PrintAndWaitFast()
        {
            PrintAndWaitStateMachineFast stateMachine = default(PrintAndWaitStateMachineFast);
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            AsyncTaskMethodBuilder builder = stateMachine.builder;
            //Passing by reference is an important optimization,
            //because a state machine tends to be fairly large struct (>100 bytes) and passing it by reference
            //avoids a redundant copy.
            //It also ensures that any changes made to the state within the Start() method are still visible when
            // the Start() method returns
            builder.Start(ref stateMachine);
            return stateMachine.builder.Task;
        }
    }
}
