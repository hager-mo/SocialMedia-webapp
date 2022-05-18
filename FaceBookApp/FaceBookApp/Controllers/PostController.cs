using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceBookApp.Models;
using FaceBookApp.ViewModels;

namespace FaceBookApp.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _context;

        public PostController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult addPost() {
            int id = (int)Session["userID"];
            var userPost = new PostandUserViewModel()
            {
                user = _context.Users.SingleOrDefault(c => c.userId == id)
        };

            return View(userPost);
        }   
        
        


        [HttpPost]
        public ActionResult publishPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("displayFriendsProfileDetails", "User",new { id = post.postAuthor });
        }

        [HttpPost]
        public void hideOrViewPost(int id, bool hidden)
        {
            var post = _context.Posts.SingleOrDefault(p => p.postId == id);

            if (hidden)
                post.postHidden = false;
            else
                post.postHidden = true;

            _context.SaveChanges();
        }
        [HttpPost]
        public void likePostAjax (int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.postId == id);
            post.postLikes += 1;
            _context.SaveChanges();

        }
        [HttpPost]
        public void dislikePostAjax(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.postId == id);
            post.postDislikes += 1;
            _context.SaveChanges();

        }



    }
}