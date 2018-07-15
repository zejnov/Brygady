using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Brygady2.Models;

namespace Brygady2.Controllers
{

    [Produces("application/json")]
    [Route("api/lampy.json")]
    [ApiController]
    public class GPSapiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public GPSapiController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/GPSapi
        [HttpGet]
        public IEnumerable<GPSs> GetGPSs()
        {
            return _context.GPSs;
        }
    }
}