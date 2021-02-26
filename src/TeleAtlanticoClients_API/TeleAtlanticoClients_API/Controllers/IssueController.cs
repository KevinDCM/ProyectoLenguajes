using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TeleAtlanticoClients_API.Models;

namespace TeleAtlanticoClients_API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly ProyectoB61309_B74849Context _context;

        public IssueController()
        {
            _context = new ProyectoB61309_B74849Context();

        }

        // GET: api/issue/GetIssues/id
        [EnableCors("GetAllPolicy")]
        [Route("[action]/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetIssues(int id)
        {

            var id_ = new SqlParameter("@clientid", id);
            var issues = _context.Clients
                           .FromSqlRaw($"GetIssuesByClientId @clienteid", id_)
                           .AsEnumerable().Single();

            if (issues == null)
            {
                return NotFound();
            }

            return Ok(issues);
        }

        // GET: api/issue/GetIssue/id
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }


        //// POST: api/issue/      
        [HttpPost]
        public async Task<ActionResult<Issue>> Post(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return Ok();

        }

        //// PUT FROM STORED PROCEDURE
       
        //[EnableCors("GetAllPolicy")]
        //[HttpPut]
        //public IActionResult Put(Issue issue)
        //{

        //    var result = _context.Database.ExecuteSqlRaw("UpdateStudentById {0}, {1}, {2}, {3}",
        //                        issue.attr1, issue.attr2);
        //    if (result == 0)
        //    {
        //        return null;
        //    }

        //    return Ok(result);
        //}

        //// PUT: api/issue/   // with id ?
        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> PutIssue(Issue issue)
        {

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
              
                return NotFound();
         
            }

            return NoContent();
        }


    }

}