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
    public class TemplateWorkflowController : ControllerBase
    {
        TemplateWorkflow objNocdesk = new TemplateWorkflow();
        DataTableConversion obj = new DataTableConversion();
        DataTable dt = new DataTable();

        #region TemplateDetails

        // GET the Template Workflow details 
        // GET: Nocdesk/TemplateWorkflow/GetTemplateWorkflowDetails
        [HttpGet]
        public DataTable GetTemplateWorkflowDetails()
        {
            dt = objNocdesk.GetTemplateWorkflowDetails();
            return dt;
        }
        // Post the Template Workflow Details 
        // POST: Nocdesk/TemplateWorkflow/AddTemplateWorkflowDetails
        [HttpPost]
        public string AddTemplateWorkflowDetails([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddTemplateWorkflowDetails(objParam.user_json);
            return strReturn;
        }
        //POST: Nocdesk/TemplateWorkflow/AddTemplatetypeDetails
        [HttpPost]
        public string AddTemplatetypeDetails([FromBody] ParameterJSON objParam)
        {
            string strReturn = objNocdesk.AddTemplatetypeDetails(objParam.user_json);
            return strReturn;
        }
        #endregion

        #region Template Workflow Steps

        // GET the Template Workflow Steps details 
        // GET: Nocdesk/TemplateWorkflow/GetTemplateWorkflowStepsDetails
        [HttpGet]
        public DataTable GetTemplateWorkflowStepsDetails()
        {
            dt = objNocdesk.GetTemplateWorkflowStepsDetails();
            return dt;
        }

        // Post the Template Workflow Steps Details 
        // POST: Nocdesk/TemplateWorkflow/AddTemplateWorkflowStepsDetails
        //[HttpPost]
        //public string AddTemplateWorkflowStepsDetails([FromBody] ParameterJSON objParam)
        //{
        //    string strReturn = objNocdesk.AddTemplateWorkflowStepsDetails(objParam.user_json);
        //    return strReturn;
        //}
        #endregion
    }
}