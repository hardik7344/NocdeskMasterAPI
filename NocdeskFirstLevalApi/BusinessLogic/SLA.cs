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
    public class SLA
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
        public async Task<DataTable> GetSLADetails(string Doctype)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/GetDocumentMasterbydoctype/" + Doctype;
                resultdata = await CallingMethod.get_method(baseUrl);
                //objcommon.WriteLog("Get_SLA_Details", "log", "Contract MicroService", "GetContractDetails Exception : " + resultdata, true);
                strStatus = "1";
                strMessage = "Get SLA created successfully.";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("SLA", "log", "FristLeval", "GetSLADetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public async Task<DataTable> AddSLA(string ParameterJson)
        {
            try
            {
                var StrData = "";
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                // resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string strTemp = dtconversion.Base64Decode(ParameterJson);
                string baseUrl = "";
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                ContractMaster objParam = new ContractMaster();
                objParam.action_type = display["action_type"];
                objParam.ApplicationID = display["ApplicationID"];
                objParam.VersionNumbar = "104";
                objParam.Docclassifier = "1";
                objParam.DocParentID = display["documentID"];
                objParam.DocParentType = display["doc_type"];
                objParam.DocuentJSON = "";
                objParam.DocumentDescription = display["Vendrmngt_SLA_descb"];
                objParam.DocumentName = display["Vendrmngt_Slaname"];
                objParam.DocumentType = display["DocumentType"];
                objParam.startday = display["Vendrmngt_SLA_strdate"];
                objParam.EndDay = display["Vendrmngt_SLA_enddate"];
                objParam.strData = display["strData"];
                StrData = display["strData"];
                objParam.Status = "1";
                ParameterJSON objParamPass = new ParameterJSON();
                objParamPass.user_json = JsonConvert.SerializeObject(objParam);
                objParamPass.user_json = dtconversion.Base64Encode(objParamPass.user_json);
                baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/AddDocumentMaster";
                string resultdata1 = await CallingMethod.post_method(baseUrl, objParamPass);
                resultdata1 = resultdata1.Substring(1, resultdata1.Length - 2).Replace("\\", "");
                JObject json = JObject.Parse(resultdata1.ToString());
                string Documentdata = json["data"].ToString();
                Documentdata = Documentdata.Substring(1, Documentdata.Length - 2).Replace("\r\n", "");
                JObject json1 = JObject.Parse(Documentdata.ToString());
                string DocumentID = json1["DocumentID"].ToString();

                //DataTable dttemp = dtconversion.JsonStringToDataTable(resultdata1);

                //IDictionary<string, string> display2 = dtconversion.getJSONPropertiesFromString("[" + json.ToString() + "]");
                //IDictionary<string, string> display2 = dtconversion.getJSONPropertiesFromString("[" + dttemp.Rows[0][2].ToString() + "]");

                //string JsonData = display2["data"];
                DataTable dtleval = new DataTable();
                dtleval = dtconversion.JsonStringToDataTable(StrData);
                string level = "";
                string role = "";
                string notify = "";
                string resolutionType = "";
                string resolutionTime = "";
                for (int i = 0; i < dtleval.Rows.Count; i++)
                {
                    string User_json = JsonConvert.SerializeObject(dtleval).ToString();
                    level = dtleval.Rows[i]["level"].ToString();
                    role = dtleval.Rows[i]["role"].ToString();
                    notify = dtleval.Rows[i]["notify"].ToString();
                    resolutionType = dtleval.Rows[i]["resolutionType"].ToString();
                    resolutionTime = dtleval.Rows[i]["resolutionTime"].ToString();
                    if (role != "")
                    {
                        DocumentDetialsmaster objParam2 = new DocumentDetialsmaster();
                        objParam2.action_type = display["action_type"];
                        objParam2.ApplicationID = "11";
                        objParam2.DocumentType = display["doc_type"];
                        objParam2.DocumentId = DocumentID;
                        objParam2.DocumentsubID = "101";
                        objParam2.DocPLID1Id = "1";
                        objParam2.DocPLName1 = "level";
                        objParam2.DocPLID2Id = "1";
                        objParam2.DocPLName2 = "role";
                        objParam2.DocPLID3Id = "1";
                        objParam2.DocPLName3 = "notify";
                        objParam2.DocV1 = level;
                        objParam2.Docv2 = role;
                        objParam2.Docv3 = notify;
                        objParam2.Document_detail_json = "NULL";
                        objParam2.startdate = "06-12-2022";
                        objParam2.Enddate = "06-12-2023";
                        objParam2.Status = "1";
                        ParameterJSON objParamPass2 = new ParameterJSON();
                        objParamPass2.user_json = JsonConvert.SerializeObject(objParam2);
                        objParamPass2.user_json = dtconversion.Base64Encode(objParamPass2.user_json);
                        baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentDetails/AddDocumentDetails";
                        resultdata = await CallingMethod.post_method(baseUrl, objParamPass2);
                        resultdata = resultdata.Substring(1, resultdata.Length - 2).Replace("\\", "");
                        JObject jsonDetails1 = JObject.Parse(resultdata.ToString());
                        string DetailsStutes = jsonDetails1["status"].ToString();
                        if (DetailsStutes == "1")
                        {
                            SLARouting objParamDetails1 = new SLARouting();
                            objParamDetails1.action_type = display["action_type"];
                            objParamDetails1.SDLinkType = "3";
                            objParamDetails1.SDLinkID = "";
                            objParamDetails1.ContractID = display["documentID"];
                            objParamDetails1.ClauseID = display["Vendrmngt_SLA_select_clause_val"];
                            objParamDetails1.SLAID = DocumentID;
                            objParamDetails1.SLALevel = level;
                            objParamDetails1.OrgID = "";
                            objParamDetails1.OUID = "";
                            objParamDetails1.OULinkType = "";
                            objParamDetails1.SDRollID = role;
                            objParamDetails1.SDPersonID = "";
                            objParamDetails1.SDReceivingID = "";
                            objParamDetails1.UserID = "";
                            objParamDetails1.DeviceID = "";
                            objParamDetails1.SDTTemplateID = "";
                            objParamDetails1.StartDate = display["Vendrmngt_SLA_strdate"];
                            objParamDetails1.EndDate = "";
                            objParamDetails1.Status = "";
                            objParamDetails1.CatID = "";
                            ParameterJSON objParamDerails = new ParameterJSON();
                            objParamDerails.user_json = JsonConvert.SerializeObject(objParamDetails1);
                            objParamDerails.user_json = dtconversion.Base64Encode(objParamDerails.user_json);
                            baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/SLARoutingLinkag";
                            resultdata = await CallingMethod.post_method(baseUrl, objParamDerails);
                        }
                        else
                        {

                        }
                        DocumentDetialsmaster objParam3 = new DocumentDetialsmaster();
                        objParam3.action_type = display["action_type"];
                        objParam3.ApplicationID = "11";
                        objParam3.DocumentType = display["doc_type"];
                        objParam3.DocumentId = DocumentID;
                        objParam3.DocumentsubID = "101";
                        objParam3.DocPLID1Id = "1";
                        objParam3.DocPLName1 = "level";
                        objParam3.DocPLID2Id = "2";
                        objParam3.DocPLName2 = "resolutionType";
                        objParam3.DocPLID3Id = "2";
                        objParam3.DocPLName3 = "resolutionTime";
                        objParam3.DocV1 = level;
                        objParam3.Docv2 = resolutionType;
                        objParam3.Docv3 = resolutionTime;
                        objParam3.Document_detail_json = "NULL";
                        objParam3.startdate = "06-12-2022";
                        objParam3.Enddate = "06-12-2023";
                        objParam3.Status = "1";
                        ParameterJSON objParamPass3 = new ParameterJSON();
                        objParamPass3.user_json = JsonConvert.SerializeObject(objParam3);
                        objParamPass3.user_json = dtconversion.Base64Encode(objParamPass3.user_json);
                        baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentDetails/AddDocumentDetails";
                        resultdata = await CallingMethod.post_method(baseUrl, objParamPass3);
                    }
                    else
                    {

                    }
                }
                JObject json2 = JObject.Parse(resultdata1.ToString());
                if (!string.IsNullOrEmpty(resultdata) && resultdata != "[]")
                {
                    strStatus = json2["status"].ToString();
                    strMessage = json2["status_message"].ToString();
                }
                else
                {
                    strStatus = json2["status"].ToString();
                    strMessage = json2["status_message"].ToString();
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                //row["data"] = resultdata;
                resultdt.Rows.Add(row);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("SLA", "log", "FristLeval", "GetContractDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public async Task<DataTable> AddSLALLinkag(string ParameterJson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                var row = resultdt.NewRow();
                string strTemp = dtconversion.Base64Decode(ParameterJson);
                string baseUrl = "";
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                SLALinkag objParam = new SLALinkag();
                objParam.action_type = display["action_type"];
                objParam.AppicationID = display["ApplicationID"];
                objParam.DocumentType = display["DocumentType"];
                objParam.DocumentID = display["DocumentID"];
                objParam.DocumentName = display["DocumentName"];
                objParam.startDate = display["StartDate"];
                objParam.EndDate = display["EndDate"];
                objParam.Stutes = display["status"];
                objParam.TData = display["TData"];
                ParameterJSON objParamPass = new ParameterJSON();
                objParamPass.user_json = JsonConvert.SerializeObject(objParam);
                objParamPass.user_json = dtconversion.Base64Encode(objParamPass.user_json);
                baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/AddDocumentSLALinkag";
                string resultdata1 = await CallingMethod.post_method(baseUrl, objParamPass);
                resultdata1 = resultdata1.Replace("\\r\\n", "").Replace("[", "").Replace("]", "");
                resultdata1 = resultdata1.Replace("]", "");
                resultdata1 = resultdata1.Substring(1, resultdata1.Length - 2);
                resultdata1 = resultdata1.Replace("\\", "");
                JObject json2 = JObject.Parse(resultdata1.ToString());
                strStatus = json2["status"].ToString();
                strMessage = json2["status_message"].ToString();
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                //row["data"] = resultdata;
                resultdt.Rows.Add(row);
                //strStatus = "1";
                //strMessage = "SLA Linkag Successfully Done.";
                //row["status"] = strStatus;
                //row["status_message"] = strMessage;
                //resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {

            }
            return resultdt;
        }
        public async Task<DataTable> DeleteSLA(string DocumentID)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string baseUrl = LocalConstant.NOCDeskSecondLevelMS + "/Nocdesk/DocumentMaster/DeleteDocumentMaster/" + DocumentID;
                resultdata = await CallingMethod.get_method(baseUrl);
                strStatus = "3";
                strMessage = "SLA Deleted Successfully Done.";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                // row["data"] = resultdata;
                resultdt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("SLA", "log", "FristLeval", "DeleteDocumentDetails Exception : " + ex.Message, true);
            }
            return resultdt;
        }
    }
}
