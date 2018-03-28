using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NTDCodeChallenge_MVC_CSharp.Models;
using NTDCodeChallenge_MVC_CSharp.HelperClasses;
using Newtonsoft.Json;

namespace NTDCodeChallenge_MVC_CSharp.Services
{
    public class PostsService : IPostsService
    {
        CSVHelper csv = new CSVHelper();
        public List<PostsModels> ImportCSV(string postedFile)
        {
            try
            {
                List<PostsModels> posts = new List<PostsModels>();
                string filepath = string.Empty;

                if (postedFile != null)
                {
                    //Read csv file. Skip header record
                    List<String> csvData = System.IO.File.ReadAllLines(postedFile).Skip(1).ToList();
                    //Loop through each row in csv file
                    foreach (string row in csvData)
                    {
                        ArrayList arList = csv.CSVParser(row);

                        posts.Add(new PostsModels
                        {
                            id = Convert.ToInt32(arList[0].ToString()),
                            title = arList[1].ToString(),
                            privacy = arList[2].ToString(),
                            likes = Convert.ToInt32(arList[3].ToString()),
                            views = Convert.ToInt32(arList[4].ToString()),
                            comments = Convert.ToInt32(arList[5].ToString()),
                            timestamp = arList[6].ToString()
                        });
                    }
                }
                return posts;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<PostsModels> TopPosts(List<PostsModels> posts)
        {
            try
            {
                return posts.Where(p => p.privacy.ToUpper() == "PUBLIC")
                            .Where(p => p.comments > 10)
                            .Where(p => p.views > 9000)
                            .Where(p => p.title.Length < 40).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<PostsModels> OtherPosts(List<PostsModels> posts)
        {
            try
            {
                return posts.Where(p => (p.privacy.ToUpper() != "PUBLIC" || p.comments <= 10 || p.views <= 9000 || p.title.Length >= 40)).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<PostsModels> DailyTopPost(List<PostsModels> posts)
        {
            try
            {
                var maxid = (from post in posts select Convert.ToInt32(post.id)).Max();
                return posts.Where(p => Convert.ToInt32(p.id) == maxid).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void ExportCSV(List<PostsModels> posts, string filePath)
        {
            try
            {
                using (var file = File.CreateText(filePath))
                {
                    //Write header record
                    string csvHeader = string.Format("id");
                    file.WriteLine(csvHeader);
                    //file.WriteLine();
                    foreach (PostsModels arr in posts)
                    {
                        string id = arr.id.ToString();
                        string csvRow = string.Format("{0}", id);
                        file.WriteLine(csvRow);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void ExportCSV(List<PostsModels> posts, string filePath, bool detailed)
        {
            try
            {
                using (var file = File.CreateText(filePath))
                {
                    //Write header record
                    string csvHeader = string.Format("id, title, privacy, likes, views, comments, timestamp");
                    file.WriteLine(csvHeader);
                    foreach (PostsModels arr in posts)
                    {
                        string csvRow = string.Format("{0},{1},{2},{3},{4},{5},{6}", arr.id, csv.formatString(arr.title), csv.formatString(arr.privacy), arr.likes, arr.views, arr.comments, csv.formatString(arr.timestamp));
                        file.WriteLine(csvRow);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void ExportJSON(List<PostsModels> posts, string filePath)
        {
            try
            {

                using (var file = File.CreateText(filePath))
                {
                    string json = JsonConvert.SerializeObject(posts.Select(p => p.id).ToArray());
                    file.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExportJSON(List<PostsModels> posts, string filePath, bool detailed)
        {
            try
            {
                using (var file = File.CreateText(filePath))
                {
                    string json = JsonConvert.SerializeObject(posts.ToArray());
                    file.WriteLine(json);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}