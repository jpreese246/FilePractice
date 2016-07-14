using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace FilePractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public FileStream AddToScript(string addToScript)
        {
            using (Stream input = System.IO.File.OpenRead(addToScript))
            using (Stream output = new FileStream("script.txt", FileMode.Append,
                                                  FileAccess.Write, FileShare.None))
            {
                input.CopyTo(output); // Using .NET 4
            }

            return (null);
        }

        //public FileResult SaveData(string fileName)

        //using (var mem = new MemoryStream())
        //{
            // Create spreadsheet based on widgetId...
            // Or get the path for a file on the server...

          //  return File(@"E:\Practice\FilePractice\src\\FilePractice\Views\Home\script.txt", "multipart /form-data", fileName);
        //}

        //Notice the parameter that you  now pass in
        //public FileResult SaveData()
        //{
        //  byte[] fileBytes = System.IO.File.ReadAllBytes(@"\folder\myfile.ext");
        //string fileName = "script.txt";
        //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        //todo: add some data from your database into that string:
        //var string_with_your_data = example;
        //using (Stream in = System.IO.File.OpenRead("script.txt"))

        //Build your stream
        //  var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
        //var stream = new MemoryStream(byteArray);

        //Returns a file that will match your value passed in (ie TestID2.txt)
        //return File(stream, "text/plain", String.Format("{0}.txt", example));
        //}


        [HttpGet]

        public FileContentResult downloadTextFile()
        {

            string filename = @"E:\Practice\FilePractice\src\FilePractice\script.txt";
            var bytes = System.IO.File.ReadAllBytes(filename);
            return File(bytes, "text/plain", "bigscript.bat");
            //string path = .MapPath("E:\\Practice\\FilePractice\\src\\FilePractice\\script.txt");
            //r//eturn File("script.txt", "text/plain");
        }

        [HttpPost]
       public ActionResult AddToBat(string addToBat)
        {
            System.IO.File.AppendAllText("E:\\Practice\\FilePractice\\src\\FilePractice\\bat.bat", "cmd /K \"C:\\Program Files\\Autodesk\\AutoCAD LT 2014\\acadlt.exe\" C:\\Users\\isundin\\" + addToBat + "Desktop\\Scripts\\ZP-EW21-1.dwg /b Schematics.scr");
            return RedirectToAction("Index");
        }
    }
}
