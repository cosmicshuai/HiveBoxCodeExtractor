using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HiveBoxCodeExtractor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HiveBoxCodeController : ControllerBase
    {
        private readonly ILogger<HiveBoxCodeController> _logger;

        public HiveBoxCodeController(ILogger<HiveBoxCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var codeEvent = new HiveCodeEvent
            {
                Date = DateTime.Now,
                Location = "MidSea Area 7 Building 16",
                BoxNumber = 3,
                openCode = "23114533",
                vendor = "SF Express"
            };

            return $"You have a new Packege, @{codeEvent.Location}, box: {codeEvent.BoxNumber}, code: {codeEvent.openCode}";
        }

        [HttpPost]
        public string Post()
        {
            return "";
        }
    }
}
