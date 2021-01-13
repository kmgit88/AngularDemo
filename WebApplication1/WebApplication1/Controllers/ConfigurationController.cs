using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    public class ConfigurationDto
    {
        public string ApiAddress { get; set; }
    }
    public class ConfigurationController : Controller
    {
        private readonly IConfiguration _configuration;
        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public IActionResult ConfigurationData()
        {
            var result = new ConfigurationDto { ApiAddress = _configuration["ApiAddress"] };
            return Ok(result);
        }
    }
}