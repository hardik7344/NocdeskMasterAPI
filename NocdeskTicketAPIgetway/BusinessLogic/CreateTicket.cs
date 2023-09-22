using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NocdeskTicketAPIgetway.DataAccessLayer;
using NocdeskTicketAPIgetway.Model;
using OwnYITCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskTicketAPIgetway.BusinessLogic
{
    public class CreateTicket
    {
        //DatabaseCommon objcommon = new DatabaseCommon();
        NocDeskCommon objcommon = new NocDeskCommon();
        DataTableConversion dtconversion = new DataTableConversion();
        ParameterJSON jSON_DATA = new ParameterJSON();
        QueryHandler objQuery = new QueryHandler();
        NocDeskCommon objCom = new NocDeskCommon();
        string jsonvalue = "";
        string resultdata = "";
        string OuName = "";
        string JSONresult = string.Empty;
        DataTable resultdt = new DataTable();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        string strStatus = "0"; // 0 - Fail , 1 - Successs , 2 - Already exist
        string strMessage = "";
        string SDCatL1ID = "";
        private int i;
        #region NormlTicket
        //public DataTable CreateTicketdata(string userjson)
        //{
        //    string strReturn = "";
        //    try
        //    {
        //        resultdt.Columns.Add("status", typeof(Int16));
        //        resultdt.Columns.Add("status_message", typeof(string));
        //        resultdt.Columns.Add("data", typeof(string));
        //        var row = resultdt.NewRow();
        //        string TicketID = "";
        //        DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
        //        objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketdata parameter pass json : " + userjson, true);
        //        objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketdata objDBActivity : " + objDBActivity, true);
        //        string strTemp = dtconversion.Base64Decode(userjson);
        //        IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
        //        objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicket DisplayData : " + display, true);

        //        if (display["action_type"] == "1")
        //        {

        //            string StrQuery1 = objQuery.CheckTicketExist(display["TicketType"], display["Problem"], display["Discription"]);
        //            if (objDBActivity.execute(StrQuery1) > 0)
        //            {

        //                strStatus = "2";
        //                strMessage = "Ticket already exist.";
        //            }
        //            else
        //            {
        //                string strQuery = objQuery.CreateTicket(display["ApplicationID"], display["TicketType"], display["TicketTemplateID"], display["parentTicketID"], display["parentTicketType"], display["TicketPriority"], display["SRuserID"], display["CurrentSDUser"], display["CurrentSDRollID"], display["OUID"], display["DeviceID"], display["SLAID"], display["SLALevel"], display["CurrentStatus"], display["Visible"], display["Problem"], display["Discription"], display["catID"], display["subcatID"], display["itemID"]);
        //                if (objDBActivity.execute(strQuery) > 0)
        //                {
        //                    TicketID = objDBActivity.executeScalar(objQuery.GetTicketID());
        //                    strStatus = "1";
        //                    strMessage = "Create Ticket Successfully Done.";
        //                }
        //                else
        //                {
        //                    strStatus = "0";
        //                    strMessage = "Create Ticket Failed.";
        //                }

        //            }
        //        }
        //        else if (display["action_type"] == "2")
        //        {
        //            if (objDBActivity.execute(objQuery.UpdateCreateTicket()) > 0)
        //            {
        //                strStatus = "1";
        //                strMessage = "Create Ticket Updated Successfully Done.";
        //            }
        //            else
        //            {
        //                strStatus = "0";
        //                strMessage = "Create Ticket updated failed.";
        //            }
        //        }
        //        //string Ticketjson = "{\"TicketID\":\"" + TicketID + "\"}";
        //        //resultdata = Ticketjson.ToString();
        //        //strReturn = "{\"status\":\"" + strStatus + "\",\"status_message\":\"" + strMessage + "\",\"data\":[" + resultdata + "]}";
        //        resultdata = "{\"TicketID\":\"" + TicketID + "\"}";
        //        row["status"] = strStatus;
        //        row["status_message"] = strMessage;
        //        row["data"] = resultdata;
        //        resultdt.Rows.Add(row);
        //        objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketData datatable count return : " + resultdt.Rows.Count, true);
        //        LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketData Exception : " + ex.Message, true);
        //    }
        //    return resultdt;
        //}
        public string CreateTicketdata(string userjson)
        {
            string strReturn = "";
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string TicketID = "";
                string ActID = "";
                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketdata parameter pass json : " + userjson, true);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketdata objDBActivity : " + objDBActivity, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicket DisplayData : " + display, true);

                if (display["action_type"] == "1")
                {

                    string StrQuery1 = objQuery.CheckTicketExist(display["TicketType"], display["Problem"], display["Discription"]);
                    if (objDBActivity.execute(StrQuery1) > 0)
                    {

                        strStatus = "2";
                        strMessage = "Ticket already exist.";
                    }
                    else
                    {
                        string strQuery = objQuery.CreateTicket(display["ApplicationID"], display["TicketType"], display["TicketTemplateID"], display["parentTicketID"], display["parentTicketType"], display["TicketPriority"], display["SRuserID"], display["CurrentSDUser"], display["CurrentSDRollID"], display["OUID"], display["DeviceID"], display["SLAID"], display["SLALevel"], display["CurrentStatus"], display["Visible"], display["Problem"], display["Discription"], display["catID"], display["subcatID"], display["itemID"]);
                        if (objDBActivity.execute(strQuery) > 0)
                        {

                            TicketID = objDBActivity.executeScalar(objQuery.GetTicketID());
                            ActID = objDBActivity.executeScalar(objQuery.GetSerialNumbar(TicketID));
                            TicketEventDetails(TicketID, display["TicketType"], ActID, "", display["CurrentStatus"],"", display["CurrentSDRollID"], display["SRuserID"], display["Discription"], "", "");
                            strStatus = "1";
                            strMessage = "Create Ticket Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Create Ticket Failed.";
                        }

                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Create Ticket Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Create Ticket updated failed.";
                    }
                }
                //string Ticketjson = "{\"TicketID\":\"" + TicketID + "\"}";
                //resultdata = Ticketjson.ToString();
                resultdata = "{\"TicketID\":\"" + TicketID + "\"}";
                strReturn = "{\"status\":\"" + strStatus + "\",\"status_message\":\"" + strMessage + "\",\"data\":[" + resultdata + "]}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketData datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketData Exception : " + ex.Message, true);
            }
            return strReturn;
        }

        public string TicketEventDetails(string TicketID, string TicketType,string ActID,string PActID,string StatusID,string ActTypeID, string SDPersonType, string SDPersonID,string Details1, string Details2, string Json)
        {
            string Event="";
            ActTypeID = "1";
           DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
            objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateTicketdata objDBActivity : " + objDBActivity, true);
            if (TicketType!= "Workflow Ticket")
            {
                PActID = "00";
            }
            string strQuery = objQuery.CreateTicketEventDetails(TicketID,TicketType,ActID,PActID,StatusID, ActTypeID,SDPersonType,SDPersonID,Details1,Details2,Json);
            objDBActivity.executeScalar(objQuery.UpdateTicketEventDetails(TicketID));
            if (objDBActivity.execute(strQuery) > 0)
            {
                
            }
            else
            {
               
            }
            return Event;
        }

        public DataTable GetTicketdata(string SRuserID, string UserType, string TicketType)
        {
            DataTable dt2 = new DataTable();
            try
            {
                string strCond = "";
                if (UserType == "User")
                    strCond = " where SRuserID=" + SRuserID + " And TicketType = " + TicketType;
                else if (UserType == "Service Manager")
                    strCond = "";
                else if (UserType == "Contract Manager")
                    strCond = "";
                else if (UserType == "Service Delivery")
                    strCond = " where CurrentSDUser=" + SRuserID + " or SRuserID = " + SRuserID + " And TicketType = " + TicketType;
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                DatabaseHandler objDBSD = LocalConstant.ServiceDeliveryPool.getConnection();
                string query2 = objQuery.GetSDCategaryData();
                dt1 = objDBSD.getDatatable(query2);
                string query1 = objQuery.GetTicketdata(strCond);
                dt2 = objDBNocdesk.getDatatable(query1);
                dt2.Columns.Add("CatName");
                dt2.Columns.Add("SubCatName");
                dt2.Columns.Add("ItemName");
                foreach (DataRow dr in dt2.Rows)
                {
                    string catID = dr["SDCategorizationL1"].ToString();
                    string subCatID = dr["SDCategorizationL2"].ToString();
                    string itemID = dr["SDCategorizationL3"].ToString();
                    if (catID != "" && subCatID != "" && itemID != "")
                    {
                        string strcond1 = "SDCatL1ID = " + catID + " and SDcatL2ID = " + subCatID + " and SDcatL3ID = " + itemID + "";
                        DataRow[] drArr = dt1.Select(strcond1);
                        //DataRow[] drArr = dt1.Select("SDCatL1ID =" + dr["SDCategorizationL1"].ToString() + " && SDcatL2ID =" + dr["SDCategorizationL2"].ToString()+ " && SDcatL3ID=" + dr["SDCategorizationL3"].ToString());\
                        if (drArr.Length > 0)
                        {
                            dr["CatName"] = drArr[0]["SDCatL1Name"].ToString();
                            dr["SubCatName"] = drArr[0]["SDCatL2Name"].ToString();
                            dr["ItemName"] = drArr[0]["SDCatL3Name"].ToString();
                        }
                    }
                }
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketdata datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBSD);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketdata Exception : " + ex.Message, true);
            }
            return dt2;
        }
        public DataTable GetTicketActiviteData(string TicketId, string TicketType)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTicketActiviteData(TicketId, TicketType));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketActiviteData datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);


            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable GetTicketServiceDelivery()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTicketServiceDelivery());
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketServiceDelivery datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketServiceDelivery Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetTicketDetailsdata(string TicketID, string TicketType)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetTicketDetailsdata(TicketID, TicketType));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketDetailsdata datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketDetailsdata Exception : " + ex.Message, true);
            }
            return dt;
        }
        #endregion
        #region Tickets
        //public DataTable GetGroupTicket(string OUID, string Category, string SubCategory, string item)
        //{
        //    try
        //    {
        //        string Search = "";
        //        DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
        //        if (OUID != "" && OUID != null && OUID != "-1")
        //        {
        //            Search += " and OUID = '" + OUID + "'";
        //        }
        //        if (Category != "" && Category != null && Category != "-1")
        //        {
        //            Search += "  and SDCategorizationL1 = '" + Category + "'";
        //        }
        //        if (SubCategory != "" && SubCategory != null && SubCategory != "-1")
        //        {
        //            Search += " and SDCategorizationL2 =  '" + SubCategory + "'";
        //        }
        //        if (item != "" && item != null && item != "-1")
        //        {
        //            Search += " and SDCategorizationl3 = '" + item + "'";
        //        }
        //        dt = objDBNocdesk.getDatatable(objQuery.GetGroupTicket(Search));

        //        objcommon.WriteLog("CreateTicket", "log", "CreateTicket MicroService", "GetTicketDetailsdata datatable count return : " + dt.Rows.Count, true);
        //        LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("CreateTicket", "log", "CreateTicket MicroService", "GetTicketDetailsdata Exception : " + ex.Message, true);
        //    }
        //    return dt;
        //}

        public DataTable GetGroupTicket(string OUID, string Category, string SubCategory, string item)
        {
            DataTable dt2 = new DataTable();
            try
            {
                string Search = "";
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                DatabaseHandler objDBSD = LocalConstant.ServiceDeliveryPool.getConnection();
                if (OUID != "" && OUID != null && OUID != "-1")
                {
                    Search += " and OUID = '" + OUID + "'";
                }
                if (Category != "" && Category != null && Category != "-1")
                {
                    Search += "  and SDCategorizationL1 = '" + Category + "'";
                }
                if (SubCategory != "" && SubCategory != null && SubCategory != "-1")
                {
                    Search += " and SDCategorizationL2 =  '" + SubCategory + "'";
                }
                if (item != "" && item != null && item != "-1")
                {
                    Search += " and SDCategorizationl3 = '" + item + "'";
                }
                string query2 = objQuery.GetSDCategaryData();
                dt1 = objDBSD.getDatatable(query2);
                dt2 = objDBNocdesk.getDatatable(objQuery.GetGroupTicket(Search));
                dt2.Columns.Add("CatName");
                dt2.Columns.Add("SubCatName");
                dt2.Columns.Add("ItemName");
                foreach (DataRow dr in dt2.Rows)
                {
                    string catID = dr["SDCategorizationL1"].ToString();
                    string subCatID = dr["SDCategorizationL2"].ToString();
                    string itemID = dr["SDCategorizationL3"].ToString();
                    if (catID != "" && subCatID != "" && itemID != "")
                    {
                        string strcond1 = "SDCatL1ID = " + catID + " and SDcatL2ID = " + subCatID + " and SDcatL3ID = " + itemID + "";
                        DataRow[] drArr = dt1.Select(strcond1);
                        //DataRow[] drArr = dt1.Select("SDCatL1ID =" + dr["SDCategorizationL1"].ToString() + " && SDcatL2ID =" + dr["SDCategorizationL2"].ToString()+ " && SDcatL3ID=" + dr["SDCategorizationL3"].ToString());\
                        if (drArr.Length > 0)
                        {
                            dr["CatName"] = drArr[0]["SDCatL1Name"].ToString();
                            dr["SubCatName"] = drArr[0]["SDCatL2Name"].ToString();
                            dr["ItemName"] = drArr[0]["SDCatL3Name"].ToString();
                        }
                    }
                }
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetGroupTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBSD);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetGroupTicket Exception : " + ex.Message, true);
            }
            return dt2;
        }
        public async Task<DataTable> CreateGroupTicketdata(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create_Group_Ticket_data_parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    string tableJson = display["Checkbox"];
                    DataTable dtleval = new DataTable();
                    dtleval = dtconversion.JsonStringToDataTable(tableJson);
                    string Category = "";
                    string SubCategory = "";
                    string Item = "";
                    string TicketName = "";
                    string TicketDesc = "";
                    string SRuserID = display["SRUserID"];
                    string OUID = "";
                    string User_json = JsonConvert.SerializeObject(dtleval).ToString();
                    Category = dtleval.Rows[0]["catID"].ToString();
                    SubCategory = dtleval.Rows[0]["subcatID"].ToString();
                    Item = dtleval.Rows[0]["itemID"].ToString();
                    TicketName = dtleval.Rows[0]["TicketName"].ToString();
                    TicketDesc = dtleval.Rows[0]["TicketDesc"].ToString();
                    OUID = dtleval.Rows[0]["OUID"].ToString();
                    string GroupTicket = "{\"action_type\":1,\"ApplicationID\":11,\"TicketType\":\"Group Ticket\",\"Problem\":\"<GroupTicketName>\",\"Discription\":\"<GroupTicketDesc>\",\"catID\":\"<catID>\",\"Category\":\"<category>\",\"subcatID\":\"<subcatID>\",\"SubCategory\":\"<subcategory>\",\"itemID\":\"<itemID>\",\"Item\":\"<item>\",\"TicketTemplateID\":\"\",\"parentTicketID\":\"\",\"parentTicketType\":\"\",\"TicketPriority\":\"\",\"SRuserID\":\"<UserID>\",\"CurrentSDUser\":\"\",\"CurrentSDRollID\":\"\",\"OUID\":\"<OUID>\",\"DeviceID\":\"\",\"SLAID\":\"\",\"SLALevel\":\"\",\"CurrentStatus\":\"\",\"Visible\":\"\"}";
                    GroupTicket = GroupTicket.Replace("<GroupTicketName>", TicketName).Replace("<GroupTicketDesc>", TicketDesc).Replace("<catID>", Category).Replace("<subcatID>", SubCategory).Replace("<itemID>", Item).Replace("<OUID>", OUID).Replace("<UserID>", SRuserID);
                    string user_json = dtconversion.Base64Encode(GroupTicket);
                    jSON_DATA.user_json = user_json;
                    string baseUrl = LocalConstant.NocdeskTicket + "/NocdeskTicket/CreateTicket/CreateTicketdata";
                    resultdata = await CallingMethod.post_method(baseUrl, jSON_DATA);
                    DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                    DatabaseHandler objTemplateMaster = LocalConstant.TemplateMasterPool.getConnection();
                    string strQuery = objQuery.GetTicketID(display["TicketType"], TicketName, TicketDesc);
                    DataTable dtTicketID = objDBActivity.getDatatable(strQuery);
                    string MasterTicketID = "";
                    string MasterCurrentStatus = "";
                    if (dtTicketID.Rows.Count > 0)
                    {
                        MasterTicketID = dtTicketID.Rows[0]["TicketID"].ToString();
                        MasterCurrentStatus = dtTicketID.Rows[0]["CurrentStatus"].ToString();
                    }
                    for (int i = 0; i < dtleval.Rows.Count; i++)
                    {
                        string Ticket_ID = "";
                        string Ticket_Name = "";
                        string Jsondata = JsonConvert.SerializeObject(dtleval).ToString();
                        Ticket_ID = dtleval.Rows[i]["TicketID"].ToString();
                        Ticket_Name = dtleval.Rows[i]["TicketName"].ToString();
                        string str_Query = objQuery.GroupTicketActivation(MasterTicketID, MasterCurrentStatus, Ticket_ID, Ticket_Name);
                        if (objDBNocdesk.execute(str_Query) > 0)
                        {
                            strStatus = "1";
                            strMessage = "Group Ticket Created Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Group Ticket Created Failed.";
                        }
                    }

                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Group Ticket Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Group Ticket Linkeg Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create_Group_Ticket_data_parameter count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create_Group_Ticket_data Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable GetMasterTicket()
        {     
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetMasterTicket());  
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetMasterTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketDetailsdata Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetNoramTicketOfMaster(string parentTicketID)
        {
            DataTable dt2 = new DataTable();
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                DatabaseHandler objDBSD = LocalConstant.ServiceDeliveryPool.getConnection();
                string query2 = objQuery.GetSDCategaryData();
                dt1 = objDBSD.getDatatable(query2);
                dt2 = objDBNocdesk.getDatatable(objQuery.GetNoramTicketOfMaster(parentTicketID));
                dt2.Columns.Add("CatName");
                dt2.Columns.Add("SubCatName");
                dt2.Columns.Add("ItemName");
                foreach (DataRow dr in dt2.Rows)
                {
                    string catID = dr["SDCategorizationL1"].ToString();
                    string subCatID = dr["SDCategorizationL2"].ToString();
                    string itemID = dr["SDCategorizationL3"].ToString();
                    if (catID != "" && subCatID != "" && itemID != "")
                    {
                        string strcond1 = "SDCatL1ID = " + catID + " and SDcatL2ID = " + subCatID + " and SDcatL3ID = " + itemID + "";
                        DataRow[] drArr = dt1.Select(strcond1);
                        //DataRow[] drArr = dt1.Select("SDCatL1ID =" + dr["SDCategorizationL1"].ToString() + " && SDcatL2ID =" + dr["SDCategorizationL2"].ToString()+ " && SDcatL3ID=" + dr["SDCategorizationL3"].ToString());\
                        if (drArr.Length > 0)
                        {
                            dr["CatName"] = drArr[0]["SDCatL1Name"].ToString();
                            dr["SubCatName"] = drArr[0]["SDCatL2Name"].ToString();
                            dr["ItemName"] = drArr[0]["SDCatL3Name"].ToString();
                        }
                    }
                }

                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetNoramTicketOfMaster datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBSD);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetNoramTicketOfMaster Exception : " + ex.Message, true);
            }
            return dt2;
        }

        public async Task<DataTable> CreateMesterTicketdata(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                DatabaseHandler objTemplateMaster = LocalConstant.TemplateMasterPool.getConnection();
                DatabaseHandler objserviceDelivaery = LocalConstant.ServiceDeliveryPool.getConnection();
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    string SDCategorizationL1 = "";
                    string SDCategorizationL2 = "";
                    string SDCategorizationl3 = "";
                    string SRNO = "";
                    string LinkTo = "";
                    string Field = "";
                    string TicketPriorite = "";
                    string Visibel = "0";
                    string ouid = "";
                    string userid = "";
                    string OUNAME = "";
                    string UserName = "";
                    string MasterTicketID = "";
                    DataTable dtleval = new DataTable();
                    DataTable dtTemplate = new DataTable();
                    string TemplatePID = display["TID"].ToString();
                    string TemplateTMName = display["TName"].ToString();
                    string SRUserID = display["SRUserID"].ToString();
                    string tableJson = display["TData"];
                    dtleval = dtconversion.JsonStringToDataTable(tableJson);
                    string strQuery1 = objQuery.GetTemplateData(TemplateTMName);
                    dtTemplate = objTemplateMaster.getDatatable(strQuery1);
                    string MasterTemplateType = "";
                    if (dtTemplate.Rows.Count > 0)
                    {
                        MasterTemplateType = dtTemplate.Rows[0]["SDTTEmplateType"].ToString();
                    }
                    if (dtleval.Rows.Count > 0)
                    {
                        for (i = 0; i < dtleval.Rows.Count; i++)
                        {
                            LinkTo = dtleval.Rows[i]["LinkTo"].ToString();
                            if (LinkTo.ToUpper() == "OU")
                            {
                                ouid = dtleval.Rows[i]["FieldID"].ToString();
                                //OUNAME = dtleval.Rows[i]["Field"].ToString();
                            }
                            else if (LinkTo == "User")
                            {
                                userid = dtleval.Rows[i]["FieldID"].ToString();
                              
                            }
                            else
                            {
                                ouid = "";  
                                userid = "";
                            }
                        }
                    }
                    string MesterTicket = "{\"action_type\":1,\"ApplicationID\":11,\"TicketType\":\"<TicketType>\",\"Problem\":\"<MasterTicketName>\",\"Discription\":\"<MasterTicketDesc>\",\"catID\":\"<categoryid>\",\"Category\":\"<category>\",\"subcatID\":\"<Subcategoryid>\",\"SubCategory\":\"<subcategory>\",\"itemID\":\"<Itemid>\",\"Item\":\"<item>\",\"TicketTemplateID\":\"<TicketTemplateID>\",\"parentTicketID\":\"\",\"parentTicketType\":\"\",\"TicketPriority\":\"<TicketPriority>\",\"SRuserID\":\"<SRuserID>\",\"CurrentSDUser\":\"\",\"CurrentSDRollID\":\"\",\"OUID\":\"<OUID>\",\"DeviceID\":\"\",\"SLAID\":\"\",\"SLALevel\":\"\",\"CurrentStatus\":\"\",\"Visible\":\"<Visible>\"}";
                    MesterTicket = MesterTicket.Replace("<TicketType>", display["TicketType"]).Replace("<MasterTicketName>", display["TName"]).Replace("<MasterTicketDesc>", display["TName"]).Replace("<categoryid>", "").Replace("<Subcategoryid>", "").Replace("<Itemid>", "").Replace("<TicketTemplateID>", display["TID"]).Replace("<OUID>", ouid).Replace("<SRuserID>", SRUserID).Replace("<TicketPriority>", TicketPriorite).Replace("<Visible>", Visibel);
                    //objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTicket datatable count return : " + MesterTicket, true);
                    string user_json = dtconversion.Base64Encode(MesterTicket);
                    jSON_DATA.user_json = user_json;
                    //objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTicket 64_Encode_User_json datatable count return : " + user_json, true);
                    string baseUrl = LocalConstant.NocdeskTicket + "/NocdeskTicket/CreateTicket/CreateTicketdata";
                    //objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTicket baseUrl datatable count return : " + baseUrl + "UserJSON :" + jSON_DATA, true);
                    resultdata = await CallingMethod.post_method(baseUrl, jSON_DATA);
                    resultdata = resultdata.Substring(1, resultdata.Length - 2).Replace("\\", "");
                    JObject json = JObject.Parse(resultdata.ToString());
                    string Documentdata = json["data"].ToString();
                    Documentdata = Documentdata.Substring(1, Documentdata.Length - 2).Replace("\r\n", "");
                    JObject json1 = JObject.Parse(Documentdata.ToString());
                    MasterTicketID  = json1["TicketID"].ToString();
                    //objcommon.WriteLog("CreateTicket", "log", "Ticket", "resultdata MasterTicket\\CreateTicketdata : " + resultdata, true);
                    for (i = 0; i < dtleval.Rows.Count; i++)
                    {
                        SRNO = dtleval.Rows[i]["SRNO"].ToString();
                        LinkTo = dtleval.Rows[i]["LinkTo"].ToString();
                        Field = dtleval.Rows[i]["Field"].ToString();
                        DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                        string strQuery2 = objQuery.GetTicketID(display["TicketType"], display["TName"], display["TName"]);
                        //objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetTicketID OF Master Ticket datatable count return : " + strQuery2, true);
                        DataTable dtTicketID = objDBActivity.getDatatable(strQuery2);
                        string Mastercurentstatus = "";
                        string CurrentSDUser = "";
                        string MasterTicketType = "";
                        if (dtTicketID.Rows.Count > 0)
                        {   
                            MasterTicketType= dtTicketID.Rows[i]["TicketType"].ToString();
                            Mastercurentstatus = dtTicketID.Rows[i]["CurrentStatus"].ToString();
                            CurrentSDUser = dtTicketID.Rows[i]["CurrentSDUser"].ToString();
                        }
                        string strQuery3 = objQuery.GetMasterdata(TemplatePID, MasterTemplateType);
                        //objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get Tamplate OF Master datatable count return : " + strQuery3, true);
                        DataTable dtTemplateData = objTemplateMaster.getDatatable(strQuery3);
                        string SDChildTTID = "";
                        string SDChildTTDesc = "";
                        string Status = "";
                        for (i = 0; i < dtTemplateData.Rows.Count; i++)
                        {
                            SDChildTTID = dtTemplateData.Rows[i]["SDChildTTID"].ToString();
                            SDChildTTDesc = dtTemplateData.Rows[i]["SDChildTTDesc"].ToString();
                            Status = dtTemplateData.Rows[i]["Status"].ToString();
                            string Str_Query1 = objQuery.MasterToNormalLinkage(SDChildTTID);
                            DataTable NormalTicketLinkage = objserviceDelivaery.getDatatable(Str_Query1);
                            if (NormalTicketLinkage.Rows.Count > 0)
                            {
                                SDCategorizationL1 = NormalTicketLinkage.Rows[0]["SDCatL1ID"].ToString();
                                SDCategorizationL2 = NormalTicketLinkage.Rows[0]["SDcatL2ID"].ToString();
                                SDCategorizationl3 = NormalTicketLinkage.Rows[0]["SDcatL3ID"].ToString();
                            }
                            string str_Query = objQuery.MasterTicketActivation(MasterTicketID, SDChildTTID, Status);
                            string NormalTicket = "{\"action_type\":1,\"ApplicationID\":11,\"TicketType\":\"Normal Ticket\",\"Problem\":\"<MasterTicketName>\",\"Discription\":\"<MasterTicketDesc>\",\"catID\":\"<catID>\",\"Category\":\"<category>\",\"subcatID\":\"<subcatID>\",\"SubCategory\":\"<subcategory>\",\"itemID\":\"<itemID>\",\"Item\":\"<item>\",\"TicketTemplateID\":\"<TicketTemplateID>\",\"parentTicketID\":\"<parentTicketID>\",\"parentTicketType\":\"<parentTicketType>\",\"TicketPriority\":\"\",\"SRuserID\":\"<SRuserID>\",\"CurrentSDUser\":\"\",\"CurrentSDRollID\":\"\",\"OUID\":\"<OUID>\",\"DeviceID\":\"\",\"SLAID\":\"\",\"SLALevel\":\"\",\"CurrentStatus\":\"\",\"Visible\":\"\"}";
                            NormalTicket = NormalTicket.Replace("<MasterTicketName>", SDChildTTDesc).Replace("<MasterTicketDesc>", SDChildTTDesc).Replace("<catID>", SDCategorizationL1).Replace("<subcatID>", SDCategorizationL2).Replace("<itemID>", SDCategorizationl3).Replace("<TicketTemplateID>", SDChildTTID).Replace("<parentTicketID>", MasterTicketID).Replace("<OUID>", ouid).Replace("<SRuserID>", userid).Replace("<parentTicketType>", MasterTicketType);
                            objcommon.WriteLog("CreateTicket", "log", "Ticket", "Normal Ticket OF Master Template datatable count return : " + NormalTicket, true);
                            string Normal_user_json = dtconversion.Base64Encode(NormalTicket);
                            objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTick_Normal_ticket_BASE64_Encode_data datatable count return : " + Normal_user_json, true);
                            jSON_DATA.user_json = Normal_user_json;
                            string Normal_baseUrl = LocalConstant.NocdeskTicket + "/NocdeskTicket/CreateTicket/CreateTicketdata";
                            objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTick_Normal_ticket_URl datatable count return : " + Normal_baseUrl, true);
                            resultdata = await CallingMethod.post_method(Normal_baseUrl, jSON_DATA);
                            if (objDBNocdesk.execute(str_Query) > 0)
                            {
                                strStatus = "1";
                                strMessage = "Master Ticket Created Successfully Done.";
                            }
                            else
                            {
                                strStatus = "0";
                                strMessage = "Master Ticket Created Failed.";
                            }
                        }


                    }

                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Master Ticket Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Master Ticket Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTicket datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "MasterTicket Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable GetPannedTicket()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();

                dt = objDBNocdesk.getDatatable(objQuery.GetPannedTicket());

                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetPannedTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetPannedTicket Exception : " + ex.Message, true);
            }
            return dt;
        }

        public async Task<DataTable> CreatePanneTicketdata(string userjson)
        {
            try
            {  
                string Status = "";              
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string previousTicketID = "";
                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                DatabaseHandler objserviceDelivaery = LocalConstant.ServiceDeliveryPool.getConnection();
                DatabaseHandler objTemplateMaster = LocalConstant.TemplateMasterPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreatePanneTicketdata parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    string TemplatePID = display["TID"].ToString();
                    string TemplateTMName = display["TName"].ToString();
                    string tableJson = display["TData"];
                    DataTable dtleval = new DataTable();
                    dtleval = dtconversion.JsonStringToDataTable(tableJson);
                    string strQuery1 = objQuery.GetTemplateData(TemplateTMName);
                    DataTable dtTemplate = objDBActivity.getDatatable(strQuery1);
                    string MasterTemplateType = "";
                    if (dtTemplate.Rows.Count > 0)
                    {
                        MasterTemplateType = dtTemplate.Rows[0]["SDTTEmplateType"].ToString();
                    }
                    string ouid = "";
                    string userid = "";
                    string SRNO = "";
                    string LinkTo = "";
                    string Field = "";
                    if (dtleval.Rows.Count > 0)
                    {

                        for (i = 0; i < dtleval.Rows.Count; i++)
                        {
                            LinkTo = dtleval.Rows[i]["LinkTo"].ToString();
                            if (LinkTo.ToUpper() == "OU")
                                ouid = dtleval.Rows[i]["FieldID"].ToString();
                            if (LinkTo == "User")
                                userid = dtleval.Rows[i]["FieldID"].ToString();
                        }

                    }
                    objcommon.WriteLog("CreateTicket", "log", "Ticket", "tableJson datatable count return : " + strTemp, true);
                    string PannedTicket = "{\"action_type\":1,\"ApplicationID\":\"<ApplicationID>\",\"TicketType\":\"<TicketType>\",\"Problem\":\"<PannedTicketName>\",\"Discription\":\"<PannedTicketDesc>\",\"catID\":\"<catID>\",\"Category\":\"<category>\",\"subcatID\":\"<subcatID>\",\"SubCategory\":\"<subcategory>\",\"itemID\":\"<itemID>\",\"Item\":\"<item>\",\"TicketTemplateID\":\"<TicketTemplateID>\",\"parentTicketID\":\"\",\"parentTicketType\":\"\",\"TicketPriority\":\"\",\"SRuserID\":\"<SRuserID>\",\"CurrentSDUser\":\"\",\"CurrentSDRollID\":\"\",\"OUID\":\"<OUID>\",\"DeviceID\":\"\",\"SLAID\":\"\",\"SLALevel\":\"\",\"CurrentStatus\":\"\",\"Visible\":\"\"}";
                    PannedTicket = PannedTicket.Replace("<ApplicationID>", display["ApplicationID"]).Replace("<TicketType>", display["TicketType"]).Replace("<PannedTicketName>", TemplateTMName).Replace("<PannedTicketDesc>", TemplateTMName).Replace("<catID>", "").Replace("<subcatID>", "").Replace("<itemID>", "").Replace("<TicketTemplateID>", TemplatePID).Replace("<SRuserID>", display["SRUserID"]).Replace("<OUID>", ouid);
                    objcommon.WriteLog("CreateTicket", "log", "Ticket", "PannedTicket datatable count return : " + PannedTicket, true);
                    string user_json = dtconversion.Base64Encode(PannedTicket);
                    jSON_DATA.user_json = user_json;
                    objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreatePannedTicket 64_Encode_User_json datatable count return : " + user_json, true);
                    string baseUrl = LocalConstant.NocdeskTicket + "/NocdeskTicket/CreateTicket/CreateTicketdata";
                    objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreatePannedTicket baseUrl datatable count return : " + baseUrl, true);
                    resultdata = await CallingMethod.post_method(baseUrl, jSON_DATA);
                 
                    for (i = 0; i < dtleval.Rows.Count; i++)
                    {
                        SRNO = dtleval.Rows[i]["SRNO"].ToString();
                        Field = dtleval.Rows[i]["Field"].ToString();
                        LinkTo = dtleval.Rows[i]["LinkTo"].ToString();
                        if (LinkTo.ToUpper() == "OU")
                            ouid = dtleval.Rows[i]["FieldID"].ToString();
                        if (LinkTo == "User")
                            userid = dtleval.Rows[i]["FieldID"].ToString();
                        DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                        string strQuery2 = objQuery.GetTicketID(display["TicketType"], display["TName"], display["TName"]);
                        DataTable dtTicketID = objDBActivity.getDatatable(strQuery2);
                        string MasterTicketID = "";
                        string MasterTicketType = "";
                        string Mastercurentstatus = "";
                        if (dtTicketID.Rows.Count > 0)
                        {
                            MasterTicketID = dtTicketID.Rows[i]["TicketID"].ToString();
                            MasterTicketType = dtTicketID.Rows[i]["TicketType"].ToString();     
                            Mastercurentstatus = dtTicketID.Rows[i]["CurrentStatus"].ToString();

                        }
                        string strQuery3 = objQuery.GetMasterdata(display["TID"], display["TicketTemplateType"]);
                        objcommon.WriteLog("CreateTicket", "log", "Ticket", "PannedTicket_template_flow_data datatable count return : " + strQuery3, true);
                        DataTable dtTemplateData = objTemplateMaster.getDatatable(strQuery3);

                        DataTable dtTicket = new DataTable();
                        dtTicket.Columns.Add("ticketID");
                        dtTicket.Columns.Add("SRNO");
                        dtTicket.Columns.Add("PreSequence");
                        string SDChildTTID = "";
                        string SDChildTTDesc = "";
                        string SDChildPreSeq = "";
                        string SDChildTTSerialNo = "";
                        for (i = 0; i < dtTemplateData.Rows.Count; i++)
                        {
                            SDChildPreSeq = dtTemplateData.Rows[i]["SDChildPreSeq"].ToString();
                            SDChildTTSerialNo = dtTemplateData.Rows[i]["SDChildTTSerialNo"].ToString();
                            SDChildTTID = dtTemplateData.Rows[i]["SDChildTTID"].ToString();
                            SDChildTTDesc = dtTemplateData.Rows[i]["SDChildTTDesc"].ToString();
                            Status = dtTemplateData.Rows[i]["Status"].ToString();
                            string Str_Query1 = objQuery.MasterToNormalLinkage(SDChildTTID);
                            DataTable NormalTicketLinkage = objserviceDelivaery.getDatatable(Str_Query1);
                            string SDCategorizationL1 = "";
                            string SDCategorizationL2 = "";
                            string SDCategorizationl3 = "";
                            if (NormalTicketLinkage.Rows.Count > 0)
                            {
                                SDCategorizationL1 = NormalTicketLinkage.Rows[0]["SDCatL1ID"].ToString();
                                SDCategorizationL2 = NormalTicketLinkage.Rows[0]["SDcatL2ID"].ToString();
                                SDCategorizationl3 = NormalTicketLinkage.Rows[0]["SDcatL3ID"].ToString();
                            }
                            string NormalTicket = "{\"action_type\":1,\"ApplicationID\":11,\"TicketType\":\"Normal Ticket\",\"Problem\":\"<MasterTicketName>\",\"Discription\":\"<MasterTicketDesc>\",\"catID\":\"<catID>\",\"Category\":\"<category>\",\"subcatID\":\"<subcatID>\",\"SubCategory\":\"<subcategory>\",\"itemID\":\"<itemID>\",\"Item\":\"<item>\",\"TicketTemplateID\":\"<TicketTemplateID>\",\"parentTicketID\":\"<parentTicketID>\",\"parentTicketType\":\"<parentTicketType>\",\"TicketPriority\":\"\",\"SRuserID\":\"<SRuserID>\",\"CurrentSDUser\":\"\",\"CurrentSDRollID\":\"\",\"OUID\":\"<OUID>\",\"DeviceID\":\"\",\"SLAID\":\"\",\"SLALevel\":\"\",\"CurrentStatus\":\"\",\"Visible\":\"\"}";
                            NormalTicket = NormalTicket.Replace("<MasterTicketName>", SDChildTTDesc).Replace("<MasterTicketDesc>", SDChildTTDesc).Replace("<catID>", SDCategorizationL1).Replace("<subcatID>", SDCategorizationL2).Replace("<itemID>", SDCategorizationl3).Replace("<TicketTemplateID>", SDChildTTID).Replace("<parentTicketID>", MasterTicketID).Replace("<OUID>", ouid).Replace("<SRuserID>", display["SRUserID"]).Replace("<parentTicketType>", MasterTicketType);
                            objcommon.WriteLog("CreateTicket", "log", "Ticket", "PannedTicket_Normal_ticket_create_Using_Normal_template datatable count return : " + NormalTicket, true);
                            string Normal_user_json = dtconversion.Base64Encode(NormalTicket);
                            objcommon.WriteLog("CreateTicket", "log", "Ticket", "PannedTicket_Normal_ticket_BASE64_Encode_data datatable count return : " + Normal_user_json, true);
                            jSON_DATA.user_json = Normal_user_json;
                            string Normal_baseUrl = LocalConstant.NocdeskTicket + "/NocdeskTicket/CreateTicket/CreateTicketdata";
                            objcommon.WriteLog("CreateTicket", "log", "Ticket", "PannedTicket_Normal_ticket_URl datatable count return : " + Normal_baseUrl, true);
                            resultdata = await CallingMethod.post_method(Normal_baseUrl, jSON_DATA);
                            DataTable TicketID = new DataTable();
                            string NoramlTicketID = "";
                            TicketID = dtconversion.JsonStringToDataTable(resultdata);
                            if (TicketID.Rows.Count > 0)
                            {
                                Dictionary<string, string> ddata = dtconversion.getJSONPropertiesFromString("[" + TicketID.Rows[0]["data"].ToString() + "]");
                                NoramlTicketID = ddata["TicketID"].ToString();
                                DataRow dr = dtTicket.NewRow();
                                dr["ticketID"] = NoramlTicketID;
                                dr["SRNO"] = SDChildTTSerialNo;
                                dr["PreSequence"] = SDChildPreSeq;
                                dtTicket.Rows.Add(dr);
                            }
                            string str_Query = objQuery.PannedTicketActivation(MasterTicketID, NoramlTicketID, Status, SDChildPreSeq, SDChildTTSerialNo, previousTicketID);
                            if (objDBNocdesk.execute(str_Query) > 0)
                            {
                                strStatus = "1";
                                strMessage = "Panned Ticket Created Successfully Done.";
                            }
                            else
                            {
                                strStatus = "0";
                                strMessage = "Panned Ticket Created Failed.";
                            }
                        }
                        foreach (DataRow dr in dtTicket.Rows)
                        {
                            string preTicketID = "";
                            string ticketID = "";
                            if (dr["PreSequence"].ToString() == "0")
                            {
                                ticketID = dr["ticketID"].ToString();
                                objDBActivity.execute(objQuery.UpdateTicket(ticketID));
                            }
                            else
                            {
                                DataRow[] drArr = dtTicket.Select("SRNO='" + dr["PreSequence"].ToString() + "'");
                                if (drArr.Length > 0)
                                {
                                    preTicketID = drArr[0]["ticketID"].ToString();
                                    ticketID = dr["ticketID"].ToString();
                                    objDBActivity.execute(objQuery.updatepreTicketID(preTicketID, ticketID));

                                }
                            }

                        }
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreatePannedTicket datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
            }

            return resultdt;
        }
        public DataTable GetExceptionTicket(string TicketType, string GetDeliveryID)
        {

            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetExceptionTicket(TicketType, GetDeliveryID));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetExceptionTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetExceptionTicket Exception : " + ex.Message, true);
            }
            return dt; ;
        }
        public DataTable GetUserExceptionTicket(string TicketType, string UserID)
        {

            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetUserExceptionTicket(TicketType, UserID));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetUserExceptionTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetUserExceptionTicket Exception : " + ex.Message, true);
            }
            return dt; ;
        }
        public DataTable CreateExceptionTicket(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string TicketID = "";
                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create ExceptionTicket parameter pass json : " + userjson, true);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create ExceptionTicket parameter pass json : " + objDBActivity, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create ExceptionTicket display : " + display, true);

                if (display["action_type"].ToString() == "1")
                {

                    {
                        string SLAID = "0";
                        string strQuery = objQuery.CreateExpectionTicket(display["ApplicationID"], display["TicketType"], display["TicketTempleteID"], display["parentTicketID"], display["parentTicketType"], display["TicketPriority"], display["SRuserID"], display["UserID"], display["RollID"], display["OUID"], display["DeviceID"], SLAID, display["CurrentSLALevel"], display["Status"], display["StartDate"], display["CurrentStatusDate"], display["EndDate"], display["Visible"], display["SDCatID"], display["SDCatL1ID"], display["SDCatL2ID"], display["SDCatL3ID"], display["ActionForOe"], display["ActionForOe"], display["Json"], display["Extenal_Exp_Id"]);
                        if (objDBActivity.execute(strQuery) > 0)
                        {
                            TicketID = objDBActivity.executeScalar(objQuery.GetTicketID());
                            int StrQuery1 = objDBActivity.execute(objQuery.CreateExpectionPlanning(TicketID, display["TicketType"], display["ActionForOe"], display["UserID"], display["OUID"], display["StartDate"], display["ActionForCe"], display["UserID"], display["OUID"], display["EndDate"], display["Status"], display["Json"]));
                            if (StrQuery1 > 0)
                            {
                                strStatus = "1";
                                strMessage = "Create Exception Ticket Successfully Done.";
                            }
                            else
                            {
                                strStatus = "0";
                                strMessage = "Create Exception Ticket Failed.";
                            }
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Create Exception Ticket Failed.";
                        }
                    }
                }
                else if (display["action_type"] == "2")
                {
                    string strQuery = "";
                    string strQuery1 = "";

                    if (display["Status"] == "80" || display["Status"] == "90" || display["Status"] == "40")
                    {
                        strQuery = objQuery.UpdateCloseTicket(display["Status"], display["TicketID"]);
                        strQuery1 = objQuery.UpdateCloseTicketActivityExcpNotifyPlanning(display["Status"], display["TicketID"]);
                    }
                    if (display["Status"] == "10" || display["Status"] == "0")
                    {
                        strQuery = objQuery.UpdateExpectionTicket(display["TicketID"], display["ActionForOe"], display["ActionForOe"], display["UserID"], display["Status"], display["creationdate"], display["expectedClousedate"], display["Extenal_Exp_Id"]);
                        strQuery1 = objQuery.UpdateExpectionTicketActivityExcpNotifyPlanning(display["Status"], display["TicketID"], display["creationdate"], display["expectedClousedate"], display["ActionForOe"], display["ActionForCe"]);

                    }

                    if (display["Status"] == "31")
                    {
                        strQuery = objQuery.UpdateCloseTicket(display["Status"], display["TicketID"]);
                        strQuery1 = objQuery.UpdateDeviasionTicketActivityExcpNotifyPlanning(display["Status"], display["TicketID"], display["Comment"], display["Remark"]);
                    }
                    int Q1 = objDBActivity.execute(strQuery);
                    int Q2 = objDBActivity.execute(strQuery1);
                    if (Q1 > 0 && Q2 > 0)
                    {

                        strStatus = "1";
                        strMessage = "Exception Ticket Updated Successfully Done. ";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Exception Ticket Updated Failed.";
                    }
                }
                resultdata = "{\"TicketID\":\"" + TicketID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateExceptionTicket datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateExceptionTicketTicket Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        #endregion

        #region SDDelivery

        public DataTable GetSDcategoryTebal()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.ServiceDeliveryPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetSDcategoryTebal());
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetSDcategoryTebal datatable count return : " + dt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetSDcategoryTebal Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable DeleteSDcategoryTebal(string SDCatID)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string strQuerynoc = "";
                DatabaseHandler objDBNocdesk = LocalConstant.ServiceDeliveryPool.getConnection();
                strQuerynoc = objQuery.DeleteSDcategoryTebal(SDCatID);
                if (objDBNocdesk.execute(strQuerynoc.ToString()) > 0)
                {
                    strStatus = "1";
                    strMessage = "Category Delete Successfully Done.";
                }
                else
                {
                    strStatus = "0";
                    strMessage = "Category Delete failed.";
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "DeleteSDcategoryTebal datatable count return : " + dt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBNocdesk);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "DeleteSDcategoryTebal Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable GetCategory()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.ServiceDeliveryPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetCategory());
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetCategory datatable count return : " + dt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetCategory Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable GetsubCategory(string category)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.ServiceDeliveryPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetsubCategory(category));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetsubCategory datatable count return : " + dt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetsubCategory Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable Getitem(string Subcategory)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.ServiceDeliveryPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.Getitem(Subcategory));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Getitem datatable count return : " + dt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Getitem Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable CreateCategory(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateCategory parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {

                    string SDLevel = "1";
                    if (Convert.ToInt16(objDBActivity.executeScalar(objQuery.CheckSDCatL1NameExist(display["SDCatL1Name"]))) > 0)
                    {
                        strStatus = "2";
                        strMessage = "Category already exist.";
                    }
                    else
                    {
                        SDCatL1ID = objDBActivity.executeScalar(objQuery.GetSDCatL1ID());
                        string strQuery = objQuery.CreateCategory(display["ApplicationID"], SDLevel, SDCatL1ID, display["SDCatL1Name"], display["SDCatL1Desc"], display["SDCatL2ID"], display["SDCatL2Name"], display["SDCatL2Desc"]);
                        string strQuery2 = objQuery.CreateCategorySDSY121(display["ApplicationID"], SDCatL1ID, display["SDCatL1Name"], display["SDCatL1Desc"]);
                        if (objDBActivity.execute(strQuery) > 0 && objDBActivity.execute(strQuery2) > 0)
                        {

                            strStatus = "1";
                            strMessage = " Category created successfully.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Category created failed.";
                        }

                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Category Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Category Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                // row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Category datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Category Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable CreateSubCategory(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateSubCategory parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    if (Convert.ToInt16(objDBActivity.executeScalar(objQuery.CheckSDCatL2Name(display["SDCatL1Name"], display["SDCatL2Name"]))) > 0)
                    {

                        strStatus = "2";
                        strMessage = "Sub Category Already Exist.";
                    }
                    else
                    {
                        string chackSubcategoty;
                        string SDLevel = "2";
                        string SDCatL2ID = "";
                        SDCatL1ID = objDBActivity.executeScalar(objQuery.GetSDCatL1ID());
                        //string SDCatL1ID = objDBActivity.executeScalar(objQuery.GetSDCatL1ID());
                        string strQuery = objQuery.CreateSubCategory(display["ApplicationID"], SDLevel, display["SDCatL1ID"], display["SDCatL1Name"], display["SDCatL1Desc"], SDCatL1ID, display["SDCatL2Name"], display["SDCatL1Desc"]);
                        if (objDBActivity.execute(strQuery) > 0)
                        {
                            SDCatL2ID = objDBActivity.executeScalar(objQuery.GetSDCatL2ID());
                            chackSubcategoty = objDBActivity.executeScalar(objQuery.GetsubcategoryCount(display["SDCatL1ID"], display["SDCatL1Name"]));
                            if (Convert.ToInt32(chackSubcategoty) == 1)
                            {
                                objDBActivity.execute(objQuery.updateSubCategoryLink(SDCatL2ID, display["SDCatL2Name"], display["SDCatL2Desc"], display["SDCatL1ID"]));
                            }
                            else
                            {
                                objDBActivity.execute(objQuery.insertSubCategoryLink(display["ApplicationID"], display["SDCatL1ID"], display["SDCatL1Name"], display["SDCatL1Desc"], SDCatL2ID, display["SDCatL2Name"], display["SDCatL2Desc"]));
                            }
                            strStatus = "1";
                            strMessage = "Sub Category Created Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Sub Category Created Failed.";
                        }
                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Sub Category Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Sub Category Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create Sub Category datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateSubCategory Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable Createitem(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create item parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    if (Convert.ToInt16(objDBActivity.executeScalar(objQuery.CheckSDCatL3Name(display["SDCatL3Name"], display["SDCatL2Name"]))) > 0)
                    {
                        strStatus = "2";
                        strMessage = "Item Already Exist.";
                    }
                    else
                    {
                        string SDLevel = "3";
                        string ItemCount = "";
                        string SDCatL3ID = "";
                        SDCatL1ID = objDBActivity.executeScalar(objQuery.GetSDCatL1ID());
                        string strQuery = objQuery.CreateItem(display["ApplicationID"], SDLevel, display["SDCatL1ID"], display["SDCatL1Name"], display["SDCatL1Desc"], display["SDCatL2ID"], display["SDCatL2Name"], display["SDCatL2Desc"], SDCatL1ID, display["SDCatL3Name"], display["SDCatL3Desc"]);
                        if (objDBActivity.execute(strQuery) > 0)
                        {
                            SDCatL3ID = objDBActivity.executeScalar(objQuery.GetSDCatL3ID());
                            ItemCount = objDBActivity.executeScalar(objQuery.GetItemCount(display["SDCatL1ID"], display["SDCatL1Name"], display["SDCatL2ID"], display["SDCatL2Name"]));
                            if (Convert.ToInt32(ItemCount) == 1)
                            {
                                objDBActivity.execute(objQuery.updateitemLink(SDCatL3ID, display["SDCatL3Name"], display["SDCatL3Desc"], display["SDCatL1ID"], display["SDCatL2ID"]));
                            }
                            else
                            {
                                objDBActivity.execute(objQuery.insertitemLink(display["ApplicationID"], display["SDCatL1ID"], display["SDCatL1Name"], display["SDCatL1Desc"], display["SDCatL2ID"], display["SDCatL2Name"], display["SDCatL2Desc"], SDCatL3ID, display["SDCatL3Name"], display["SDCatL3Desc"]));
                            }
                            strStatus = "1";
                            strMessage = "Item Created Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Item Category Created Failed.";
                        }

                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Item Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Item Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create Item datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Item Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable CreateSDDeliverydata(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                //resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.ServiceDeliveryPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateSDDeliverydata parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    //if (Convert.ToInt16(objDBActivity.executeScalar(objQuery.CheckTicketExist(display["TicketID"]))) > 0)
                    //{
                    //    strStatus = "2";
                    //    strMessage = "Ticket already exist.";
                    //}
                    //else
                    {
                        string strQuery = objQuery.CreateSDDeliveryTicket(display["ApplicationID"], display["SDleval"], display["SDcatL2Id"], display["SDCatL2Name"], display["SDCatL2Desc"], display["SDCatL1ID"], display["SDCatL1Name"], display["SDCatL1Desc"], display["StartDate"], display["EndDate"], display["Stuse"]);
                        if (objDBActivity.execute(strQuery) > 0)
                        {
                            strStatus = "1";
                            strMessage = "Create SDDelivery Ticket Created Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Create SDDelivery Ticket Created Failed.";
                        }

                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Create SDDelivery Ticket Updated Successfully.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Create SDDelivery Ticket Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                //row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateSDDeliveryTicket datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.ServiceDeliveryPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateGroupTicket Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable CreateChildTicketdata(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                // resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();

                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateChildTicketdata parameter pass json : " + userjson, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                if (display["action_type"] == "1")
                {
                    //if (Convert.ToInt16(objDBActivity.executeScalar(objQuery.CheckTicketExist(display["TicketID"]))) > 0)
                    //{
                    //    strStatus = "2";
                    //    strMessage = "Ticket already exist.";
                    //}
                    //else
                    {
                        string strQuery = objQuery.CreateChildTicketdata(display["ApplicationID"], display["ParentID"], display["TicketActType"], display["CurrentTicketID"], display["CurrentTicketFinalstatus"], display["previoseTicketID"], display["PrevTstaus"], display["epcTime"], display["status"]);
                        if (objDBActivity.execute(strQuery) > 0)
                        {
                            strStatus = "1";
                            strMessage = "Create Child Ticket Created Successfully Done.";
                        }
                        else
                        {
                            strStatus = "0";
                            strMessage = "Create Child Ticket Created Failed.";
                        }

                    }
                }
                else if (display["action_type"] == "2")
                {
                    if (objDBActivity.execute(objQuery.UpdateGroupCreateTicket()) > 0)
                    {
                        strStatus = "1";
                        strMessage = "Create Child Ticket Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Create Child Ticket Updated Failed.";
                    }
                }
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                //row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateChild Ticket datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateChild Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        #endregion

        #region Ticket_Dashboard
        public DataTable Get_Count_Status_Wish_Ticket()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetCountStatusWishTicket());
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Count_Status_Wish_Ticket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Count_Status_Wish_Ticket Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable Get_Engineer_Count_Wish_Ticket()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetCountEngineerWishTicket());
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Engineer_Count_Wish_Ticket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Engineer_Count_Wish_Ticket Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable Get_Assing_Count_Wish_Ticket()
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetCountAssingWishTicket());
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Assing_Count_Wish_Ticket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket ", "Get_Assing_Count_Wish_Ticket Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable Get_Status_Wish_Ticket(string CurrentStatus)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetStatusWishTicket(CurrentStatus));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Status_Wish_Ticket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Status_Wish_Ticket Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable Get_Engineer_Wish_Ticket(string SRuserID)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetEngineerWishTicket(SRuserID));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Engineer_Wish_Ticket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Engineer_Wish_Ticket Exception : " + ex.Message, true);
            }
            return dt;
        }
        public DataTable Get_Assign_Ticket(string CurrentStatus, string CurrentSDRollID)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetAssignWishTicket(CurrentStatus, CurrentSDRollID));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Assign_Ticket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Get_Assign_Ticket Exception : " + ex.Message, true);
            }
            return dt;
        }
        #endregion

        #region UserDashBoard
        public DataTable GetUserdashboard(string GetUserdashboard)
        {
            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetUserdashboard(GetUserdashboard));
                objcommon.WriteLog("GetUserdashboard", "log", "GetUserdashboard MicroService", "GetUserdashboard datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("GetUserdashboard", "log", "GetUserdashboard MicroService", "GetUserdashboard Exception : " + ex.Message, true);
            }
            return dt;
        }
        #endregion  

        #region CreateNotification
        public DataTable CreateNotificatinTicket(string userjson)
        {
            try
            {
                resultdt.Columns.Add("status", typeof(Int16));
                resultdt.Columns.Add("status_message", typeof(string));
                resultdt.Columns.Add("data", typeof(string));
                var row = resultdt.NewRow();
                string TicketID = "";
                DatabaseHandler objDBActivity = LocalConstant.TicketMasterPool.getConnection();
                DatabaseHandler objDBNotification = LocalConstant.NotificationMasterpool.getConnection();

                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateNotificatinTicket parameter pass json : " + userjson, true);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "CreateNotificatinTicket parameter pass json : " + objDBActivity, true);
                string strTemp = dtconversion.Base64Decode(userjson);
                IDictionary<string, string> display = dtconversion.getJSONPropertiesFromString("[" + strTemp + "]");
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create Notificatin Ticket display : " + display, true);

                if (display["action_type"].ToString() == "1")
                {

                    ////string StrQuery1 = objQuery.CheckNotifictionticketExist();
                    //if (objDBActivity.execute(StrQuery1) > 0)
                    //{

                    //    strStatus = "2";
                    //    strMessage = " Notificatin Ticket already exist.";
                    //}
                    //else
                    {
                        string tableDetatis = display["tabledatadetails"];
                        DataTable dtleval = new DataTable();
                        DateTime Time = new DateTime();
                        dtleval = dtconversion.JsonStringToDataTable(tableDetatis);
                        for (i = 0; i < dtleval.Rows.Count; i++)
                        {
                            string userID = "";
                            string username = "";
                            string OUID = "";
                            string OUName = "";
                            string RollID = "";
                            string RollName = "";
                            userID = dtleval.Rows[i]["UserID"].ToString();
                            OUID = dtleval.Rows[i]["OUID"].ToString();
                            RollID = dtleval.Rows[i]["RollID"].ToString();
                            username = dtleval.Rows[i]["UserName"].ToString();
                            string strQuery = objQuery.CreateNotificatinTicket(display["ApplicationID"], display["TicketType"], display["TicketTempleteID"], display["parentTicketID"], display["parentTicketType"], display["TicketPriority"], display["SRuserID"], userID, RollID, OUID, display["DeviceID"], display["SLAID"], display["CurrentSLALevel"], display["Status"], display["StartDate"], display["CurrentStatusDate"], display["EndDate"], display["Visible"], display["SDCatID"], display["SDCatL1ID"], display["SDCatL2ID"], display["SDCatL3ID"], display["ActionReqDesc"], display["FDesc"], display["Json"]);
                            //TicketID = objDBActivity.executeScalar(objQuery.GetTicketID());
                            if (objDBActivity.execute(strQuery) > 0)
                            {
                                TicketID = objDBActivity.executeScalar(objQuery.GetTicketID());
                                int strQuery2 = objDBActivity.execute(objQuery.CreateNotificatinPlanning(TicketID, display["TicketType"], display["FDesc"], userID, OUID, display["EndDate"], display["Status"], display["Json"]));
                                if (strQuery2 > 0)
                                {
                                    strStatus = "1";
                                    strMessage = "Create Notificatin Ticket Successfully Done.";
                                }
                                else
                                {
                                    strStatus = "0";
                                    strMessage = "Create Notificatin Ticket  Failed.";
                                }

                            }
                            else
                            {
                                strStatus = "0";
                                strMessage = "Create Notificatin Ticket  Failed.";
                            }
                        }
                    }
                }
                else if (display["action_type"] == "2")
                {
                    string NotificationTicket = display["TicketID"].ToString();
                    string NotificationCount = display["CountTicket"].ToString();
                    string strQuery = objQuery.UpdateNotificationTicket(NotificationTicket, NotificationCount);
                    string strQuery2 = objQuery.UpdateNotificationplanning(NotificationTicket, NotificationCount, display["Comment"]);
                    if ((objDBActivity.execute(strQuery) > 0) && (objDBActivity.execute(strQuery2) > 0))
                    {
                        strStatus = "1";
                        strMessage = "Notificatin Ticket Updated Successfully Done.";
                    }
                    else
                    {
                        strStatus = "0";
                        strMessage = "Notificatin Ticket Updated Failed.";
                    }
                }
                resultdata = "{\"TicketID\":\"" + TicketID + "\"}";
                row["status"] = strStatus;
                row["status_message"] = strMessage;
                row["data"] = resultdata;
                resultdt.Rows.Add(row);
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create Ticket datatable count return : " + resultdt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBActivity);

            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "Create Ticket Exception : " + ex.Message, true);
            }
            return resultdt;
        }
        public DataTable GetNotificatinTicket(string TicketType, string UserID)
        {

            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetNotificatinTicket(TicketType, UserID));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetNotificatinTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetNotificatinTicket Exception : " + ex.Message, true);
            }
            return dt; ;
        }
        public DataTable GetUserNotificatinTicket(string TicketType, string GetDeliveryID)
        {

            try
            {
                DatabaseHandler objDBNocdesk = LocalConstant.TicketMasterPool.getConnection();
                dt = objDBNocdesk.getDatatable(objQuery.GetUserNotificatinTicket(TicketType, GetDeliveryID));
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetUserNotificatinTicket datatable count return : " + dt.Rows.Count, true);
                LocalConstant.TicketMasterPool.returnConnection(objDBNocdesk);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("CreateTicket", "log", "Ticket", "GetUserNotificatinTicket Exception : " + ex.Message, true);
            }
            return dt; ;
        }
        #endregion

    }
}
