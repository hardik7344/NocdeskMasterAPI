using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NocdeskFirstLevalApi.Controllers
{
    [Route("NocdeskFristLeval/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //GET:NocdeskFristLeval/Test/GetFristLeval
        [HttpGet]
        public string GetFristLeval()
        {
            return "Welcome to Nocdesk FristLeval Web Api";
        }
    }
}