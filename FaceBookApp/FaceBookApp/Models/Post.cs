using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class Post
    {
        public int postId { get; set; }
        public string postContent { get; set; }
        public bool postHidden { get; set; }
        public List<string> postComments { get; set; }
        public int postLikes { get; set; }
        public int postDislikes { get; set; }

        public int postAuthor { get; set; }
        public User user { get; set; }

    }
}