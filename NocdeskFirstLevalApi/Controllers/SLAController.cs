using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NocdeskFirstLevalApi.BusinessLogic;
using NocdeskFirstLevalApi.Model;

namespace NocdeskFirstLevalApi.Controllers
{
    [Route("NocdeskFristLeval/[controller]/[action]")]
    [ApiController]
    public class SLAController : ControllerBase
    {
        SLA objNocdesk = new SLA();
        DataTable dt = new DataTable();

        #region SLA

        // GET: NocdeskFristLeval/SLA/GetSLADetails
        [HttpGet("{Doctype}")]
        public async Task<DataTable> GetSLADetails(string Doctype)
        {
            dt = await objNocdesk.GetSLADetails(Doctype);
            return dt;
        }
        // GET: NocdeskFristLeval/SLA/AddSLA
        [HttpPost]
        public async Task<DataTable> AddSLA([FromBody] ParameterJSON objParam)
        {
            dt = await objNocdesk.AddSLA(objParam.user_json);
            return dt;
        }
        //Post: NocdeskFristLeval/SLA/AddSLALLinkag
        [HttpPost]
        public async Task<DataTable> AddSLALLinkag([FromBody] ParameterJSON objParam)
        {
            dt = await objNocdesk.AddSLALLinkag(objParam.user_json);
            return dt;
        }
        // GET: NocdeskFristLeval/SLA/DeleteSLA
        [HttpGet("{DocumentID}")]
        public async Task<DataTable> DeleteSLA(string DocumentID)
      {
            dt = await objNocdesk.DeleteSLA(DocumentID);
            return dt;
        }
        #endregion
    }
}