using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NocdeskAPIgetway.BusinessLogic;
using NocdeskAPIgetway.Model;
using OwnYITCommon;

namespace NocdeskAPIgetway.Controllers
{
    [Route("Nocdesk/[controller]/[action]")]
    [ApiController]
    public class DocumentAttachmentController : ControllerBase
    {
        DocumentAttachment objNocdesk = new DocumentAttachment();
        DataTableConversion obj = new DataTableConversion();
        DataTable dt = new DataTable();
        [HttpPost]

        //Post:Nocdesk/DocumentAttachment/AddLinkageMaster
        public string AddLinkageMaster([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddLinkageMaster(objParam.user_json);
            return strReturn;
        }
        [HttpGet("{DocumentID}")]
        //Post:Nocdesk/DocumentAttachment/GetLinkageMaster/DocumentID
        public DataTable GetLinkageMaster(string DocumentID)
        {
            dt = objNocdesk.GetLinkageMaster(DocumentID);
            return dt;
        }
    }
}