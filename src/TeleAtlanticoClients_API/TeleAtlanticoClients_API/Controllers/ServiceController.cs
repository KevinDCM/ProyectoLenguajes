using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleAtlanticoClients_API.Models;

namespace TeleAtlanticoClients_API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous] // not required login 
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ProyectoB61309_B74849Context _context;

        public ServiceController()
        {
            _context = new ProyectoB61309_B74849Context();

        }

        // GET: api/service/GetServices
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }



    }
}
