using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTDCodeChallenge_MVC_CSharp.Services;
using NTDCodeChallenge_MVC_CSharp.HelperClasses;
using NTDCodeChallenge_MVC_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;

namespace NTDCodeChallenge_MVC_CSharp.Services.Tests
{
    [TestClass()]
    public class PostsServiceTests
    {
        string filePath = @"C:\Users\mrm97\Documents\visual studio 2015\Projects\NTDCodeChallenge_MVC_CSharp\NTDCodeChallenge_MVC_CSharp\Uploads\posts.csv";
        string outputfilePath = @"C:\Users\mrm97\Documents\visual studio 2015\Projects\NTDCodeChallenge_MVC_CSharp\NTDCodeChallenge_MVC_CSharp\Output\";

        [TestMethod()]
        public void ExportCSVTest()
        {
            PostsModels posts = new PostsModels();
            posts.id = 2;
            posts.title = "\"t,e,s,t,1\"";
            posts.likes = 2;
            posts.comments = 2;
            posts.privacy = "test1";
            posts.views = 2;
            posts.timestamp = "2018-03-27";
            List<PostsModels> list = new List<PostsModels>() { posts };
            PostsService service = new PostsService();
            service.ExportCSV(list, outputfilePath + "ExportCSVTest.csv");
            service.ExportCSV(list, outputfilePath + "ExportCSVTestDetailed.csv", true);
        }

        [TestMethod()]
        public void ExportCSVTest1()
        {
            PostsModels posts = new PostsModels();
            posts.id = 2;
            posts.title = "Shut Up, Mom! Disrespectful Kids";
            posts.likes = 2;
            posts.comments = 2;
            posts.privacy = "test1";
            posts.views = 2;
            posts.timestamp = "2018-03-27";
            List<PostsModels> list = new List<PostsModels>() { posts };
            PostsService service = new PostsService();
            service.ExportCSV(list, outputfilePath + "ExportCSVTest.csv");
            service.ExportCSV(list, outputfilePath + "ExportCSVTestDetailed.csv", true);
        }

        [TestMethod()]
        public void ImportCSVTest()
        {
            PostsService service = new PostsService();
            List<PostsModels> posts =  service.ImportCSV(filePath);
            Assert.AreEqual(posts.Count, 1985);
        }

        [TestMethod()]
        public void TopPostsTest()
        {
            PostsService service = new PostsService();
            List<PostsModels> posts = service.ImportCSV(filePath);
            List<PostsModels> topposts = service.TopPosts(posts);
            Assert.AreEqual(topposts.Count, 347);                
        }

        [TestMethod()]
        public void OtherPostsTest()
        {
            PostsService service = new PostsService();
            List<PostsModels> posts = service.ImportCSV(filePath);
            List<PostsModels> OtherPosts = service.OtherPosts(posts);
            Assert.AreEqual(OtherPosts.Count, 1638);
        }

        [TestMethod()]
        public void DailyTopPostTest()
        {
            PostsService service = new PostsService();
            var posts = service.ImportCSV(filePath);
            var dailyTopPosts = service.DailyTopPost(posts);
            Assert.AreEqual(dailyTopPosts.Count, 1);
        }

        [TestMethod()]
        public void ExportJSONTest()
        {
            PostsModels posts = new PostsModels();
            posts.id = 1;
            posts.title = "test1";
            posts.likes = 1;
            posts.comments = 1;
            posts.privacy = "test1";
            posts.views = 1;
            posts.timestamp = "2018-03-27";
            List<PostsModels> list = new List<PostsModels>() { posts };
            PostsService service = new PostsService();
            service.ExportJSON(list, outputfilePath + "ExportJSONTest.txt");
            service.ExportJSON(list, outputfilePath + "ExportJSONTestDetailed.txt", true);

        }
    }
}