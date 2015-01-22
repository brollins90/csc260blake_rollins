using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScratchMVC5.Models;

namespace ScratchMVC5.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quiz(string quizType)
        {
            //var q = Activator.CreateInstance(null, "ScratchMVC5.Models." + quizType);
            //if (q == null)
            //{
            //    return View("Index");
            //}
            //return View(q);
            if (quizType.Equals("car"))
            {
                return View(new Car());
            }

            else if (quizType.Equals("unicycle"))
            {
                return View(new Unicycle());
            }
            else
            {
                return View("Index");
            } 


        }
    }
}