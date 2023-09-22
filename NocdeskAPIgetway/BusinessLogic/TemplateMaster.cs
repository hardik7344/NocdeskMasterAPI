using NocdeskAPIgetway.DataAccessLayer;
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
    public class TemplateMaster
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

        #region Template Master
        public DataTable GetTemplateMaster()
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateMaster());
                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "GetTemplateMaster datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "GetTemplateMaster Exception : " + ex.Message, true);
            }
            return dt;
        }

        public DataTable GetTemplateMasterDetailsByTemplateType()
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTemplateMasterDetailsByTemplateType());
                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "GetTemplateMasterDeatilsByTemplateType datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "GetTemplateMasterDeatilsByTemplateType Exception : " + ex.Message, true);
            }
            return dt;
        }
        public string AddTemplateMaster(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                string TemplateID = "";
                string TemplateType = "";
                string EntityType = "8";
                DatabaseHandler objDBNocdesk = LocalConstant.TemplateMasterPool.getConnection();
                DatabaseHandler objSDDB = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "AddDTemplateMaster parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                string DocumentID = objSDDB.executeScalar(objQuery.NormalTemplatLinkag(display["catID"], display["subcatID"], display["itemID"]));
                //CultureInfo provider = CultureInfo.InvariantCulture;
                //DateTime Startdate = DateTime.ParseExact(display["StartDate"], "dd/mm/yyyy", provider);
                //DateTime Enddate = DateTime.ParseExact(display["EndDate"], "dd/mm/yyyy", provider);
                if (display["action_type"] == "1")
                {
                    TemplateID = objDBNocdesk.executeScalar(objQuery.GetTemplateID());
                    string strQuery = objQuery.InsertTemplateMasterData(TemplateID, display["ApplicationID"], display["TemplateType"], display["TemplateName"], display["ParentID"], display["ParentType"], display["Description"], display["DefaultPriority"]);
                    
                     if (objDBNocdesk.execute(strQuery) > 0)
                    {
                        if (display["TemplateType"] == "Normal")
                        {
                            TemplateType = "10";
                            string StrQuery1 = objQuery.InsertNormalTemplatLinkag(display["ApplicationID"], TemplateType, TemplateID, EntityType, DocumentID);
                            objSDDB.execute(StrQuery1);
                        }                        
                        strStatus = "1";
                        strMessage = "Template Created Successfully Done.";
                    }
                    else
                    {

                        strStatus = "0";
                        strMessage = "Template Created Failed.";
                    }
                    //}
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
                resultdata = "{\"TemplateID\":\"" + TemplateID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "TemplateMaster datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TemplateMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("TemplateMaster", "log", "secondlevel", "TemplateMaster Exception : " + ex.Message, true);
            }
            return dtconversion.DataTableToJSONString(resultdt);
        }
        #endregion
    }
}
