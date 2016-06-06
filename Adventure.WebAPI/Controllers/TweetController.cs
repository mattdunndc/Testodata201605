using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LinqToTwitter;
using Newtonsoft.Json;
using Adventure.WebAPI.Models;
//using _20160215webapi.Models;

namespace _20160215webapi.Controllers
{
    public class TweetController : ApiController
    {
        // GET api/values
        // GET: api/Tweet
        [Route("~/api/tweets/{userName}")]
        public IHttpActionResult Get(string userName)
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                    AccessToken = ConfigurationManager.AppSettings["accessToken"],
                    AccessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"]
                }
            };

            var ctx = new TwitterContext(auth);
            IEnumerable<Tweet> tweets = new List<Tweet>();
            tweets =
                    (from t in ctx.Status
                         //where t.Type == StatusType.User &&
                         //      t.ScreenName == userName &&
                         //      t.Count == 20
                         ///////////////
                     where t.Type == StatusType.Home &&
                           t.ScreenName == userName &&
                           t.Count == 20
                     select new Tweet
                     {
                         ImageUrl = t.User.ProfileImageUrl,
                         ScreenName = t.User.ScreenNameResponse,
                         UserName = t.User.Name,
                         Msg = t.Text,
                         CreatedAt = t.CreatedAt,
                         FavoriteCount = t.FavoriteCount,
                         RetweetCount = t.RetweetCount
                     }
                     //
                     //select t
                     )
                     .ToList();

            if (tweets != null) //.ToListAsync() doesn't return json root element but the tweets array does!!
            {
                var newtweets = new { tweets };
                return Ok(tweets);
            }

            else
                return NotFound();
        }

        ////http://localhost:55555/api/tweets/mattdunndc
        // GET: api/Tweet
        [Route("~/api/tweets2/{userName}")]
        public async Task<IHttpActionResult> GetTweetsByUser(string userName)
        {
            //using (var ctx = new NorthwindSlimContext())
            //{
            //    List<Product> products = await
            //        (from p in ctx.Products.Include("Category")
            //         orderby p.ProductName
            //         select p).ToListAsync();
            //    return products;
            //}
            //
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                    AccessToken = ConfigurationManager.AppSettings["accessToken"],
                    AccessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"]
                }
            };
            
            var ctx = new TwitterContext(auth);
            var tweets =
                await
                    (from t in ctx.Status
                     where t.Type == StatusType.User &&
                           t.ScreenName == userName &&
                           t.Count == 20
                     select new Tweet
                     {
                         //ImageUrl = t.User.ProfileImageUrl,
                         /////ScreenName = t.User.ScreenNameResponse,
                         ScreenName = t.User.ScreenNameResponse,
                         UserName = t.User.Name,          
                         Msg = t.Text,
                         CreatedAt = t.CreatedAt,
                         FavoriteCount = t.FavoriteCount,
                         RetweetCount = t.RetweetCount
                     }
                     //
                     //select t
                         )
                        .ToListAsync();

            if (tweets != null) //.ToListAsync() doesn't return json root element but the tweets array does!!
            {
                var newtweets = new { tweets } ;
                return Ok(tweets);
            }
            
            else
                return NotFound();

        }
        
        // GET: api/Tweet/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tweet
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tweet/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tweet/5
        public void Delete(int id)
        {
        }
    }
}
