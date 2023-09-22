using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NocdeskFirstLevalApi.BusinessLogic;
using NocdeskFirstLevalApi.Model;
using OwnYITCommon;

namespace NocdeskFirstLevalApi.Controllers
{
    [Route("NocdeskFristLeval/[controller]/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        Contract objNocdesk = new Contract();
        DataTable dt = new DataTable();
        
        #region Contract
        // GET the Document Master 
        // GET: NocdeskFristLeval/Contract/GetContractDetails
        [HttpGet("{Doctype}")]
        public async Task<DataTable> GetContractDetails(string Doctype)
        {
            dt = await objNocdesk.GetContractDetails(Doctype);
            return dt;
        }
        // GET: NocdeskFristLeval/Contract/AddContract
        [HttpPost]
        public async Task<DataTable> AddContract([FromBody] ParameterJSON objParam)
        {
            dt =await objNocdesk.AddContract(objParam.user_json);
            return dt;
        }
        // GET: NocdeskFristLeval/Contract/DeleteContract
        [HttpGet("{DocumentID}")]
        public async Task<DataTable> DeleteContract(string DocumentID)
        {
            dt = await objNocdesk.DeleteContract(DocumentID);
            return dt;
        }
        #endregion
    }
}