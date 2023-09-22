using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NocdeskAPIgetway.Controllers
{
    [Route("Nocdesk/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //GET:Nocdesk/Test/Get
        [HttpGet]
        public string Get()
        {
            return "Welcome to Nocdesk Web Api";
        }
    }
}