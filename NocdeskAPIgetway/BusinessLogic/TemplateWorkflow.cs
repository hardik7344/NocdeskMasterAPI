using NocdeskAPIgetway.DataAccessLayer;
using OwnYITCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskAPIgetway.BusinessLogic
{
    public class TemplateWorkflow
    {
        //DatabaseCommon objcommon = new DatabaseCommon();
        NocDeskCommon objcommon = new NocDeskCommon();
        DataTableConversion dtconversion = new DataTableConversion();
        QueryHandler objQuery = new QueryHandler();

        string resultdata = "";
        string JSONresult = string.Empty;
        DataTable resultdt = new DataTable();
        DataTable dt = new DataTable();

        string strStatus = "0"; // 0 - Fail , 1 - Successs , 2 - Already exist
        string strMessage = "";

        #region Template Workflow Details
        public DataTable GetTemplateWorkflowDetails()
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateWorkflowDetails());
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "GetTemplateWorkflowDetails datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "GetTemplateWorkflowDetails Exception : " + ex.Message, true);
            }
            return dt;
        }

        public string AddTemplateWorkflowDetails(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "AddTemplateWorkflowDetails parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    string Json_data = display["ActivityData"];
                    DataTable dttemp = dtconversion.JsonStringToDataTable(Json_data);
                    foreach (DataRow dr in dttemp.Rows)
                    {
                        string strSrNo = dr["serialNo"].ToString().Trim();
                        string ActName = dr["ActName"].ToString().Trim();
                        string FlowJson = dr["FlowJson"].ToString().Trim();
                        string strQuery = objQuery.InsertTemplateWorkflowDetails(display["TemplateID"], display["TemplateType"], strSrNo, ActName, display["ActDetails1"], display["ActDetails2"], FlowJson);
                        int q1 = objDBNocdesk.execute(strQuery);
                        string[] dtdata = FlowJson.Split(",");
                        for (int i = 0; i < dtdata.Length; i++)
                        {
                            if (dtdata[i].Trim().Length > 2)
                            {
                                string[] strArr = dtdata[i].Trim().Split(" ");
                                string strQuery1 = objQuery.InsertAddTemplateWorkflowStepsDetails(display["TemplateID"], strSrNo, strArr[0], strArr[1]);
                                objDBNocdesk.execute(strQuery1);
                                

                            }
                            
                        }
                       
                    }
                    strStatus = "0";
                    strMessage = "Template Details Created Successfully Done.";
                }
                //else if (display["action_type"] == "2")
                //{
                //    if (objDBNocdesk.execute(objQuery.UpdateTemplateMasterData()))
                //    {
                //        strStatus = "1";
                //        strMessage = "DocumentMaster updated successfully.";
                //    }
                //    else
                //    {
                //        strStatus = "0";
                //        strMessage = "DocumentMaster updated failed.";
                //    }
                //}
                //    resultdata = "{\"TemplateID\":\"" + TemplateID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "AddTemplateWorkflowDetails datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateWorkflow", "log", " secondlevel", "AddTemplateWorkflowDetails Exception : " + ex.Message, true);
            }
            return dtconversion.DataTableToJSONString(resultdt);
        }

        //Addtempletestypedata

        public string AddTemplatetypeDetails(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "AddTemplatetypeDetails parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    if (display["TemplateType"] == "exception")
                    {
                        string strQuery = objQuery.InsertTemplatetyperaisetException(display["TemplateID"], display["TemplateType"], display["raisetException"]);
                        string strQuery1 = objQuery.InsertTemplatetypeCloseException(display["TemplateID"], display["TemplateType"], display["CloseException"]);
                        if (objDBNocdesk.execute(strQuery) > 0 && objDBNocdesk.execute(strQuery1) > 0)
                        {
                            strStatus = "1";
                            strMessage = "Template Type Details Created Successfully Done.";
                        }
                        else
                        {

                            strStatus = "0";
                            strMessage = "Template Type Details Created Failed.";
                        }
                    }
                    else
                    {
                        //string strQuery = objQuery.InsertTemplatetyperaisetException(display["TemplateID"], display["TemplateType"], display["raisetException"]);
                        //string strQuery1 = objQuery.InsertTemplatetypeCloseException(display["TemplateID"], display["TemplateType"], display["CloseException"]);
                        string strQuery2 = objQuery.InsertTemplatetyperaiseNotifaction(display["TemplateID"], display["TemplateType"], display["raiseNotifaction"]);
                        if (objDBNocdesk.execute(strQuery2) > 0)
                        {
                            strStatus = "1";
                            strMessage = "Template Type Details Created Successfully.";
                        }
                        else
                        {

                            strStatus = "0";
                            strMessage = "Template Type Details Created Failed.";
                        }
                    }
                }
                //else if (display["action_type"] == "2")
                //{
                //    if (objDBNocdesk.execute(objQuery.UpdateTemplateMasterData()))
                //    {
                //        strStatus = "1";
                //        strMessage = "DocumentMaster updated successfully.";
                //    }
                //    else
                //    {
                //        strStatus = "0";
                //        strMessage = "DocumentMaster updated failed.";
                //    }
                //}
                //    resultdata = "{\"TemplateID\":\"" + TemplateID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("TemplateWorkflow", "log", " secondlevel", "AddTemplatetypeDetails datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateWorkflow", "log", " secondlevel", "TemplateWorkflowDetails Exception : " + ex.Message, true);
            }
            return dtconversion.DataTableToJSONString(resultdt);
        }
        #endregion

        #region Template Workflow Steps Details
        public DataTable GetTemplateWorkflowStepsDetails()
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateWorkflowStepsDetails());
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "GetTemplateWorkflowStepsDetails datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "GetTemplateWorkflowStepsDetails Exception : " + ex.Message, true);
            }
            return dt;
        }
        public string AddTemplateWorkflowStepsDetails(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "AddTemplateWorkflowStepsDetails parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                //CultureInfo provider = CultureInfo.InvariantCulture;
                //DateTime Startdate = DateTime.ParseExact(display["StartDate"], "dd/mm/yyyy", provider);
                //DateTime Enddate = DateTime.ParseExact(display["EndDate"], "dd/mm/yyyy", provider);
                //if (display["action_type"] == "1")
                //{
                //    string strQuery = objQuery.InsertAddTemplateWorkflowStepsDetails(display["TemplateID"], SerialNO, keyleval, valueleval);
                //    if (objDBNocdesk.execute(strQuery) > 0)
                //    {
                //        strStatus = "1";
                //        strMessage = "Template created successfully.";
                //    }
                //    else
                //    {

                //        strStatus = "0";
                //        strMessage = "Template created failed.";
                //    }
                //    //}
                //}
                //else if (display["action_type"] == "2")
                //{
                //    if (objDBNocdesk.execute(objQuery.UpdateTemplateMasterData()))
                //    {
                //        strStatus = "1";
                //        strMessage = "DocumentMaster updated successfully.";
                //    }
                //    else
                //    {
                //        strStatus = "0";
                //        strMessage = "DocumentMaster updated failed.";
                //    }
                //}
                //    resultdata = "{\"TemplateID\":\"" + TemplateID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "AddTemplateWorkflowStepsDetails datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateWorkflow", "log", "secondlevel", "AddTemplateWorkflowStepsDetails Exception : " + ex.Message, true);
            }
            return dtconversion.DataTableToJSONString(resultdt);
        }
        #endregion
    }
}
