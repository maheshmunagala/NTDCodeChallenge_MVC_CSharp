using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NTDCodeChallenge_MVC_CSharp.Models;

namespace NTDCodeChallenge_MVC_CSharp.Services
{
    public interface IPostsService
    {
        List<PostsModels> ImportCSV(string fileName);
        List<PostsModels> TopPosts(List<PostsModels> posts);
        List<PostsModels> OtherPosts(List<PostsModels> posts);
        List<PostsModels> DailyTopPost(List<PostsModels> posts);
        void ExportCSV(List<PostsModels> posts, string fileName);
        void ExportCSV(List<PostsModels> posts, string fileName, bool detailed);
        void ExportJSON(List<PostsModels> posts, string filePath);
        void ExportJSON(List<PostsModels> posts, string filePath, bool detailed);
    }
}