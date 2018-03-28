using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTDCodeChallenge_MVC_CSharp.Models
{
    public class PostsModels
    {
        public int id { get; set; }
        public string title { get; set; }
        public string privacy { get; set; }
        public int likes { get; set; }
        public int views { get; set; }
        public int comments { get; set; }
        public string timestamp { get; set; }
    }
}