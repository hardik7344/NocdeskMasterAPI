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
    public class DocumentMaster
    {
        //DatabaseCommon objcommon = new DatabaseCommon();
        NocDeskCommon objcommon = new NocDeskCommon();
        DataTableConversion dtconversion = new DataTableConversion();
        QueryHandler objQuery = new QueryHandler();

        string resultdata = "";
        string JSONresult = string.Empty;
        DataTable resultdt = new DataTable();
        DataTable dt = new DataTable();
        //EntityType objEntityType = new EntityType();

        string strStatus = "0"; // 0 - Fail , 1 - Successs , 2 - Already exist
        string strMessage = "";
        #region DocumentMaster

        public DataTable GetDocumentMaster()
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentMaster());
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMaster datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMaster Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetDocumentMasterbydoctypeAndID(string DocumentID, string DocumentType)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentMasterbyDoctypeandId(DocumentID, DocumentType));
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMasterbydoctypeAndID datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMasterbydoctypeAndID Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetDocumentMasterbydoctypeAndParentID(string DocumentID, string DocumentType)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentMasterbyDoctypeandParentId(DocumentID, DocumentType));
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMasterbydoctypeAndParentID datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMasterbydoctypeAndParentID Exception : " + ex.Message, true);
            }
            return dt;
        }

        public DataTable GetDocumentMasterbydoctype(string DocumentType)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetDocumentMasterbyDoctype(DocumentType));
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMasterbydoctype datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetDocumentMasterbydoctype Exception : " + ex.Message, true);
            }
            return dt;
        }

        public DataTable GetcontractName(string DocumentID)
        {
            try
            {
                string data = "";
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetcontractName(DocumentID));
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetcontractName datatable count return : " + dt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "GetcontractName Exception : " + ex.Message, true);
            }
            return dt;
        }
        //public DataTable Getcontract()
        //{
        //    try
        //    {
        //        string data = "";
        //        DatabaseHandler objDBNocdesk = LocalConstant.poolNocdesk.getConnection();
        //        dt = objDBNocdesk.getDatatable(objQuery.GetDocumentMaster());
        //        objcommon.WriteLog("Document Master", "log", "DocumentMaster MicroService", "GetDocumentMaster datatable count return : " + dt.Rows.Count, true);
        //        LocalConstant.poolNocdesk.returnConnection(objDBNocdesk);
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("Document Master", "log", "DocumentMaster MicroService", "GetDocumentMaster Exception : " + ex.Message, true);
        //    }
        //    return dt;
        //}
        public string AddDocumentMaster(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string DocumentID = "";
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "addDocumentMaster parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    if (Convert.ToInt16(objDBNocdesk.executeScalar(objQuery.CheckUserExist(display["DocumentType"] , display["Status"], display["DocumentName"],display["DocumentDescription"]))) > 0)
                    {
                        strStatus = "2";
                        if (display["DocumentType"] == "101")
                            strMessage = "Contract already exist.";
                        else if (display["DocumentType"] == "102")
                            strMessage = "Clause already exist.";
                        else if (display["DocumentType"] == "103")
                            strMessage = "SLA already exist.";
                        else
                            strMessage = "Document already exist.";
                    }
                    else
                    {
                        string strQuery = objQuery.InsertDocumentMasterData(display["ApplicationID"], display["DocumentType"], display["VersionNumbar"], display["DocumentName"], display["DocumentDescription"], display["Docclassifier"], display["DocuentJSON"], display["DocParentType"], display["DocParentID"], display["startday"], display["EndDay"], display["Status"], display["SRNo"], display["vendorID"], display["VendorName"]);
                        if (objDBNocdesk.execute(strQuery) > 0)
                        {
                            DocumentID = objDBNocdesk.executeScalar(objQuery.GetDocumentID(display["ApplicationID"].ToString(), display["DocumentType"].ToString(), display["DocumentName"].ToString(), display["DocumentDescription"].ToString()));
                            //DocumentName = objDBNocdesk.executeScalar(objQuery.GetDocumentName(DocumentID));
                            strStatus = "1";
                            if (display["DocumentType"] == "101")
                                strMessage = "Contract Created Successfully Done.";
                            else if (display["DocumentType"] == "102")
                                strMessage = "Clause Created Successfully Done.";
                            else if  (display["DocumentType"] == "103")
                                strMessage = "SLA Created Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            if (display["DocumentType"] == "101")
                                strMessage = "Contract Created Failed.";
                            else if (display["DocumentType"] == "102")
                                strMessage = "Clause Created Failed.";
                            else if (display["DocumentType"] == "103")
                                strMessage = "SLA Created Failed.";                   
                        }
                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBNocdesk.execute(objQuery.UpdateDocumentMasterData(display["ApplicationID"], display["DocumentType"], display["VersionNumbar"], display["DocumentName"], display["DocumentDescription"], display["Docclassifier"], display["DocuentJSON"], display["DocParentType"], display["DocParentID"], display["startday"], display["EndDay"], display["Status"])) > 0)
                    {
                        DocumentID = display["DocumentID"];
                        strStatus = "1";
                        if (display["DocumentType"] == "101")
                            strMessage = "Contract Updated Successfully Done.";
                        else if (display["DocumentType"] == "102")
                            strMessage = "Clause Updated Successfully Done.";
                        else if (display["DocumentType"] == "103")
                            strMessage = "SLA Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        if (display["DocumentType"] == "101")
                            strMessage = "Contract Updated Failed.";
                        else if (display["DocumentType"] == "102")
                            strMessage = "Clause Updated Failed.";
                        else if (display["DocumentType"] == "103")
                            strMessage = "SLA Updated Updated Failed.";
                       
                    }
                }
                resultdata = "{\"DocumentID\":\"" + DocumentID + "\"}";
                strReturn = "{\"status\":\"" + strStatus + "\",\"status_message\":\"" + strMessage + "\",\"data\":[" + resultdata + "]}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "AddDocumentMaster datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "AddDocumentMaster Exception : " + ex.Message, true);
            }
            //strReturn= dtconversion.DataTableToJSONString(resultdt);
            return strReturn;
        }


        public string AddDocumentSLALinkag(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DataTable dtleval = new DataTable();
                int i;
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                DatabaseHandler objServiceDelivery = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "AddDocumentSLALinkag parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "AddDocumentSLALinkag  json : " + display, true);
                if (display["action_type"] == "1")
                {    
                    {
                        string tableJson = display["TData"];
                        dtleval = dtconversion.JsonStringToDataTable(tableJson);
                        for (i = 0; i < dtleval.Rows.Count; i++)
                        {
                            //string SatrtDate = display["startDate"];
                            //string EndDate = display["EndDate"];
                            string LinkTo = "";
                            string EntityID1 = "";
                            string EntityID2 = "";
                            string EntityID = "";
                            string EntityType = "";
                            string SRNO = "";
                            LinkTo = dtleval.Rows[i]["LinkTo"].ToString();
                            if (LinkTo.ToUpper() == "Vendor")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkOrg;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "Role")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkRole;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "SDDeliveryPerson")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkSDDeliveryPerson;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "User")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkUser;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "OU")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkOU;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "Device")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkDevice;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "Category")
                            {
                                EntityID1 = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityID2 = dtleval.Rows[i]["FieldID2"].ToString();
                                string SQ = objQuery.SLACSLinkage(EntityID1, EntityID2);
                                EntityID = objServiceDelivery.executeScalar(SQ);
                                EntityType = ConstantEntityType.EnttypeLinkSDCategory;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            else if (LinkTo == "SDTicketTemplate")
                            {
                                EntityID = dtleval.Rows[i]["FieldID1"].ToString();
                                EntityType = ConstantEntityType.EnttypeLinkTickeTemplate;
                                SRNO = dtleval.Rows[i]["SRNO"].ToString();
                            }
                            string strQuery = "";
                            if (LinkTo == "Category")
                            {
                                string Sq = objQuery.LinkageChack(display["DocumentID"], display["DocumentType"], EntityType);
                                if (Convert.ToInt16(objServiceDelivery.executeScalar(Sq)) > 0)
                                {
                                    strStatus = "2";
                                    strMessage = "SLA Linkage already exist.";
                                }
                                else
                                {
                                    strQuery = objQuery.InsertDocumentSLALInkag(display["AppicationID"], display["DocumentType"], display["DocumentID"], SRNO, EntityType, EntityID, display["Stutes"]);
                                }
                            }
                            else
                            {
                                strQuery = objQuery.InsertDocumentSLALInkag(display["AppicationID"], display["DocumentType"], display["DocumentID"], SRNO, EntityType, EntityID, display["Stutes"]);
                            }
                            objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "InsertDocumentSLALInkag json : " + strQuery, true);
                            if (strQuery.Length > 0)
                            {
                                if (objServiceDelivery.execute(strQuery) > 0)
                                {
                                    strStatus = "1";
                                    strMessage = "SLA Linkage Successfully Done.";
                                }
                                else
                                {
                                    strStatus = "0";
                                    strMessage = "SLA Linkage Failed.";
                                }
                            }
                        }
                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBNocdesk.execute(objQuery.UpdateDocumentMasterData(display["ApplicationID"], display["DocumentType"], display["VersionNumbar"], display["DocumentName"], display["DocumentDescription"], display["Docclassifier"], display["DocuentJSON"], display["DocParentType"], display["DocParentID"], display["startday"], display["EndDay"], display["Status"])) > 0)
                    {
                        strStatus = "1";
                        strMessage = "SLA Linkag Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = " SLA Linkag Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "UpdateDocumentMasterData datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "UpdateDocumentMasterData Exception : " + ex.Message, true);
            }
            return dtconversion.DataTableToJSONString(resultdt);
        }

        public string SDRoutingLinkag(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string DocumentID = "";
                DataTable dtleval = new DataTable();
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                DatabaseHandler objDBSDCategary = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "SDRoutingLinkag parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    string tableJson = display["TData"];
                    dtleval = dtconversion.JsonStringToDataTable(tableJson);
                    for (int i = 0; i < dtleval.Rows.Count; i++)
                    {
                        string SDLinkagType = "";
                        string OUID = "";
                        string SDPersonID = "";
                        string LinkTO = "";
                        string OUType = "2";
                        SDLinkagType = dtleval.Rows[i]["SDLinkType"].ToString();
                        LinkTO = dtleval.Rows[i]["LinkTo"].ToString();
                        if (SDLinkagType=="1")
                        {  
                            OUID = dtleval.Rows[i]["FieldID2"].ToString();     
                        }
                         else if (SDLinkagType == "2"){
                                SDPersonID = dtleval.Rows[i]["FieldID1"].ToString();      
                         }
                        //if (Convert.ToInt16(objDBNocdesk.executeScalar(objQuery.SDRoutingLinkagChack())) > 0)
                        //{

                        //}
                        //else
                        {
                                string strQuery = objQuery.InsertRoutingLinkag(SDLinkagType, display["ContractID"],display["ClauseID"],display["SLAID"],display["SLALevel"],display["OrgID"], OUID, OUType, display["SDRollID"], SDPersonID, display["SDReceivingID"],display["UserID"],display["DeviceID"],display["SDTTemplateID"],display["EndDate"],display["Status"],display["CatID"]);             
                                if (objDBSDCategary.execute(strQuery) > 0)
                                {
                                    strStatus = "1";
                                    strMessage = "SD Linkage Successfully Done.";
                                }
                                else
                                {
                                    strStatus = "0";
                                    strMessage = "SD Linkage Failed.";
                                }    
                        }
                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBNocdesk.execute(objQuery.UpdateDocumentMasterData(display["ApplicationID"], display["DocumentType"], display["VersionNumbar"], display["DocumentName"], display["DocumentDescription"], display["Docclassifier"], display["DocuentJSON"], display["DocParentType"], display["DocParentID"], display["startday"], display["EndDay"], display["Status"])) > 0)
                    {

                    }
                    else
                    {


                    }
                }
                resultdata = "{\"DocumentID\":\"" + DocumentID + "\"}";
                strReturn = "{\"status\":\"" + strStatus + "\",\"status_message\":\"" + strMessage + "\",\"data\":[" + resultdata + "]}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "SDRoutingLinkag datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBSDCategary);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "SDRoutingLinkag Exception : " + ex.Message, true);
            }
            //strReturn= dtconversion.DataTableToJSONString(resultdt);
            return strReturn;
        }

        public string SLARoutingLinkag(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string DocumentID = "";
                DataTable dtleval = new DataTable();
                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                DatabaseHandler objDBSDCategary = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "SLARoutingLinkag parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {       
                        //if (Convert.ToInt16(objDBNocdesk.executeScalar(objQuery.SDRoutingLinkagChack())) > 0)
                        //{

                        //}
                        //else
                        {
                            string strQuery = objQuery.InsertRoutingLinkag(display["SDLinkType"], display["ContractID"], display["ClauseID"], display["SLAID"], display["SLALevel"], display["OrgID"], display["OUID"], display["OULinkType"], display["SDRollID"], display["SDPersonID"], display["SDReceivingID"], display["UserID"], display["DeviceID"], display["SDTTemplateID"], display["EndDate"], display["Status"], display["CatID"]);
                            if (objDBSDCategary.execute(strQuery) > 0)
                            {
                                strStatus = "1";
                                strMessage = "SLA Routing Linkage Successfully Done.";
                            }
                            else
                            {
                                strStatus = "0";
                                strMessage = "SLA Routing Linkage Failed.";
                            }
                        }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBNocdesk.execute(objQuery.UpdateDocumentMasterData(display["ApplicationID"], display["DocumentType"], display["VersionNumbar"], display["DocumentName"], display["DocumentDescription"], display["Docclassifier"], display["DocuentJSON"], display["DocParentType"], display["DocParentID"], display["startday"], display["EndDay"], display["Status"])) > 0)
                    {

                    }
                    else
                    {


                    }
                }
                resultdata = "{\"DocumentID\":\"" + DocumentID + "\"}";
                strReturn = "{\"status\":\"" + strStatus + "\",\"status_message\":\"" + strMessage + "\",\"data\":[" + resultdata + "]}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);

                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "SLARoutingLinkag datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBSDCategary);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "SLARoutingLinkag Exception : " + ex.Message, true);
            }
            //strReturn= dtconversion.DataTableToJSONString(resultdt);
            return strReturn;
        }
        public DataTable DeleteDocumentMaster(string DocumentID)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBNocdesk = LocalConstant.DocumentMasterPool.getConnection();
                if (objDBNocdesk.execute(objQuery.DeleteDocumentMaster(DocumentID)) > 0)
                {
                    row["status"] = "1";
                    row["status_message"] = "DocumentMaster Head Deleted Successfully Done.";
                    // row["data"] = "";
                }
                else
                {
                    row["status"] = "0";
                    row["status_message"] = "DocumentMaster Head Deleted Failed.";
                    //row["data"] = "";
                }
                resultdt.Rows.Add(row);
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "DeleteDocumentMaster datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.DocumentMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("DocumentMaster", "log", "secondlevel", "DeleteDocumentMaster Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        #endregion


    }
}
