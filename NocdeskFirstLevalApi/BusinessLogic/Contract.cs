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
    public class Contract
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
        string data = "";
        public async Task<DataTable> AddContract(string ParameterJson)
        {
            try
            {
                string strReturn = "";
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
                objParam.DocParentID = "0";
                objParam.DocParentType = "0";
                objParam.DocuentJSON = "";
                objParam.DocumentDescription = display["add_contract_description"];
                objParam.DocumentName = display["add_contract_name"];
                objParam.DocumentType = display["DocumentType"];
                objParam.EndDay = display["add_contract_end_date"];
                objParam.startday = display["add_contract_start_date"];
                objParam.Status = "1";
                objParam.vendorID = display["add_contract_venderid"];
                objParam.VendorName = display["add_contract_vender_text"];
                ParameterJSON objParamPass = new ParameterJSON();
                objParamPass.user_json = JsonConvert.SerializeObject(objParam);
                objParamPass.user_json = dtconversion.Base64Encode(objParamPass.user_json);
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/AddDocumentMaster";
                resultdata = await CallingMethod.post_method(baseUrl, objParamPass);
                //string output = JsonConvert.SerializeObject(resultdata);
                resultdata = resultdata.Substring(1, resultdata.Length - 2).Replace("\\", "");
                JObject json = JObject.Parse(resultdata.ToString());
                {
                    strStatus = json["status"].ToString();
                    strMessage = json["status_message"].ToString();
                    data = json["data"].ToString();
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = data;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("Contract", "log", "FristLeval", "GetContractDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public async Task<DataTable> GetContractDetails(string Doctype)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/GetDocumentMasterbydoctype/" + Doctype;
                resultdata = await CallingMethod.get_method(baseUrl);
                objcommon.WriteLog("Contract", "log", "FristLeval", "GetContractDetails GetDocumentMasterbydoctype resultdata  : " + resultdata, true);
                strStatus = "1";
                strMessage = " Get Contract Successfully Done.";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("Contract", "log", "FristLeval", "GetContractDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public async Task<DataTable> DeleteContract(string DocumentID)
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
                strMessage = "SLA Deleted Successfully Done.";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("Contract", "log", "FristLeval", "DeleteDocumentDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
    }
}
