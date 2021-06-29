using System;
using System.Text.RegularExpressions;
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

        [Route("api/getCode")]
        [HttpGet]
        public string GetBoxCode([FromQuery]string content)
        {
            //【丰巢】凭取件码63610565至海悦花园七区16幢架空层3号丰巢取中通快递包裹。有疑问联系快递员13732531641
            //【丰巢】凭取件码29699459至海悦花园七区16幢架空层2号丰巢柜取中通快递包裹。有疑问联系快递员13732531641
            Regex fcRegex = new(@"^【丰巢】.*凭取件码([0-9]{8})至(.*)丰巢.*包裹。.*");
            if (fcRegex.IsMatch(content))
            {
                var matched = fcRegex.Match(content);
                var code = matched.Groups[1].Value;
                var location = matched.Groups[2].Value;
                return code + "  ||  " + location + "  || " + DateTime.Now.Date.ToString("d");
            }

            //【菜鸟驿站】您的中通包裹已到苏州海悦花园七区物业店，请21:00前凭3-1-2009取件，详询13451534429
            Regex cnRegex = new(@"^【菜鸟驿站】.*到(.*)，请.*凭(\d-\d-\d{4})取件，.*");
            if (cnRegex.IsMatch(content))
            {
                var matched = cnRegex.Match(content);
                var code = matched.Groups[2].Value;
                var location = matched.Groups[1].Value;
                return code + "  ||  " + location + "  || " + DateTime.Now.Date.ToString("d");
            }

            return "Not Valid";
        }
    }
}
