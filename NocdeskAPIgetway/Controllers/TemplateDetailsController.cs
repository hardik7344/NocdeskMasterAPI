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
    public class TemplateDetailsController : ControllerBase
    {
        TemplateDetails objNocdesk = new TemplateDetails();
        DataTableConversion obj = new DataTableConversion();
        DataTable dt = new DataTable();

        #region TemplateDetails

        // GET the Template Details 
        // GET: Nocdesk/TemplateDetails/GetTemplateDetails
        [HttpGet]
        public DataTable GetTemplateDetails()
        {
            dt = objNocdesk.GetTemplateDetails();
            return dt;
        }
        // GET: Nocdesk/TemplateDetails/GetTemplateList
        [HttpGet("{SDTTEmplateType}")]
        public DataTable GetTemplateList(string SDTTEmplateType)
        {
            dt = objNocdesk.GetTemplateList(SDTTEmplateType);
            return dt;
        }

        // GET the Template Details By TemplateID 
        // GET: Nocdesk/TemplateDetails/GetTemplateDetailsByID
        [HttpGet("{TemplateID}")]
        public DataTable GetTemplateDetailsByID(string TemplateID)
        {
            dt = objNocdesk.GetTemplateDetailsByID(TemplateID);
            return dt;
        }

        // GET the Template Details By TemplateName 
        // GET: Nocdesk/TemplateDetails/GetTemplateDetailsByName
        [HttpGet("{Templatename}")]
        public DataTable GetTemplateDetailsByName(string Templatename)
        {
            dt = objNocdesk.GetTemplateDetailsByName(Templatename);
            return dt;
        }

        // Post the Template Details 
        // POST: Nocdesk/TemplateDetails/AddTemplatedetails
        [HttpPost]
        public string AddTemplateDetails([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddTemplateDetails(objParam.user_json);
            return strReturn;
        }
        #endregion
    }
}