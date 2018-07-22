using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISYS.Model;
using ISYS.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AddNSubtractAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : BaseController
    {
        IRepository<Post> _rep;
        public ArticleController(IRepository<Post> repository)
        {
            _rep = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet]
        [Route("GetPost/{id}")]
        public async Task<Post> Get(string id)
        {
            var post = await _rep.Get(id);
            return post;
        }

        [HttpPost]
        [Route("SavePost")]
        public async Task<Result> Post([FromBody]Post post)
        {
            //Post posted = JsonConvert.DeserializeObject<Post>(post.ToString());
            post.CreatedAtUtc = DateTime.UtcNow;
            post.Comments = new List<Comment>();
            var res = await _rep.Insert(post);
            return res;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
