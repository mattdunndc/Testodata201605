using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adventure.WebAPI.Models
{

    public class Tweet
    {
        [Key]
        public string ScreenName { get; set; }
        public string UserName { get; set; }
        public string Msg { get; set; }
        public int? FavoriteCount { get; set; }
        public int? RetweetCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        public string MediaUrl { get; set; }


    }
}