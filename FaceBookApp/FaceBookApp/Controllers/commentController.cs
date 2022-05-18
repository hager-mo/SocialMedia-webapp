using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceBookApp.Models;
using FaceBookApp.ViewModels;


namespace FaceBookApp.Controllers
{
    public class commentController : Controller
    {
        private ApplicationDbContext _context;

        public commentController()
        {
            _context = new ApplicationDbContext();
        }



        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [HttpPost]
        public ActionResult addComment(UserFreindsPostsViewModel vm)
        {
            Comment comment = new Comment()
            {
                postNum = vm.comment.postNum,
                commentContent = vm.comment.commentContent,
                commentAuthor = vm.comment.commentAuthor
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("displayFriendsProfileDetails", "User");
        }




        public ActionResult addCommentMyprofile(UserFreindsPostsViewModel vm)
        {
            Comment comment = new Comment()
            {
                postNum = vm.comment.postNum,
                commentContent = vm.comment.commentContent,
                commentAuthor = vm.comment.commentAuthor
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("displayMyProfilePage", "User");
        }
    }
}