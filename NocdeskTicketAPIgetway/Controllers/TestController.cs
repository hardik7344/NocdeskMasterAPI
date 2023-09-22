using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NocdeskTicketAPIgetway.Controllers
{
    [Route("NocdeskTicket/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //GET:NocdeskTicket/Test/Get
        [HttpGet]
        public string Get()
        {
            return "Welcome to Nocdesk Ticket Api";
        }
    }
}