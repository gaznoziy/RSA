using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rsa_api.Services;

namespace rsa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {
        private readonly IRSAService _rsaService;

        public RSAController(IRSAService rsaService)
        {
            _rsaService = rsaService;
        }

        [HttpGet("get-rsa-keys")]
        [ProducesResponseType(typeof(KeysViewModel), StatusCodes.Status200OK)]
        public IActionResult GetRSAKeys()
        {
            var result = _rsaService.GetRandomRSAKeys();

            return Ok(result);
        }
    }
}