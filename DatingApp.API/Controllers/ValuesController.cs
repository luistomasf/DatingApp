using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public ValuesController(DataContext dbcontext)
        {
           _dbcontext = dbcontext;
        }

        //GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _dbcontext.Values.ToListAsync();

            return Ok(values);
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetValues(int id)
        {
           var values = await  _dbcontext.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(values);
        }

        //POST api/values
        [HttpPost]
        public void Post([FromForm] string value)
        {
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
        }

        //Delete api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}