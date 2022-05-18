using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        [FileExtensions(Extensions ="jpg,jpeg,png" )]
        [DataType(DataType.ImageUrl)]
        public byte[] userProfileImage { get; set; }
        public string userCountry { get; set; }
        public string userCity { get; set; }
        public int? userMobileNumber { get; set; }
         public string userEmail { get; set; } 
        public string userPassword { get; set; }
        public List<Post> posts { get; set; } 
    }
}