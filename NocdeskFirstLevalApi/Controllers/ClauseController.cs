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
    public class ClauseController : ControllerBase
    {
        Clause objNocdesk = new Clause();
        DataTable dt = new DataTable();
        #region Clause

        // GET: NocdeskFristLeval/Clause/GetClauseDetails
        //[HttpGet("{DocumentID}/{DocumentType}")]
        [HttpGet("{DocumentID}/{DocumentType}")]
        public async Task<DataTable> GetClauseDetails(string DocumentID, string DocumentType)
        {
            dt = await objNocdesk.GetClauseDetails(DocumentID, DocumentType);
            return dt;
        }
        // GET: NocdeskFristLeval/Clause/AddClause
        [HttpPost]
        public async Task<DataTable> AddClause([FromBody] ParameterJSON objParam)
        {
            dt = await objNocdesk.AddClause(objParam.user_json);
            return dt;
        }
        // GET: NocdeskFristLeval/Clause/DeleteClause
        [HttpGet("{DocumentID}")]
        public async Task<DataTable> DeleteClause(string DocumentID)
        {
            dt = await objNocdesk.DeleteClause(DocumentID);
            return dt;
        }
        #endregion
    }
}