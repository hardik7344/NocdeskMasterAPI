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
    public class DocumentDetails
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
        //GetDocumentDetails
        public DataTable GetDocumentDetailsdata()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentDetails());
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "GetDocumentDetailsdata datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "GetDocumentDetailsdata Exception : " + ex.Message, true);
            }
            return dt;
        }
        //GetDocumentDetailsbyDocTypeAndID
        public DataTable GetDocumentDetailsbyDocTypeAndID(string DocumentType,string DocumentID)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentDetailsbyDocTypeAndID(DocumentType,DocumentID));
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "GetDocumentDetailsbyDocTypeAndID datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "GetDocumentDetailsbyDocTypeAndID Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetDocumentDetailsbyDocType(string DocumentType)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentDetailsbyDocType(DocumentType));
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "GetDocumentDetailsbyDocType datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "GetDocumentDetailsbyDocType Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable AddDocumentDetailsdata(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.DocumentMasterPool.getConnection();
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "AddDocumentDetailsdata parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    string strQuery = objQuery.InsertDocumentDetailsData(/*display["Record_Serial_Number"],*/ display["ApplicationID"], display["DocumentType"], display["DocumentId"], display["DocumentsubID"], display["DocPLID1Id"], display["DocPLName1"], display["DocPLID2Id"], display["DocPLName2"], display["DocPLID3Id"], display["DocPLName3"], display["DocV1"], display["Docv2"], display["Docv3"], display["Document_detail_json"], display["startdate"], display["Enddate"], display["Status"]);
                    if (objDBActivity.execute(strQuery) > 0)
                    {
                        strStatus = "1";
                        strMessage = "DocumentDetails Created Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "DocumentDetails Created Failed.";
                    }

                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateDocumentDetailsData(display["editUserId"], display["Editpass"], display["edit_user_end_date"])) > 0)
                    {
                        strStatus = "1";
                        strMessage = "DocumentDetails Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "DocumentDetails Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                //row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "AddDocumentDetailsdata datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBActivity);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "AddDocumentDetailsdata Exception : " + ex.Message, true);
            }
            return resultdt;
        }

        public DataTable DeleteDocumentDetailsdata(string DocumentID, string RecordSerialNumber)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.DocumentMasterPool.getConnection();
                if (objDBActivity.execute(objQuery.DeleteDocumentDetails(DocumentID,RecordSerialNumber)) > 0)
                {
                    row["status"] = "1";
                    row["status_message"] = "DocumentDetails Head Deleted Successfully.";
                   
                }
                else
                {
                    row["status"] = "0";
                    row["status_message"] = "DocumentDetails Head Deleted Failed.";
                   
                }
                resultdt.Rows.Add(row);
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "DeleteDocumentDetailsdata datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBActivity);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentDetails", "log", "secondlevel", "DeleteDocumentDetailsdata Exception : " + ex.Message, true);
            }
            return resultdt;
        }
    }
}
