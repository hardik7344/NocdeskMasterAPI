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
    public class DocumentDetailsController : ControllerBase
    {
        DocumentDetails objNocdesk = new DocumentDetails();
        DataTableConversion obj = new DataTableConversion();
        DataTable dt = new DataTable();

        #region DocumentDetails
        // GET the Document Master 
        // GET: Nocdesk/DocumentDetails/GetDocumentDetails
        [HttpGet]
        public DataTable GetDocumentDetails()
        {
            dt = objNocdesk.GetDocumentDetailsdata();
            return dt;
        }
        // GET the Get Document Details by DocType And ID
        // GET: Nocdesk/DocumentDetails/GetDocumentDetailsbyDocTypeAndID
        [HttpGet("{DocumentType}/{DocumentID}")]
        public DataTable GetDocumentDetailsbyDocTypeAndID(string DocumentType, string DocumentID)
        {
            dt = objNocdesk.GetDocumentDetailsbyDocTypeAndID( DocumentType,DocumentID);
            return dt;
        }
        // GET the Get Document Details by DocType And ID
        // GET: Nocdesk/DocumentDetails/GetDocumentDetailsbyDocType
        [HttpGet("{DocumentType}")]
        public DataTable GetDocumentDetailsbyDocType(string DocumentType)
        {
            dt = objNocdesk.GetDocumentDetailsbyDocType(DocumentType);
            return dt;
        }
        // Post the Document Master 
        // POST: Nocdesk/DocumentDetails/AddDocumentDetails
        [HttpPost]
        public DataTable AddDocumentDetails([FromBody] ParameterJSON objParam)
        {
            dt = objNocdesk.AddDocumentDetailsdata(objParam.user_json);
            return dt;
        }
        //delete The Document Master
        //delete:Nocdesk/DocumentDetails/DeleteDocumentDetails
        [HttpGet("{RecordSerialNumber}/{DocumentID}")]
        public DataTable DeleteDocumentDetails(string DocumentID,string RecordSerialNumber)
        {
            dt = objNocdesk.DeleteDocumentDetailsdata(DocumentID, RecordSerialNumber);
            return dt;
        }
        #endregion
    }
}