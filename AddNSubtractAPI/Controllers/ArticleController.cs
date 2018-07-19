﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISYS.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AddNSubtractAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : BaseController
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("SavePost")]
        public string Post([FromBody]Post post)
        {
            //Post posted = JsonConvert.DeserializeObject<Post>(post.ToString());
            return "created";
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
