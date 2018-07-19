using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISYS.Model;
using ISYS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddNSubtractAPI.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : BaseController
    {
        IRepository<Topic> _rep;
        public TopicController(IRepository<Topic> repository)
        {
            _rep = repository;
        }

        [Route("GetTopicById")]
        [HttpPost]
        public async Task<ActionResult> GetTopicById([FromBody]string courseName)
        {
            var topics = await _rep.GetById(courseName.ToString());
            return Ok(topics);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTopics()
        {
            var topic = await _rep.GetAll();
            //var recentPosts = await blogContext.Posts.Find(x => true)
            //    .SortByDescending(x => x.CreatedAtUtc)
            //    .Limit(10)
            //    .ToListAsync();

            //var model = new IndexModel
            //{
            //    RecentPosts = recentPosts
            //};

            return Ok(topic);
        }

        [HttpPost]
        public ActionResult NewPost()
        {
            return Ok();
        }

        //[HttpPost]
        //public async Task<ActionResult> NewPost(NewPostModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var blogContext = new BlogContext();
        //    var post = new Post
        //    {
        //        Author = User.Identity.Name,
        //        Title = model.Title,
        //        Content = model.Content,
        //        Tags = model.Tags.Split(' ', ',', ';'),
        //        CreatedAtUtc = DateTime.UtcNow,
        //        Comments = new List<Comment>()
        //    };

        //    await blogContext.Posts.InsertOneAsync(post);

        //    return RedirectToAction("Post", new { id = post.Id });
        //}

        //[HttpGet]
        //public async Task<ActionResult> Post(string id)
        //{
        //    var blogContext = new BlogContext();

        //    var post = await blogContext.Posts.Find(x => x.Id == id).SingleOrDefaultAsync();

        //    if (post == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var model = new PostModel
        //    {
        //        Post = post,
        //        NewComment = new NewCommentModel
        //        {
        //            PostId = id
        //        }
        //    };

        //    return View(model);
        //}

        //[HttpGet]
        //public async Task<ActionResult> Posts(string tag = null)
        //{
        //    var blogContext = new BlogContext();

        //    Expression<Func<Post, bool>> filter = x => true;

        //    if (tag != null)
        //    {
        //        filter = x => x.Tags.Contains(tag);
        //    }

        //    var posts = await blogContext.Posts.Find(filter)
        //        .SortByDescending(x => x.CreatedAtUtc)
        //        .Limit(10)
        //        .ToListAsync();

        //    return View(posts);
        //}

        //[HttpPost]
        //public async Task<ActionResult> NewComment(NewCommentModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Post", new { id = model.PostId });
        //    }

        //    var comment = new Comment
        //    {
        //        Author = User.Identity.Name,
        //        Content = model.Content,
        //        CreatedAtUtc = DateTime.UtcNow
        //    };

        //    var blogContext = new BlogContext();

        //    await blogContext.Posts.UpdateOneAsync(
        //        x => x.Id == model.PostId,
        //        Builders<Post>.Update.Push(x => x.Comments, comment));

        //    return RedirectToAction("Post", new { id = model.PostId });
        //}
    }
}