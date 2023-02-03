using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvcTextFiles.Controllers
{
    public class FilesController : Controller
    {

        private readonly IWebHostEnvironment _env;

        public FilesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            //get root folder path
            string WebRootPath = _env.WebRootPath;
            string contentRootPath = _env.ContentRootPath;
            string TextPath = Path.Combine(contentRootPath, "TextFiles");

            //get file paths of text files
            string[] TextFiles = Directory.GetFiles(TextPath);

            //turn file paths to text file names only
            for(int i = 0; i<TextFiles.Length; i++)
            {
                TextFiles[i] = Path.GetFileNameWithoutExtension(TextFiles[i]);
            }

            ViewBag.TextFiles = TextFiles;
            return View();
        }
        public IActionResult Content(int id)
        {
            string contentRootPath = _env.ContentRootPath;
            string TextPath = Path.Combine(contentRootPath, "TextFiles");
            string[] TextFiles = Directory.GetFiles(TextPath);
            string FileName = String.Empty;
            string FileContent = String.Empty;
            //for (int i = 0; i < TextFiles.Length; i++)
                //{
                //    if (i == FileNum)
                //    {
                //        FileContent = System.IO.File.ReadAllText(TextFiles[i]);
                //        FileName = Path.GetFileNameWithoutExtension(TextFiles[i]);
                //    }
                //}
            FileContent = System.IO.File.ReadAllText(TextFiles[id]);
            FileName = Path.GetFileNameWithoutExtension(TextFiles[id]);
            ViewBag.FileName = FileName;
            ViewBag.FileContent = FileContent;
            ViewBag.Number = id;



            return View();
        }
    }
}
