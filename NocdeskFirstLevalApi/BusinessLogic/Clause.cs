using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NocdeskFirstLevalApi.DataAccessLayer;
using NocdeskFirstLevalApi.Model;
using OwnYITCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskFirstLevalApi.BusinessLogic
{
    public class Clause
    {
        DataTableConversion dtconversion = new DataTableConversion();
        string resultdata = "";
        string JSONresult = string.Empty;
        DataTable resultdt = new DataTable();
        DataTable dt = new DataTable();
        //DatabaseCommon objcommon = new DatabaseCommon();
        NocDeskCommon objcommon = new NocDeskCommon();
        string strStatus = "0"; // 0 - Fail , 1 - Successs , 2 - Already exist
        string strMessage = "";
        public async Task<DataTable> GetClauseDetails(string DocumentID, string DocumentType)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/GetDocumentMasterbydoctypeAndParentID/" + DocumentID + "/102";
                resultdata = await CallingMethod.get_method(baseUrl);
                //objcommon.WriteLog("Get_SLA_Details", "log", "Contract MicroService", "GetContractDetails Exception : " + resultdata, true);
                strStatus = "1";
                strMessage = "Get Clause successfully.";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("Clause", "log", "FristLeval", "GetClauseDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public async Task<DataTable> AddClause(string ParameterJson)
        {
            try
            {  
  
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string strTemp = dtconversion.Base64Decode(ParameterJson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                ContractMaster objParam = new ContractMaster();
                objParam.action_type = display["action_type"];                
                objParam.ApplicationID = display["ApplicationID"];
                objParam.VersionNumbar = "104";
                objParam.Docclassifier = "1";
                objParam.DocParentID = display["documentid"];
                objParam.DocParentType = display["documenttype"];
                objParam.DocuentJSON = "";
                objParam.DocumentDescription = display["add_clause_Description"];
                objParam.DocumentName = display["Add_clause_name"];
                objParam.DocumentType = display["DocumentType"];
                objParam.startday = display["add_clause_start_date"];
                objParam.EndDay = display["add_clause_end_date"];
                objParam.Status = "1";
                objParam.SRNo = display["Add_clause_RefNo"];    
                ParameterJSON objParamPass = new ParameterJSON();
                objParamPass.user_json = JsonConvert.SerializeObject(objParam);
                objParamPass.user_json = dtconversion.Base64Encode(objParamPass.user_json);
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/AddDocumentMaster";
                objcommon.WriteLog("Clause", "log", "FristLeval", "ClauseDetails URL : " + baseUrl, true);
                resultdata = await CallingMethod.post_method(baseUrl, objParamPass);
                resultdata = resultdata.Substring(1, resultdata.Length - 2).Replace("\\", "");
                JObject json = JObject.Parse(resultdata.ToString());
                {
                    strStatus = json["status"].ToString();
                    strMessage = json["status_message"].ToString();
                }                
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("Clause", "log", "FristLeval", "ClauseDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public async Task<DataTable> DeleteClause(string DocumentID)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/DeleteDocumentMaster/" + DocumentID;
                resultdata = await CallingMethod.get_method(baseUrl);
                strStatus = "3";
                strMessage = "Clause Deleted Successfully Done.";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("Clause", "log", "FristLeval", "DeleteClauseDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
    }
}
