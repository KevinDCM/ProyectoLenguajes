using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleAtlanticoClients_API.Models;

namespace TeleAtlanticoClients_API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ProyectoB61309_B74849Context _context;

        public ClientController()
        {
            _context = new ProyectoB61309_B74849Context();

        }

        // GET: api/client/GetClients
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/client/GetClient/id
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Client>> Getclient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }


        //// POST: api/client/      
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client student)
        {
            _context.Clients.Add(student);
            await _context.SaveChangesAsync();

            return Ok();

        }


        [EnableCors("GetAllPolicy")]
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostSP(Client client)
        {
                var result = _context.Database.ExecuteSqlRaw("InsertClient {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                                client.Name,
                                client.Firstsurname,
                                client.Secondsurname,
                                client.Phonenumber,
                                client.Secondcontact,
                                client.Email,
                                client.Fulladdress,
                                client.Password
                );

                return Ok(result);
        }

        [Route("[action]")]
        //[HttpGet("email={email}&password={password}")]
        // GET: api/client/GetStudentToAuthenticate?email=ss&password=ss
        public Client GetClientToAuthenticate(string email, string password)
        {

            try
            {
                var client_ = _context.Clients.Where(a => a.Email.Equals(email) && a.Password.Equals(password)).Single();
                return client_;

            }
            catch
            {
                throw new InvalidOperationException("An error has ocurred!");
            }

        }


    }

}