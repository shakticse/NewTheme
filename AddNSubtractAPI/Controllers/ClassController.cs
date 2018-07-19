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
    public class ClassController : BaseController
    {
        IRepository<Class> _rep;
        public ClassController(IRepository<Class> repository)
        {
            _rep = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClass()
        {
            try
            {
                var res = await _rep.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }        
    }
}