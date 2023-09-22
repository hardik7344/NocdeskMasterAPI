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
    public class TemplateMasterController : ControllerBase
    {
        TemplateMaster objNocdesk = new TemplateMaster();
        DataTableConversion obj = new DataTableConversion();
        DataTable dt = new DataTable();

        #region TemplateMaster

        // GET the Template Master 
        // GET: Nocdesk/TemplateMaster/GetTemplateMaster
        [HttpGet]
        public DataTable GetTemplateMaster()
        {
            dt = objNocdesk.GetTemplateMaster();
            return dt;
        }

        // GET the Template Master Details  
        // GET: Nocdesk/TemplateMaster/GetTemplateMasterDetailsByTemplateType
        [HttpGet]
        public DataTable GetTemplateMasterDetailsByTemplateType()
        {
            dt = objNocdesk.GetTemplateMasterDetailsByTemplateType();
            return dt;
        }

        // Post the Template Master 
        // POST: Nocdesk/TemplateMaster/AddTemplateMaster
        [HttpPost]
        public string AddTemplateMaster([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddTemplateMaster(objParam.user_json);
            return strReturn;
        }
        #endregion
    }

}
