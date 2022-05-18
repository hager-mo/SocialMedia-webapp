using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class Comment
    {
        public int commentId { get; set; }
        public string commentContent { get; set; }
        public int postNum { get; set; }
        public string commentAuthor { get; set; }
    }
}