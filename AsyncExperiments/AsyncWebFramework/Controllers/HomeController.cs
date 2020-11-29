using AsyncStandardLibrary;
using AsyncWebFramework.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncWebFramework.Controllers
{
    public class HomeController : Controller
    {
        private const string URL = "https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AsyncVoid()
        {
            return View();
        }

        public ActionResult ElidingIndex()
        {
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }

        #region async void
        public ActionResult CallAsyncVoid()
        {
            var asyncVoid = new AsyncVoid();
            asyncVoid.CallAsyncVoid();

            return View();
        }

        public ActionResult CallAsyncVoidWithException()
        {
            var asyncVoid = new AsyncVoid();
            asyncVoid.CallAsyncVoidWithException();

            return View();
        }
        #endregion

        #region .Result
        public ActionResult WithResult()
        {
            var result = new Result();
            var number = result.GetNumberAsync();
            return View(number.Result);
        }

        public async Task<ActionResult> Parallelism()
        {
            var result = new Result();
            var number = await result.GetBothAsync("https://jsonplaceholder.typicode.com/todos/1", "https://jsonplaceholder.typicode.com/todos/2");
            return View(number);
        }

        public  ActionResult Deadlock()
        {
            var result = new Result();
            var number =  result.DownloadStringV5("https://jsonplaceholder.typicode.com/todos/1");
            return View(number);
        }
        #endregion

        #region Eliding
        public async Task<ActionResult> WithoutEliding()
        {
            var result = await Eliding.GetWithKeywordsAsync();

            return View(new MyViewModel { Text = result });
        }

        public async Task<ActionResult> WithEliding()
        {
            var result = await Eliding.GetElidingKeywordsAsync();

            return View(new MyViewModel { Text = result });
        }

        public async Task<ActionResult> WithElidingTry()
        {
            var result = await Eliding.GetElidingKeywordsWithTryAsync();

            return View(new MyViewModel { Text = result });
        }

        public async Task<ActionResult> DebugEliding()
        {
            var compilerCode = new TaskElidingCompilerGeneratedCode();
            var text = await compilerCode.GetElidingKeywordsAsync();

            return View(new MyViewModel { Text = text });
        }

        public async Task<ActionResult> DebugWithoutEliding()
        {
            var compilerCode = new TaskWithoutElidingCompilerGeneratedCode();
            var text = await compilerCode.GetWithKeywordsAsync();

            return View(new MyViewModel { Text = text });
        }

        public async Task<ActionResult> DebugStateMachine()
        {
            var compilerCode = new CompilerGeneratedStateMachine();
            await compilerCode.PrintAndWait(TimeSpan.FromSeconds(1));

            return View("DebugWithoutEliding",new MyViewModel { Text = "Success" });
        }

        public async Task<ActionResult> DebugStateMachineFast()
        {
            var compilerCode = new CompilerGeneratedStateMachine();
            await compilerCode.PrintAndWaitFast();

            return View("DebugWithoutEliding", new MyViewModel { Text = "Success" });
        }

        public async Task<ActionResult> WithElidingException()
        {
            var task =  Eliding.GetElidingKeywordsExceptionAsync();
            var result = await task;
            return View(new MyViewModel { Text = result });
        }

        public async Task<ActionResult> WithoutElidingException()
        {
            var task =  Eliding.GetWithKeywordsExceptionAsync();
            var result = await task;
            return View(new MyViewModel { Text = result });
        }

        public async Task<ActionResult> ElidingStackTrace()
        {
            try
            {
                await Eliding.Top(elide: true);
            }
            catch (Exception e)
            {
                return View(new MyViewModel { Text = e.StackTrace });
            }
            
            return View(new MyViewModel { Text = "" });
        }

        public async Task<ActionResult> WithoutElidingStackTrace()
        {
            try
            {
                await Eliding.Top(elide: false);
            }
            catch (Exception e)
            {
                return View(new MyViewModel { Text = e.StackTrace });
            }

            return View(new MyViewModel { Text = "" });
        }

        public async Task<ActionResult> AsyncLocalWithouEliding()
        {
            await Eliding.AsyncLocalWithoutEliding();

            return View(new MyViewModel { Text = "" });
        }

        public async Task<ActionResult> AsyncLocalEliding()
        {
            await Eliding.AsyncLocalEliding();

            return View(new MyViewModel { Text = "" });
        }
        #endregion
    }
}