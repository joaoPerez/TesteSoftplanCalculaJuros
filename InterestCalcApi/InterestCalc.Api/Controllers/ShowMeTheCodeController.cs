using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InterestCalc.Api.Controllers
{
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ShowMeTheCodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/ShowMeTheCode
        [HttpGet]
        [Route("showmethecode")]
        public Dictionary<string, string> Get()
        {
            string InterestRateUrl = _configuration.GetSection("UrlInterestRate").Value;
            string CompoundInterestUrl = _configuration.GetSection("UrlCompoundCalc").Value;

            Dictionary<string, string> urls = new Dictionary<string, string>
            {
                { "Taxa de juros", InterestRateUrl },
                { "Calculo juros compostos", CompoundInterestUrl }
            };

            return urls;
        }
    }
}
