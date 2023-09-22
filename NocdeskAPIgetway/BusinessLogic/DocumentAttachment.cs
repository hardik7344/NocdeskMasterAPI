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
    public class DocumentAttachment
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
        public string AddLinkageMaster(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DataTable dtleval = new DataTable();
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();

                objcommon.WriteLog("DocumentAttachment", "log", "secondlevel", "ADDDocumentAttachment parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                objcommon.WriteLog("DocumentAttachment", "log", "secondlevel", " ADDDocumentAttachment display  json : " + display, true);
                if (display["action_type"] == "1")
                {
                    string strQuery = objQuery.InsertDocumentInsert(display["ApplicationID"],display["L1Type"], display["L1ID"], display["L2Type"], display["L2ID"], display["L3Type"], display["L3ID"], display["DocumentAttachmentJson"],display["Status"]);
                    if (objDBNocdesk.execute(strQuery) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Document Attachment Successfully Done.";
                    }
                    else
                    {

                        strStatus = "0";
                        strMessage = "Document Attachment Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = "";
                resultdt.Rows.Add(row);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {

            }
            return dtconversion.DataTableToJSONString(resultdt);

        }
        public DataTable GetLinkageMaster(string DocumentID)
        {
            try
            {
                
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetLinkageMaster(DocumentID));
                objcommon.WriteLog("DocumentAttachment", "log", "secondlevel", "GetLinkageMaster datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentAttachment", "log", "secondlevel", "GetLinkageMaster Exception : " + ex.Message, true);
            }
            return dt;
        }
    }
}