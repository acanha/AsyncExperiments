using AsyncStandardLibrary;
using AsyncWebFramework.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncWebFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Result()
        {
            var result = new Result();
            var number = result.GetNumberAsync().Result;
            return View(number);
        }

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