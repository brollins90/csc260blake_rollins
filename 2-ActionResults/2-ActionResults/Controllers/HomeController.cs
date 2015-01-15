using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2_ActionResults.Models;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization;

namespace _2_ActionResults.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Home
        public ActionResult Index(Character character)
        {
            return View(character);
        }

        public ContentResult GetCharacterString(Character character)
        {
            return Content(character.ToString(), "text/html");
        }

        public JsonResult GetCharacterJson(Character character)
        {
            return Json(character, JsonRequestBehavior.AllowGet);
        }

        public ContentResult GetCharacterXml(Character character)
        {
            return Content(Serialize(character), "text/xml");
        }

        public FileResult GetFile()
        {
            return File("/Content/Images/MaleFighter.png", "image/png", "MaleFighter.png");
        }

        public HttpStatusCodeResult NotFound()
        {
            return new HttpNotFoundResult();
        }

        public static string Serialize<T>(T item)
        {
            MemoryStream memStream = new MemoryStream();
            using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(textWriter, item);

                memStream = textWriter.BaseStream as MemoryStream;
            }
            if (memStream != null)
                return Encoding.Unicode.GetString(memStream.ToArray());
            else
                return null;
        }

    }
}