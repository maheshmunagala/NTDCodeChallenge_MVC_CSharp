using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTDCodeChallenge_MVC_CSharp.Models;
using NTDCodeChallenge_MVC_CSharp.Services;

namespace NTDCodeChallenge_MVC_CSharp.Controllers
{
    public class PostsController : Controller
    {
        private IPostsService service;

        public PostsController(IPostsService service)
        {
            this.service = service;
        }
        // GET: posts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(HttpPostedFileBase postedFile, string OutputType, bool Detailed=false)
        {
            try
            {
                string filepath = string.Empty;
                if (postedFile != null && postedFile.FileName.Contains(".csv"))
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filepath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filepath);
                    List<PostsModels> posts = this.service.ImportCSV(filepath);
                    Analyze(posts, OutputType, Detailed);
                }
                else
                    TempData["Message"] = "Select the CSV file to import";

                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Analyze(List<PostsModels> posts, string OutputType, bool detailed)
        {
            try
            {
                string filePath = Server.MapPath("~/Output/");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (OutputType == "json")
                {
                    if (detailed)
                    {
                        this.service.ExportJSON(this.service.TopPosts(posts), filePath + "TopPostsJSON.txt", true);
                        this.service.ExportJSON(this.service.OtherPosts(posts), filePath + "OtherPostsJSON.txt", true);
                        this.service.ExportJSON(this.service.DailyTopPost(posts), filePath + "DailyTopPostsJSON.txt", true);
                        TempData["Message"] = "JSON Output exported to the folder \n" + filePath;
                    }
                    else
                    {
                        this.service.ExportJSON(this.service.TopPosts(posts), filePath + "TopPostsJSON.txt");
                        this.service.ExportJSON(this.service.OtherPosts(posts), filePath + "OtherPostsJSON.txt");
                        this.service.ExportJSON(this.service.DailyTopPost(posts), filePath + "DailyTopPostsJSON.txt");
                        TempData["Message"] = "JSON Output (ID column ONLY) exported to the folder \n" + filePath;
                    }
                }
                else if (OutputType == "csv")
                {
                    if (detailed)
                    {
                        this.service.ExportCSV(this.service.TopPosts(posts), filePath + "TopPosts.csv", true);
                        this.service.ExportCSV(this.service.OtherPosts(posts), filePath + "OtherPosts.csv", true);
                        this.service.ExportCSV(this.service.DailyTopPost(posts), filePath + "DailyTopPosts.csv", true);
                        TempData["Message"] = "CSV detailed Output exported to the folder \n" + filePath;
                    }
                    else
                    {
                        this.service.ExportCSV(this.service.TopPosts(posts), filePath + "TopPosts.csv");
                        this.service.ExportCSV(this.service.OtherPosts(posts), filePath + "OtherPosts.csv");
                        this.service.ExportCSV(this.service.DailyTopPost(posts), filePath + "DailyTopPosts.csv");
                        TempData["Message"] = "CSV Output (ID column ONLY) exported to the folder \n" + filePath;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}