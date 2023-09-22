using Newtonsoft.Json;
using NocdeskAPIgetway.DataAccessLayer;
using NocdeskAPIgetway.Model;
using OwnYITCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskAPIgetway.BusinessLogic
{
    public class TemplateDetails
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

        #region Template Details
        public DataTable GetTemplateDetails()
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateDetails());
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetails datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetails Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetTemplateList(string SDTTEmplateType)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateList(SDTTEmplateType));
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetails datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetails Exception : " + ex.Message, true);
            }
            return dt;
        }

        public DataTable GetTemplateDetailsByID(string TemplateID)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateDetailsByID(TemplateID));
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetailsByID datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetailsByID Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetTemplateDetailsByName(string Templatename)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateDetailsByName(Templatename));
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetailsByName datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "GetTemplateDetailsByName Exception : " + ex.Message, true);
            }
            return dt;
        }
        public string AddTemplateDetails(string userjson)
        {
            string strReturn = "";
            try
            {
                var StrData = "";
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "AddDTemplateDetails parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                string strData = dtconversion.Base64Decode(display["strData"]);
                DataTable dt = dtconversion.JsonStringToDataTable(strData);
                string EntryID = "";
                string Templatedes = "";
                string TemplateName = "";
                string ChildID = "";
                string result = "";
                string ChildPreSeq = "";
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EntryID =   dt.Rows[i]["AttnEntryID"].ToString();
                        TemplateName = dt.Rows[i]["TemplateName"].ToString();
                        ChildID =  dt.Rows[i]["ChildId"].ToString();
                        Templatedes = dt.Rows[i]["Templatedes"].ToString();
                        ChildPreSeq = dt.Rows[i]["TemplatePreSeq"].ToString();
                   
                        if (display["action_type"] == "1")
                        {
                            //string query = objQuery.GetTemplateID();
                            //string TemplateID = objDBNocdesk.executeScalar(query);
                            string strQuery = objQuery.InsertTemplateDetailsData(display["TemplateID"], display["TemplateType"], EntryID, ChildPreSeq, ChildID, Templatedes);
                            if (objDBNocdesk.execute(strQuery) > 0)
                            {
                                strStatus = "1";
                                strMessage = "Template Created Successfully Done.";
                            }
                            else
                            {

                                strStatus = "0";
                                strMessage = "Template Created Failed.";
                            }
                        }
                    }
                    
                }
                if (result == "")
                {
                    result = "No data found";
                }
                //resultdata = "{\"TemplateID\":\"" + TemplateID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "AddDTemplateDetails datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateDetails", "log", "secondlevel", "AddDTemplateDetails Exception : " + ex.Message, true);
            }
            return dtconversion.DataTableToJSONString(resultdt);
        }
        #endregion
    }
}
