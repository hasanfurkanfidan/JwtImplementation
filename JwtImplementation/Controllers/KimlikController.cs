using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KimlikController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GirisYap()
        {
          
            return Created("",new TokenOlusturucu().TokenAdminRolOlustur());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Erisim()
        {
            return Ok("token geçti");
        }

    }
}
