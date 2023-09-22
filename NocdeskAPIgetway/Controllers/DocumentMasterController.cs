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
    public class DocumentMasterController : ControllerBase
    {
        DocumentMaster objNocdesk = new DocumentMaster();
        DataTableConversion obj = new DataTableConversion();
        DataTable dt = new DataTable();
        #region DocumentMaster
        // GET the Document Master 
        // GET: Nocdesk/DocumentMaster/GetDocumentMaster
        [HttpGet]
        public DataTable GetDocumentMaster()
        {
            dt = objNocdesk.GetDocumentMaster();
            return dt;
        }

        // GET the Document Master BY DocType and ID
        // GET: Nocdesk/DocumentMaster/GetDocumentMasterbydoctypeAndID
        [HttpGet("{DocumentID}/{DocumentType}")]
        public DataTable GetDocumentMasterbydoctypeAndID(string DocumentID,string DocumentType)
        {
            dt = objNocdesk.GetDocumentMasterbydoctypeAndID(DocumentID,DocumentType);
            return dt;
        }

        // GET the Document Master BY DocType and Parent Doc ID
        // GET: Nocdesk/DocumentMaster/GetDocumentMasterbydoctypeAndID
        [HttpGet("{DocumentID}/{DocumentType}")]
        public DataTable GetDocumentMasterbydoctypeAndParentID(string DocumentID, string DocumentType)
        {
            dt = objNocdesk.GetDocumentMasterbydoctypeAndParentID(DocumentID, DocumentType);
            return dt;
        }

        // GET the Document Master BY DocType and ID
        // GET: Nocdesk/DocumentMaster/GetDocumentMasterbydoctype
        [HttpGet("{DocumentType}")]
        public DataTable GetDocumentMasterbydoctype(string DocumentType)
        {
            dt = objNocdesk.GetDocumentMasterbydoctype(DocumentType);
            return dt;
        }

        // GET the contract name
        // GET: Nocdesk/DocumentMaster/GetcontractName
        [HttpGet("{documentID}")]
        public DataTable GetcontractName(string documentID)
        {
            dt = objNocdesk.GetcontractName(documentID);
            return dt;
        }
        // Post the Document Master 
        // POST: Nocdesk/DocumentMaster/AddDocumentMaster
        [HttpPost]
        public string AddDocumentMaster([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddDocumentMaster(objParam.user_json);
            return strReturn;
        }
        //POST: Nocdesk/DocumentMaster/AddDocumentSLALinkag
        [HttpPost]
        public string AddDocumentSLALinkag([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddDocumentSLALinkag(objParam.user_json);
            return strReturn;
        }
        ////POST: Nocdesk/DocumentMaster/SDRoutingLinkag
        [HttpPost]
        public string SDRoutingLinkag([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.SDRoutingLinkag(objParam.user_json);
            return strReturn;
        }

        ////POST: Nocdesk/DocumentMaster/SLARoutingLinkag
        [HttpPost]
        public string SLARoutingLinkag([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.SLARoutingLinkag(objParam.user_json);
            return strReturn;
        }
        //delete:Nocdesk/DocumentMaster/DeleteDocumentMaster
        [HttpGet("{DocumentID}")]
        public DataTable DeleteDocumentMaster(string DocumentID)
        {
            dt = objNocdesk.DeleteDocumentMaster(DocumentID);
            return dt;
        }
        #endregion
    }
}