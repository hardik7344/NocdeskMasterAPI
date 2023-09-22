using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskTicketAPIgetway.DataAccessLayer
{
    public class QueryHandler
    {
        //DatabaseCommon objcommon = new DatabaseCommon();
        NocDeskCommon objcommon = new NocDeskCommon();
        OwnYITConstant.DatabaseTypes dbtype;
        DateTime time = new DateTime();

        #region CheckSDExist
        public string CheckSDCatL1NameExist(string SDCatL1Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorization where SDCatName='{0}'", SDCatL1Name);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorization where SDCatName='{0}'", SDCatL1Name);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CheckSDCatL1NameExist Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //CheckSDCatL2NameExist
        public string CheckSDCatL2Name(string SDCatL1Name, string SDCatL2Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorization where SDCatName='{0}' AND SDCatL1Name='{1}'", SDCatL2Name, SDCatL1Name);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorization where SDCatL1Name='{0}' AND SDCatName='{1}'", SDCatL2Name, SDCatL1Name);
                        //strQuery.AppendFormat("select count(*) from SDCategorization where SDCatName='{0}'", SDCatL1Name);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CheckSDCatL2Name Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //End of CheckSDCatL3NameExist 
        public string CheckSDCatL3Name(string SDCatL3Name, string SDCatL2Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorization where SDCatL1Name='{0}' AND SDCatName='{1}'", SDCatL2Name, SDCatL3Name);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorization where SDCatL1Name='{0}' AND SDCatName='{1}'", SDCatL2Name, SDCatL3Name);
                        //strQuery.AppendFormat("select count(*) from SDCategorization where SDCatName='{0}'", SDCatL1Name);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CheckSDCatL3Name Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string CheckTicketExist(string Tickettype, string Problem, string Discription)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from TicketMasterNOCD010TM where TicketType='{0}' and ActionReqDescription='{1}' and  DescriptionTOdisplay='{2}'", Tickettype, Problem, Discription);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from TicketMasterNOCD010TM where TicketType='{0}' and ActionReqDescription='{1}' and  DescriptionTOdisplay='{2}'", Tickettype, Problem, Discription);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CheckTicketExist Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }

            return strQuery.ToString();

        }
        #endregion

        #region Ticket
        public string GetTicketID()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select isnull(max(cast(TicketID as bigint)),0) from TicketMasterNOCD010TM");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select isnull(max(cast(TicketID as bigint)),0) from TicketMasterNOCD010TM");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //GetSerialNumbar
        public string GetSerialNumbar(string TicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("SELECT isnull(MAX(ActID),0) + 1 AS ActID FROM TicketEventDetailsNOCDO11TD where Tid = '{0}'", TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("SELECT isnull(MAX(ActID),0) + 1 AS ActID FROM TicketEventDetailsNOCDO11TD where Tid = '{0}'", TicketID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        // GetTicketServiceDelivery 
        public string GetTicketServiceDelivery()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        //strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketServiceDelivery Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetTicketActiviteData(string TicketID, string TicketType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        //strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketServiceDelivery Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //
        public string GetTicketdata(string SearchCond)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM  {0} ", SearchCond);
                        //strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM  {0} ", SearchCond);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from  TicketMasterNOCD010TM {0} ", SearchCond);
                        //strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketdata Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetSDCategaryData()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDCatL1ID, SDCatL1Name,SDcatL2ID,SDCatL2Name,SDcatL3ID,SDCatL3Name from SDCategorizationLinkageSDSY121");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDCatL1ID, SDCatL1Name,SDcatL2ID,SDCatL2Name,SDcatL3ID,SDCatL3Name from SDCategorizationLinkageSDSY121");
                        //strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentSDUser,CurrentSDRollID,SRuserID,creationdate,ExpectedClousedate,CurrentStatus,SLALevel from TicketMasterNOCD010TM");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetSDCategaryData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        // GET Ticket Details
        public string GetTicketDetailsdata(string TicketID, string TicketType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,SLAID,SLALevel,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,SLAID,SLALevel,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketDetailsdata Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetGroupTicket(string Search)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,OUID,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3 from TicketMasterNOCD010TM where TicketType='Normal Ticket' {0} ", Search);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,OUID,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3 from TicketMasterNOCD010TM where TicketType='Normal Ticket' {0} ", Search);
                        //strQuery.AppendFormat("select TicketID,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1='{0}',SDCategorizationL2='{1}',SDCategorizationl3='{2}',OUID='{3}' from TicketMasterNOCD010TM where TicketType='Normal Ticket'", Category, SubCategory, item, OUID);
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetGroupTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GroupTicketActivation(string MasterTicketID, string MasterCurrentStatus, string Ticket_ID, string Ticket_Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','12345','{2}',getdate(),'1')", MasterTicketID, Ticket_ID, MasterCurrentStatus);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','12345','{2}',getdate(),'1')", MasterTicketID, Ticket_ID, MasterCurrentStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GroupTicketActivation Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //mster
        public string MasterTicketActivation(string ParentID, string Ticket_ID, string Mastercurentstatus)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','','{2}',getdate(),'1')", ParentID, Ticket_ID, Mastercurentstatus);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','','{2}',getdate(),'1')", ParentID, Ticket_ID, Mastercurentstatus);
                        //strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','12345','{2}',getdate(),'1')", MasterTicketID, Ticket_ID, MasterCurrentStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "MasterTicketActivation Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        // Normal Ticket Linkage

        public string MasterToNormalLinkage(string TemplatePID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDCL.SDCatL1ID,SDCL.SDcatL2ID,SDCL.SDcatL3ID,SDCL.SDCatL1Name,SDCL.SDCatL2Name,SDCL.SDCatL3Name from SDCategorizationLinkageSDSY121 SDCL, DocumentLinkageSDSY131 DL  where DL.DocumentID='{0}' and SDCL.SDCatID = DL.EntityID", TemplatePID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDCL.SDCatL1ID,SDCL.SDcatL2ID,SDCL.SDcatL3ID,SDCL.SDCatL1Name,SDCL.SDCatL2Name,SDCL.SDCatL3Name from SDCategorizationLinkageSDSY121 SDCL, DocumentLinkageSDSY131 DL  where DL.DocumentID='{0}' and SDCL.SDCatID = DL.EntityID", TemplatePID);
                        //strQuery.AppendFormat("select SDCL.SDCatL1ID,SDCL.SDcatL2ID,SDCL.SDcatL3ID from SDCategorizationLinkageSDSY121 SDCL, DocumentLinkageSDSY131 DL  where DL.DocumentID='{0}' and SDCL.SDCatID = DL.EntityID", TemplatePID);
                        //strQuery.AppendFormat("select SDCL.SDCatL1Name,SDCL.SDCatL2Name,SDCL.SDCatL3Name from SDCategorizationLinkageSDSY121 SDCL, DocumentLinkageSDSY131 DL  where DL.DocumentID='{0}' and SDCL.SDCatID = DL.EntityID", TemplatePID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "MasterToNormalLinkage Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string PannedTicketActivation(string ParentID, string NoramlTicketID, string Mastercurentstatus, string SDChildPreSeq, string SDChildTTSerialNo, string previousTicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','{2}','{3}',getdate(),'1')", ParentID, NoramlTicketID, previousTicketID, Mastercurentstatus);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','{2}','{3}',getdate(),'1')", ParentID, NoramlTicketID, previousTicketID, Mastercurentstatus);
                        //strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','12345','{2}',getdate(),'1')", MasterTicketID, Ticket_ID, MasterCurrentStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "PannedTicketActivation Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        

        public string UpdateTicket(string TicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivationN0CD010CTR set previoseTicketID='0' where CurrentTicketID='{0}'", TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivationN0CD010CTR set previoseTicketID='0' where CurrentTicketID='{0}'", TicketID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string updatepreTicketID(string previoseTicketID, string ticketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivationN0CD010CTR set previoseTicketID='{0}' where CurrentTicketID='{1}'", previoseTicketID, ticketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivationN0CD010CTR set previoseTicketID='{0}' where CurrentTicketID='{1}'", previoseTicketID, ticketID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "updatepreTicketID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string CreateTicket(string ApplicationID, string TicketType, string TicketTemplateID, string parentTicketID, string parentTicketType, string TicketPriority, string SRuserID, string CurrentSDUser, string CurrentSDRollID, string OUID, string DeviceID, string SLAID, string SLALevel, string CurrentStatus, string Visible, string Problem, string Discription, string Category, string SubCategory, string Item)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',getdate(),getdate(),'2023-12-29','{14}','111','{15}','{16}','{17}','{18}','{19}','')", ApplicationID, TicketType, TicketTemplateID, parentTicketID, parentTicketType, TicketPriority, SRuserID, CurrentSDUser, CurrentSDRollID, OUID, DeviceID, SLAID, SLALevel, CurrentStatus, Visible, Category, SubCategory, Item, Problem, Discription);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',getdate(),getdate(),'2023-12-29','{14}','111','{15}','{16}','{17}','{18}','{19}','')", ApplicationID, TicketType, TicketTemplateID, parentTicketID, parentTicketType, TicketPriority, SRuserID, CurrentSDUser, CurrentSDRollID, OUID, DeviceID, SLAID, SLALevel, CurrentStatus, Visible, Category, SubCategory, Item, Problem, Discription);
                        //strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','Normal Ticket','1','0','','','','','','','','','','0',getdate(),getdate(),'2022-12-14','1','111','{1}','{2}','{3}','{4}','{5}','')", ApplicationID, Category, SubCategory, Item, Problem, Discription);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "Create Ticket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateTicket Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        public string CreateTicketEventDetails(string TicketID, string TicketType, string ActID, string PActID, string StatusID, string ActTypeID, string SDPersonType, string SDPersonID, string Details1, string Details2, string Json)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketEventDetailsNOCDO11TD(Tid,TicketType,ActID,PActID,StatusID,ActType,SDparsonType,SDPersonID,AsgnDate,ActDet1,ActDet2,Json)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'{8}','{9}','{10}')", TicketID, TicketType, ActID, PActID, StatusID, ActTypeID, SDPersonType, SDPersonID, Details1, Details2, Json);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketEventDetailsNOCDO11TD(Tid,TicketType,ActID,PActID,StatusID,ActType,SDparsonType,SDPersonID,AsgnDate,ActDet1,ActDet2,Json)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'{8}','{9}','{10}')", TicketID, TicketType, ActID, PActID, StatusID, ActTypeID, SDPersonType, SDPersonID, Details1, Details2, Json);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateTicketEventDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateTicketEventDetails Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        //
        public string UpdateTicketEventDetails(string ticketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketEventDetailsNOCDO11TD set CompDate=getdate() where Tid={0} And CompDate is NULL",ticketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketEventDetailsNOCDO11TD set CompDate=getdate() where Tid={0} And CompDate is NULL", ticketID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateTicketEventDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateTicketEventDetails Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        public string UpdateCreateTicket(/*string UserID, string UserPassword, string enddate*/)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateCreateTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        #endregion

        #region SDANDMASTERTICKET

        public string SDCategorizationId(string SDCategorizationId)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3  from TicketMasterNOCD010TM where TicketID='{0}'", SDCategorizationId);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3  from TicketMasterNOCD010TM where TicketID='{0}'", SDCategorizationId);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "SDCategorizationId Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string CreateGropuTicket(string CheckedTicketId, string GroupTicketName)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateGropuTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //master

        public string GetMasterTicket()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID, TicketTemplateID, TM141.SDTTEmplateType, parentTicketID, OUID, SRuserID, ActionReqDescription, DescriptionTOdisplay,EntityName as OUNAME from TicketMasterNOCD010TM TM , TemplateMasterDB.dbo.TemplateMasterSDSY141 TM141  where TicketType = 'Master Ticket' and TM.TicketTemplateID = TM141.SDTTemplateID");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID, TicketTemplateID, TM141.SDTTEmplateType, parentTicketID, OUID, SRuserID, ActionReqDescription, DescriptionTOdisplay, EntityName as OUNAME from TicketMasterNOCD010TM TM , TemplateMasterDB.dbo.TemplateMasterSDSY141 TM141  where TicketType = 'Master Ticket' and TM.TicketTemplateID = TM141.SDTTemplateID");
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " GetMasterTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetMasterTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //GetPannedTicket

        public string GetPannedTicket()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketTemplateID,parentTicketID,OUID,SRuserID,ActionReqDescription,DescriptionTOdisplay,'' as ouname from TicketMasterNOCD010TM where TicketType='Planned Ticket'");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketTemplateID,parentTicketID,OUID,SRuserID,ActionReqDescription,DescriptionTOdisplay,'' as ouname from TicketMasterNOCD010TM where TicketType='Planned Ticket'");
                        //strQuery.AppendFormat("select TicketID,TicketTemplateID,TM141.SDTTEmplateType,parentTicketID,OUID,SRuserID,ActionReqDescription,DescriptionTOdisplay,'' as ouname from TicketMasterNOCD010TM , TemplateMasterSDSY141 TM141 where TicketType='Planned Ticket'");
                        break;

                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " GetPannedTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetPannedTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetNoramTicketOfMaster(string parentTicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3  from TicketMasterNOCD010TM  where parentTicketID='{0}'", parentTicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3  from TicketMasterNOCD010TM  where parentTicketID='{0}'", parentTicketID);     
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetNoramTicketOfMaster Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        //public string GetNoramTicketOfMaster(string parentTicketID, string SDTTemplateID, string TicketId)
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("select TicketID,TicketType,TicketTemplateID,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3 from TicketMasterNOCD010TM TM , TemplateMasterDB.dbo.TemplateMasterSDSY141 TMSDS  where TM.parentTicketID='{0}' AND TMSDS.SDTTemplateID='{1}' And TM.TicketID='{2}' and TM.TicketTemplateID=TMSDS.SDTTemplateID", parentTicketID, SDTTemplateID, TicketId);
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("select TicketID,TicketType,TicketTemplateID,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3 from TicketMasterNOCD010TM TM ,TemplateMasterDB.dbo.TemplateMasterSDSY141 TMSDS  where TM.parentTicketID='{0}' AND TMSDS.SDTTemplateID='{1}' And TM.TicketID='{2}' and TM.TicketTemplateID=TMSDS.SDTTemplateID", parentTicketID, SDTTemplateID, TicketId);
        //                //strQuery.AppendFormat("select TicketID,TicketType,TicketTemplateID,ActionReqDescription,DescriptionTOdisplay,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3 from TicketMasterNOCD010TM TM ,TemplateMasterSDSY141 TMSDS where TM.parentTicketID='{0}' AND TMSDS.SDTTemplateID='{1}' and TM.TicketTemplateID=TMSDS.SDTTemplateID", parentTicketID, SDTTemplateID);
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "CreateTicket MicroService", "GetTicketDetailsdata Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}
        public string TMsterTemplateActivation(string MasterTicketID, string MasterCurrentStatus, string Ticket_ID, string Ticket_Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','12345','{2}',getdate(),'1')", MasterTicketID, Ticket_ID, MasterCurrentStatus);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert Into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','2','{1}','2','12345','{2}',getdate(),'1')", MasterTicketID, Ticket_ID, MasterCurrentStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "TMsterTemplateActivation Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateGroupCreateTicket()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateGroupCreateTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetTicketID(string TicketType, string problam, string Description)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,CurrentSDUser,CurrentStatus from TicketMasterNOCD010TM where TicketType='{0}' and ActionReqDescription='{1}' and DescriptionTOdisplay='{2}'", TicketType, problam, Description);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,CurrentSDUser,CurrentStatus from TicketMasterNOCD010TM where TicketType='{0}' and ActionReqDescription='{1}' and DescriptionTOdisplay='{2}'", TicketType, problam, Description);
                        break;

                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketID  Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTicketID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetMasterdata(string MasterTemplateID, string MasterTemplateType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDChildPreSeq,SDChildTTSerialNo,SDChildTTID,SDChildTTDesc,Status from TemplateFlowSDSY142 where SDTTemplateID='{0}' and SDTTEmplateType='{1}'", MasterTemplateID, MasterTemplateType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDChildPreSeq,SDChildTTSerialNo,SDChildTTID,SDChildTTDesc,Status from TemplateFlowSDSY142 where SDTTemplateID='{0}' and SDTTEmplateType='{1}'", MasterTemplateID, MasterTemplateType);
                        //strQuery.AppendFormat("select SDChildTTID,SDChildTTDesc,Status from TemplateFlowSDSY142 where SDTTemplateID='{0}' and SDTTEmplateType='{1}'",MasterTemplateID, MasterTemplateType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetMasterdata Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetTemplateData(string TemplateDesc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDTTEmplateType from TemplateMasterSDSY141 where SDTTemplateName='{0}'", TemplateDesc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,SDTTEmplateType,SDTTemplateDesc from TemplateMasterSDSY141 where SDTTemplateName='{0}'", TemplateDesc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetTemplateData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetPannedTicketID(string tickettype, string problam, string Description)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select top 1 TicketID, OUID, DeviceID, SRuserID,CurrentStatus from TicketMasterNOCD010TM where TicketType = '{0}' and ActionReqDescription = '{1}' and DescriptionTOdisplay = '{2}' order by TicketID desc", tickettype, problam, Description);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select top 1 TicketID, OUID, DeviceID, SRuserID,CurrentStatus from TicketMasterNOCD010TM where TicketType = '{0}' and ActionReqDescription = '{1}' and DescriptionTOdisplay = '{2}' order by TicketID desc", tickettype, problam, Description);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetPannedTicketID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);


            }
            return strQuery.ToString();
        }
        #endregion

        #region SDDelivery

        public string GetSDcategoryTebal()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL1Name,SDCatL2Name,SDCatL3Name from SDCategorizationLinkageSDSY121");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID SDCatL1Name,SDCatL2Name,SDCatL3Name from SDCategorizationLinkageSDSY121");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetSDcategoryTebal Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string DeleteSDcategoryTebal(string SDCatID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("delete SDCategorizationLinkageSDSY121 where SDCatID='{0}'", SDCatID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("delete SDCategorizationLinkageSDSY121 where SDCatID='{0}'", SDCatID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "DeleteSDcategoryTebal Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetsubcategoryCount(string SDCatL1ID, string SDCatL1Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorizationLinkageSDSY121 where SDCatL1ID='{0}' and SDCatL1Name='{1}' and SDcatL2ID=0 and SDcatL3ID=0", SDCatL1ID, SDCatL1Name);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorizationLinkageSDSY121 where SDCatL1ID='{0}' and SDCatL1Name='{1}' and SDcatL2ID=0 and SDcatL3ID=0", SDCatL1ID, SDCatL1Name);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetsubcategoryCount Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //GetItemCount
        public string GetItemCount(string SDCatL1ID, string SDCatL1Name, string SDcatL2ID, string SDCatL2Name)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorizationLinkageSDSY121 where SDCatL1ID='{0}' and SDCatL1Name='{1}' and SDcatL2ID='{2}' and SDCatL2Name='{3}' and SDcatL3ID=0", SDCatL1ID, SDCatL1Name, SDcatL2ID, SDCatL2Name);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from SDCategorizationLinkageSDSY121 where SDCatL1ID='{0}' and SDCatL1Name='{1}' and SDcatL2ID='{2}' and SDCatL2Name='{3}' and SDcatL3ID=0", SDCatL1ID, SDCatL1Name, SDcatL2ID, SDCatL2Name);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetItemCount Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetCategory()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL2ID,SDCatName from SDCategorization where SDLevel='1'");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL2ID,SDCatName from SDCategorization where SDLevel='1'");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetCategory Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetsubCategory(string category)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL2ID,SDCatName from SDCategorization where SDLevel='2' And SDCatL1Name='{0}'", category);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL2ID,SDCatName from SDCategorization where SDLevel='2' And SDCatL1Name='{0}'", category);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetsubCategory Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string Getitem(string Subcategory)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL2ID,SDCatName from SDCategorization where SDLevel='3' And SDCatL1Name='{0}'", Subcategory);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct SDCatID,SDCatL2ID,SDCatName from SDCategorization where SDLevel='3' And SDCatL1Name='{0}'", Subcategory);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetsubCategory Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //Start Create Category   
        public string CreateCategory(string ApplicationID, string SDleval, string SDcatL2Id, string SDCatl2Name, string SDCatl2Desc, string SDCatL1ID, string SDCatL1Name, string SDCatL1Desc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateCategory Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //End Create Category
        public string CreateCategorySDSY121(string ApplicationID, string SDcatL2Id, string SDCatl2Name, string SDCatL1Desc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorizationLinkageSDSY121(ApplicationID,SDCatL1ID,SDCatL1Name,SDCatL1Desc,SDcatL2ID,SDCatL2Name,SDCatL2Desc,SDcatL3ID,SDCatL3Name,SDCatL3Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','','','','','','',getdate(),getdate(),'0')", ApplicationID, SDcatL2Id, SDCatl2Name, SDCatL1Desc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorizationLinkageSDSY121(ApplicationID,SDCatL1ID,SDCatL1Name,SDCatL1Desc,SDcatL2ID,SDCatL2Name,SDCatL2Desc,SDcatL3ID,SDCatL3Name,SDCatL3Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','','','','','','',getdate(),getdate(),'0')", ApplicationID, SDcatL2Id, SDCatl2Name, SDCatL1Desc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateCategory Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //Start Sub Category
        public string CreateSubCategory(string ApplicationID, string SDleval, string SDcatL2Id, string SDCatl2Name, string SDCatl2Desc, string SDCatL1ID, string SDCatL1Name, string SDCatL1Desc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDCatL1ID, SDCatL1Name, SDCatL1Desc, SDcatL2Id, SDCatl2Name, SDCatl2Desc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDCatL1ID, SDCatL1Name, SDCatL1Desc, SDcatL2Id, SDCatl2Name, SDCatl2Desc);
                        //strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateSubCategory Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string insertSubCategoryLink(string ApplicationID, string SDCatL1ID, string SDCatL1Name, string SDCatL1Desc, string SDCatL2ID, string SDCatL2Name, string SDCatL2Desc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into  SDCategorizationLinkageSDSY121(ApplicationID,SDCatL1ID,SDCatL1Name,SDCatL1Desc,SDcatL2ID,SDCatL2Name,SDCatL2Desc,SDcatL3ID,SDCatL3Name,SDCatL3Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','','','',getdate(),getdate(),'0')", ApplicationID, SDCatL1ID, SDCatL1Name, SDCatL1Desc, SDCatL2ID, SDCatL2Name, SDCatL2Desc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into  SDCategorizationLinkageSDSY121(ApplicationID,SDCatL1ID,SDCatL1Name,SDCatL1Desc,SDcatL2ID,SDCatL2Name,SDCatL2Desc,SDcatL3ID,SDCatL3Name,SDCatL3Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','','','',getdate(),getdate(),'0')", ApplicationID, SDCatL1ID, SDCatL1Name, SDCatL1Desc, SDCatL2ID, SDCatL2Name, SDCatL2Desc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "insertSubCategoryLink Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string updateSubCategoryLink(string SDcatL2Id, string SDCatl2Name, string SDCatl2Desc, string SDCatL1ID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update SDCategorizationLinkageSDSY121  set SDcatL2ID='{0}' , SDCatL2Name='{1}', SDCatL2Desc='{2}' where SDCatL1ID={3} and SDcatL2ID=0 and SDcatL3ID=0", SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update SDCategorizationLinkageSDSY121  set SDcatL2ID='{0}' , SDCatL2Name='{1}', SDCatL2Desc='{2}' where SDCatL1ID={3} and SDcatL2ID=0 and SDcatL3ID=0", SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "updateSubCategoryLink Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //End Sub Category
        //CreateItem
        public string CreateItem(string ApplicationID, string SDleval, string SDcatL2Id, string SDCatl2Name, string SDCatl2Desc, string SDCatL1ID, string SDCatL1Name, string SDCatL1Desc, string SDCatL3ID, string SDCatL3Name, string SDCatL3Desc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDCatL3ID, SDCatL3Name, SDCatL3Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'0')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateItem Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();

        }
        //updateitemLink
        public string updateitemLink(string SDcatL2Id, string SDCatl2Name, string SDCatl2Desc, string SDCatL1ID, string SDCatL2ID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update SDCategorizationLinkageSDSY121  set SDcatL3ID='{0}' , SDCatL3Name='{1}', SDCatL3Desc='{2}' where SDCatL1ID='{3}' and SDcatL2ID='{4}' and SDcatL3ID=0", SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL2ID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update SDCategorizationLinkageSDSY121  set SDcatL3ID='{0}' , SDCatL3Name='{1}', SDCatL3Desc='{2}' where SDCatL1ID='{3}' and SDcatL2ID='{4}' and SDcatL3ID=0", SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL2ID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "updateitemLink Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string insertitemLink(string ApplicationID, string SDCatL1ID, string SDCatL1Name, string SDCatL1Desc, string SDCatL2ID, string SDCatL2Name, string SDCatL2Desc, string SDCatL3ID, string SDCatL3Name, string SDCatL3Desc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into  SDCategorizationLinkageSDSY121(ApplicationID,SDCatL1ID,SDCatL1Name,SDCatL1Desc,SDcatL2ID,SDCatL2Name,SDCatL2Desc,SDcatL3ID,SDCatL3Name,SDCatL3Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',getdate(),getdate(),'0')", ApplicationID, SDCatL1ID, SDCatL1Name, SDCatL1Desc, SDCatL2ID, SDCatL2Name, SDCatL2Desc, SDCatL3ID, SDCatL3Name, SDCatL3Desc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into  SDCategorizationLinkageSDSY121(ApplicationID,SDCatL1ID,SDCatL1Name,SDCatL1Desc,SDcatL2ID,SDCatL2Name,SDCatL2Desc,SDcatL3ID,SDCatL3Name,SDCatL3Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',getdate(),getdate(),'0')", ApplicationID, SDCatL1ID, SDCatL1Name, SDCatL1Desc, SDCatL2ID, SDCatL2Name, SDCatL2Desc, SDCatL3ID, SDCatL3Name, SDCatL3Desc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "insertitemLink Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        // end 
        public string CreateSDDeliveryTicket(string ApplicationID, string SDleval, string SDcatL2Id, string SDCatl2Name, string SDCatl2Desc, string SDCatL1ID, string SDCatL1Name, string SDCatL1Desc, string StartDate, string EndDate, string Stuse)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'{8}')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc, Stuse);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'{8}')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc, Stuse);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateSDDeliveryTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //
        public string CreateChildTicketdata(string ApplicationID, string ParentID, string TicketActType, string CurrentTicketID, string CurrentTicketFinalstatus, string previoseTicketID, string PrevTstaus, string epcTime, string status)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ParentID, TicketActType, CurrentTicketID, CurrentTicketFinalstatus, previoseTicketID, PrevTstaus, epcTime, status);
                        //strQuery.AppendFormat("insert into SDCategorization(ApplicationID,SDLevel,SDcatL2ID,SDCatName,SDCatDesc,SDCatL1ID,SDCatL1Name,SDCatL1Desc,Startdate,Enddate,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),getdate(),'{8}')", ApplicationID, SDleval, SDcatL2Id, SDCatl2Name, SDCatl2Desc, SDCatL1ID, SDCatL1Name, SDCatL1Desc, Stuse);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketActivationN0CD010CTR(ParentID,TicketActType,CurrentTicketID,CurrentTicketFinalstatus,previoseTicketID,PrevTstaus,epcTime,status)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ParentID, TicketActType, CurrentTicketID, CurrentTicketFinalstatus, previoseTicketID, PrevTstaus, epcTime, status);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateChildTicketdata Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetSDCatL1ID()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select isnull(MAX(sdcatl2id),0)+1 from SDCategorization");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select isnull(MAX(sdcatl2id),0)+1 from SDCategorization");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetSDCatL1ID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetSDCatL2ID()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select ISNULL(max(SDCatL1ID),0)+1 from SDCategorization");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select ISNULL(max(SDCatL1ID),0)+1 from SDCategorization");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetSDCatL2ID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //GetSDCatL3ID
        public string GetSDCatL3ID()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select ISNULL(max(SDCatL1ID),0)+1 from SDCategorization");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select ISNULL(max(SDCatL1ID),0)+1 from SDCategorization");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetSDCatL3ID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #endregion

        #region Ticket_Dashboard
        public string GetCountStatusWishTicket()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("SELECT distinct CurrentStatus, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY CurrentStatus");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("SELECT distinct CurrentStatus, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY CurrentStatus");
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetCountStatusWishTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetCountEngineerWishTicket()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("SELECT distinct SRuserID,CurrentSDUser, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY SRuserID,CurrentSDUser");
                        //strQuery.AppendFormat("SELECT distinct CurrentSDRollID,CurrentSDUser, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY CurrentSDRollID,CurrentSDUser");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("SELECT distinct SRuserID,CurrentSDUser, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY SRuserID,CurrentSDUser");
                        //strQuery.AppendFormat("SELECT distinct CurrentSDRollID,CurrentSDUser, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY CurrentSDRollID,CurrentSDUser");
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetCountEngineerWishTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetCountAssingWishTicket()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("SELECT distinct CurrentSDRollID, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY CurrentSDRollID");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("SELECT distinct CurrentSDRollID, COUNT(*) FROM TicketMasterNOCD010TM GROUP BY CurrentSDRollID");
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetCountAssingWishTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetStatusWishTicket(string CurrentStatus)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,creationdate,ExpectedClousedate,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentStatus,CurrentSDUser,CurrentSDRollID from TicketMasterNOCD010TM where CurrentStatus='{0}'", CurrentStatus);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,creationdate,ExpectedClousedate,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentStatus,CurrentSDUser,CurrentSDRollID from TicketMasterNOCD010TM where CurrentStatus='{0}'", CurrentStatus);
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetStatusWishTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetEngineerWishTicket(string SRuserID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,creationdate,ExpectedClousedate,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentStatus,CurrentSDRollID,SRuserID,CurrentSDUser,OUID from TicketMasterNOCD010TM where SRuserID='{0}'", SRuserID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,creationdate,ExpectedClousedate,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentStatus,CurrentSDRollID,SRuserID,CurrentSDUser,OUID from TicketMasterNOCD010TM where SRuserID='{0}'", SRuserID);
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetEngineerWishTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetAssignWishTicket(string CurrentStatus, string CurrentSDRollID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,creationdate,ExpectedClousedate,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentStatus,CurrentSDRollID,CurrentSDUser from TicketMasterNOCD010TM where CurrentStatus='{0}' AND CurrentSDRollID='{1}'", CurrentStatus, CurrentSDRollID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,creationdate,ExpectedClousedate,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,CurrentStatus,CurrentSDRollID,CurrentSDUser from TicketMasterNOCD010TM where CurrentStatus='{0}' AND CurrentSDRollID='{1}'", CurrentStatus, CurrentSDRollID);
                        //strQuery.AppendFormat("select TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentSDUser,creationdate,currentStatusDate,ExpectedClousedate from TicketMasterNOCD010TM where TicketID='{0}' AND TicketType='{1}'", TicketID, TicketType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetAssignWishTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #endregion
        #region USER
        public string GetUserdashboard(string GetAssignWishTicket)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentStatus,creationdate,ExpectedClousedate,CurrentSDUser,CurrentSDRollID from TicketMasterNOCD010TM where CurrentSDRollID='{0}'", GetAssignWishTicket);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct TicketID,TicketType,ActionReqDescription,DescriptionTOdisplay,CurrentStatus,creationdate,ExpectedClousedate,CurrentSDUser,CurrentSDRollID from TicketMasterNOCD010TM where CurrentSDRollID='{0}'", GetAssignWishTicket);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "CreateTicket MicroService", "GetUserdashboard Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string getKbcategoryByQid(string Qid)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDCatL1,SDCatL2,SDCatL3  from SD_LinkageBase_Master where KBID='{0}'", Qid);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDCatL1,SDCatL2,SDCatL3  from SD_LinkageBase_Master where KBID='{0}'", Qid);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "CreateTicket MicroService", "GetUserdashboard Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //getKbcategoryByQid
        #endregion
        //#region KB
        //public string GetKBTebal()
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("select SN, QType, PQID, QID, QText, AText from Kb_Master");
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("select SN, QType, PQID, QID, QText, AText from Kb_Master");
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "DocumentMaster MicroService", "GetDocumentID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}
        //public string GetKBQid()
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("select isnull(MAX(QID),0)+1 from Kb_Master");
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("select isnull(MAX(QID),0)+1 from Kb_Master");
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "DocumentMaster MicroService", "GetDocumentID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}
        //public string CreateKB(string KBQuestion, string KBAnswer, string KBLeaf, string QuestionID, string PQID)
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("insert into Kb_Master(SROrgID,KBID,QType,PQID,QID,QText,AText,ChildQJSON,ActionJSON,startdate,enddate)values('1','1','{0}','{1}','{2}','{3}','{4}','','',getdate(),getdate())", KBLeaf, PQID, QuestionID, KBQuestion, KBAnswer);
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("insert into Kb_Master(SROrgID,KBID,QType,PQID,QID,QText,AText,ChildQJSON,ActionJSON,startdate,enddate)values('1','1','{0}','{1}','{2}','{3}','{4}','','',getdate(),getdate())", KBLeaf, PQID, QuestionID, KBQuestion, KBAnswer);
        //                //strQuery.AppendFormat("insert into Kb_Master(SROrgID,KBID,QType,PQID,QID,QText,AText,ChildQJSON,ActionJSON,startdate,enddate)values('1','1','{0}','1','{1}','{2}','{3}','','',getdate(),getdate())", KBLeaf, QuestionID, KBQuestion, KBAnswer);
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "CreateTicket MicroService", "Create Ticket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}

        //public string CreateKBLinkeg(string OUID, string KBQID, string SDcatL1, string SDcatL2, string SDcatL3)
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("insert into SD_LinkageBase_Master(SROrgID,KBID,OUID,SDCatL1,SDCatL2,SDCatL3,startdate,enddate)values('1','{0}','{1}','{2}','{3}','{4}',getdate(),getdate())", KBQID, OUID, SDcatL1, SDcatL2, SDcatL3);
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("insert into SD_LinkageBase_Master(SROrgID, KBID, OUID, SDCatL1, SDCatL2, SDCatL3, startdate, enddate)values('1', '{0}', '{1}', '{2}', '{3}', '{4}', getdate(), getdate())", KBQID, OUID, SDcatL1, SDcatL2, SDcatL3);
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "CreateKBLinkeg MicroService", "Create KB Linkeg Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}
        //#endregion
        #region Notification Ticket 
        public string CreateNotificatinTicket(string ApplicationID, string TicketType, string TicketTempleteID, string parentTicketID, string parentTicketType, string TicketPriority, string SRuserID, string DeliveryUID, string RollID, string OUID, string DeviceID, string SLAID, string CurrentSLALevel, string Status, string StartDate, string CurrentStatusDate, string EndDate, string Visible, string SDCatID, string SDCatL1ID, string SDCatL2ID, string SDCatL3ID, string ActionReqDesc, string FDesc, string Json)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate(),'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')", ApplicationID, TicketType, TicketTempleteID, parentTicketID, parentTicketType, TicketPriority, SRuserID, DeliveryUID, RollID, OUID, DeviceID, SLAID, CurrentSLALevel, Status, StartDate, EndDate, Visible, SDCatID, SDCatL1ID, SDCatL2ID, SDCatL3ID, ActionReqDesc, FDesc, Json);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate(),'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')", ApplicationID, TicketType, TicketTempleteID, parentTicketID, parentTicketType, TicketPriority, SRuserID, DeliveryUID, RollID, OUID, DeviceID, SLAID, CurrentSLALevel, Status, StartDate, EndDate, Visible, SDCatID, SDCatL1ID, SDCatL2ID, SDCatL3ID, ActionReqDesc, FDesc, Json);
                        //strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','Normal Ticket','1','0','','','','','','','','','','0',getdate(),getdate(),'2022-12-14','1','111','{1}','{2}','{3}','{4}','{5}','')", ApplicationID, Category, SubCategory, Item, Problem, Discription);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateNotificatinTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateNotificatinTicket Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        //CreateNotificatinPlanning
        public string CreateNotificatinPlanning(string TicketID, string TicketType, string Action1, string User1,string OUID, string Expiry1, string Status,  string Json)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("INSERT INTO TicketActivityExceptionandNotificationPlanning(TicketID,TicketType,Action1,Action1DeliveryUser,Action1DeliveryOrg,UserCommentsAct1,ExpiryDate1,Action2,Action2DeliveryUser,Action2DeliveryOrg,UserCommentsAct2,ExpiryDate2,status,Json)VALUES('{0}','{1}','{2}','{3}','{4}','','{5}','','','','','','{6}','{7}')",TicketID,TicketType,Action1,User1,OUID, Expiry1, Status, Json);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("INSERT INTO TicketActivityExceptionandNotificationPlanning(TicketID,TicketType,Action1,Action1DeliveryUser,Action1DeliveryOrg,UserCommentsAct1,ExpiryDate1,Action2,Action2DeliveryUser,Action2DeliveryOrg,UserCommentsAct2,ExpiryDate2,status,Json)VALUES('{0}','{1}','{2}','{3}','{4}','','{5}','','','','','','{6}','{7}')", TicketID, TicketType, Action1, User1, OUID, Expiry1, Status, Json);
                        //strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','Normal Ticket','1','0','','','','','','','','','','0',getdate(),getdate(),'2022-12-14','1','111','{1}','{2}','{3}','{4}','{5}','')", ApplicationID, Category, SubCategory, Item, Problem, Discription);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateNotificatinPlanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", " CreateNotificatinPlanning Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        public string GetNotificatinTicket(string TicketType, string UserID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,SRuserID,CurrentSDUser,CurrentSDRollID,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,ActionReqDescription,DescriptionTOdisplay  from TicketMasterNOCD010TM where TicketType='{0}' and SRuserID='{1}'", TicketType,UserID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,SRuserID,CurrentSDUser,CurrentSDRollID,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,ActionReqDescription,DescriptionTOdisplay  from TicketMasterNOCD010TM where TicketType='{0}' and SRuserID='{1}'", TicketType, UserID);
                        break;

                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " GetNotificatinTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetNotificatinTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetUserNotificatinTicket(string TicketType, string GetDeliveryID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,SRuserID,CurrentSDUser,CurrentSDRollID,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,ActionReqDescription,DescriptionTOdisplay  from TicketMasterNOCD010TM where TicketType='{0}' and CurrentSDUser='{1}'", TicketType, GetDeliveryID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TicketID,TicketType,SRuserID,CurrentSDUser,CurrentSDRollID,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,ActionReqDescription,DescriptionTOdisplay  from TicketMasterNOCD010TM where TicketType='{0}' and CurrentSDUser='{1}'", TicketType, GetDeliveryID);
                        break;

                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " GetUserNotificatinTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetUserNotificatinTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateNotificationTicket(string TicketID, string ActionCount)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketMasterNOCD010TM set CurrentStatus='{0}' where TicketID='{1}'", ActionCount, TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketMasterNOCD010TM set CurrentStatus='{0}' where TicketID='{1}'", ActionCount, TicketID);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateNotificationTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateNotificationTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateNotificationplanning(string TicketID, string ActionCount, string NotificationComment)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivityExceptionandNotificationPlanning set UserCommentsAct1 ='{0}', status='{1}' where TicketID='{2}'", NotificationComment, ActionCount, TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivityExceptionandNotificationPlanning set UserCommentsAct1 ='{0}', status='{1}' where TicketID='{2}'", NotificationComment, ActionCount, TicketID);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateNotificationplanning Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateNotificationplanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //UpdateNotificationplanning
        #endregion

        #region Expection Ticket

        //Get Expection Ticket
        public string GetExceptionTicket(string TicketType,string GetDeliveryID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TM.TicketID,TM.TicketType,TM.SRuserID,TM.CurrentSDUser,TM.CurrentSDRollID,TM.CurrentStatus,TM.creationdate,TM.currentStatusDate,TM.ExpectedClousedate,TM.ExternalTicketID,TEPP.Action1,TEPP.Action2  from TicketMasterNOCD010TM TM  ,TicketActivityExceptionandNotificationPlanning TEPP where TM.TicketType='{0}' AND TM.TicketID=TEPP.TicketID AND TM.CurrentSDUser='{1}'", TicketType,GetDeliveryID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TM.TicketID,TM.TicketType,TM.SRuserID,TM.CurrentSDUser,TM.CurrentSDRollID,TM.CurrentStatus,TM.creationdate,TM.currentStatusDate,TM.ExpectedClousedate,TM.ExternalTicketID,TEPP.Action1,TEPP.Action2  from TicketMasterNOCD010TM TM  ,TicketActivityExceptionandNotificationPlanning TEPP where TM.TicketType='{0}' AND TM.TicketID=TEPP.TicketID AND TM.CurrentSDUser='{1}'", TicketType,GetDeliveryID);
                        //strQuery.AppendFormat("select TicketID,TicketType,SRuserID,CurrentSDUser,CurrentSDRollID,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,ActionReqDescription,DescriptionTOdisplay,ExternalTicketID  from TicketMasterNOCD010TM where TicketType='Exception Ticket' AND CurrentSDUser='{0}'", GetDeliveryID);
                        break;

                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " GetExceptionTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetExceptionTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetUserExceptionTicket(string TicketType,string UserID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TM.TicketID,TM.TicketType,TM.SRuserID,TM.CurrentSDUser,TM.CurrentSDRollID,TM.CurrentStatus,TM.creationdate,TM.currentStatusDate,TM.ExpectedClousedate,TM.ExternalTicketID,TEPP.Action1,TEPP.Action2  from TicketMasterNOCD010TM TM  ,TicketActivityExceptionandNotificationPlanning TEPP where TM.TicketType='{0}' AND TM.TicketID=TEPP.TicketID AND TM.SRuserID='{1}'", TicketType, UserID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TM.TicketID,TM.TicketType,TM.SRuserID,TM.CurrentSDUser,TM.CurrentSDRollID,TM.CurrentStatus,TM.creationdate,TM.currentStatusDate,TM.ExpectedClousedate,TM.ExternalTicketID,TEPP.Action1,TEPP.Action2  from TicketMasterNOCD010TM TM  ,TicketActivityExceptionandNotificationPlanning TEPP where TM.TicketType='{0}' AND TM.TicketID=TEPP.TicketID AND TM.SRuserID='{1}'", TicketType, UserID);
                        //strQuery.AppendFormat("select TicketID,TicketType,SRuserID,CurrentSDUser,CurrentSDRollID,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,ActionReqDescription,DescriptionTOdisplay  from TicketMasterNOCD010TM where TicketType='Exception Ticket' AND  SRuserID='{0}'", UserID);
                        break;

                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " GetUserExceptionTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "GetUserExceptionTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string CreateExpectionTicket(string ApplicationID, string TicketType, string TicketTempleteID, string parentTicketID, string parentTicketType, string TicketPriority, string SRuserID, string DeliveryUID, string RollID, string OUID, string DeviceID, string SLAID, string CurrentSLALevel, string Status, string StartDate, string CurrentStatusDate, string EndDate, string Visible, string SDCatID, string SDCatL1ID, string SDCatL2ID, string SDCatL3ID, string ActionReqDesc, string FDesc, string Json, string ExternalTicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson,ExternalTicketID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate(),'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')", ApplicationID, TicketType, TicketTempleteID, parentTicketID, parentTicketType, TicketPriority, SRuserID, DeliveryUID, RollID, OUID, DeviceID, SLAID, CurrentSLALevel, Status, StartDate, EndDate, Visible, SDCatID, SDCatL1ID, SDCatL2ID, SDCatL3ID, ActionReqDesc, FDesc, Json, ExternalTicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson,ExternalTicketID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate(),'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')", ApplicationID, TicketType, TicketTempleteID, parentTicketID, parentTicketType, TicketPriority, SRuserID, DeliveryUID, RollID, OUID, DeviceID, SLAID, CurrentSLALevel, Status, StartDate, EndDate, Visible, SDCatID, SDCatL1ID, SDCatL2ID, SDCatL3ID, ActionReqDesc, FDesc, Json, ExternalTicketID);
                        //strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate(),'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')", ApplicationID, TicketType, TicketTempleteID, parentTicketID, parentTicketType, TicketPriority, SRuserID, DeliveryUID, RollID, OUID, DeviceID, SLAID, CurrentSLALevel, Status, StartDate, EndDate, Visible, SDCatID, SDCatL1ID, SDCatL2ID, SDCatL3ID, ActionReqDesc, FDesc, Json);
                        //strQuery.AppendFormat("insert into TicketMasterNOCD010TM(ApplicationID,TicketType,TicketTemplateID,parentTicketID,parentTicketType,TicketPriority,SRuserID,CurrentSDUser,CurrentSDRollID,OUID,DeviceID,SLAID,SLALevel,CurrentStatus,creationdate,currentStatusDate,ExpectedClousedate,Visible,SDCategorizationID,SDCategorizationL1,SDCategorizationL2,SDCategorizationl3,ActionReqDescription,DescriptionTOdisplay,TicketJson)values('{0}','Normal Ticket','1','0','','','','','','','','','','0',getdate(),getdate(),'2022-12-14','1','111','{1}','{2}','{3}','{4}','{5}','')", ApplicationID, Category, SubCategory, Item, Problem, Discription);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateExpectionTicket Ticket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateExpectionTicket Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        
        //Stert 
        public string CreateExpectionPlanning(string TicketID,string TicketType, string ActionForOe, string Action1UserID, string Action1OUID, string Action1EndDate, string ActionForCe, string Action2UserID, string Action2OUID, string Action2EndDate, string Status, string Json)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("INSERT INTO TicketActivityExceptionandNotificationPlanning(TicketID,TicketType,Action1,Action1DeliveryUser,Action1DeliveryOrg,UserCommentsAct1,ExpiryDate1,Action2,Action2DeliveryUser,Action2DeliveryOrg,UserCommentsAct2,ExpiryDate2,status,Json)VALUES('{0}','{1}','{2}','{3}','{4}','','{5}','{6}','{7}','{8}','','{9}','{10}','{11}')",TicketID,TicketType, ActionForOe, Action1UserID,Action1OUID,Action1EndDate,ActionForCe,Action2UserID,Action2OUID,Action2EndDate,Status,Json);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("INSERT INTO TicketActivityExceptionandNotificationPlanning(TicketID,TicketType,Action1,Action1DeliveryUser,Action1DeliveryOrg,UserCommentsAct1,ExpiryDate1,Action2,Action2DeliveryUser,Action2DeliveryOrg,UserCommentsAct2,ExpiryDate2,status,Json)VALUES('{0}','{1}','{2}','{3}','{4}','','{5}','{6}','{7}','{8}','','{9}','{10}','{11}')", TicketID, TicketType, ActionForOe, Action1UserID, Action1OUID, Action1EndDate, ActionForCe, Action2UserID, Action2OUID, Action2EndDate, Status, Json);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateExpectionPlanning Ticket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            objcommon.WriteLog("QueryHandler", "log", "Ticket", "CreateExpectionPlanning Query : " + strQuery.ToString(), true);

            return strQuery.ToString();
        }
        
        //UpdateDeviasionTicketActivityExcpNotifyPlanning
        public string UpdateDeviasionTicketActivityExcpNotifyPlanning(string Count, string TicketID,string Comment, string Remark)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat(" update TicketActivityExceptionandNotificationPlanning set UserCommentsAct1='{0}', UserCommentsAct2='{1}', status='{2}' where TicketID='{3}'", Comment, Remark,Count,TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat(" update TicketActivityExceptionandNotificationPlanning set UserCommentsAct1='{0}', UserCommentsAct2='{1}', status='{2}' where TicketID='{3}'", Comment, Remark, Count, TicketID);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateDeviasionTicketActivityExcpNotifyPlanning Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateDeviasionTicketActivityExcpNotifyPlanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateCloseTicket(string Count, string TicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketMasterNOCD010TM set CurrentStatus='{0}' where TicketID='{1}'",Count,TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketMasterNOCD010TM set CurrentStatus='{0}' where TicketID='{1}'", Count, TicketID);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateCloseTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateCloseTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateCloseTicketActivityExcpNotifyPlanning(string Count, string TicketID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivityExceptionandNotificationPlanning set status='{0}' where TicketID='{1}'", Count, TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivityExceptionandNotificationPlanning set status='{0}' where TicketID='{1}'", Count, TicketID);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateCloseTicketActivityExcpNotifyPlanning Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateCloseTicketActivityExcpNotifyPlanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateExpectionTicket(string TicketID,string ActionForOe,string ActionForOe1,string UserID,string Status, string StartDate, string EndDate,string Extenal_Exp_Id)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("Update TicketMasterNOCD010TM set ActionReqDescription='{0}',DescriptionTOdisplay='{1}',CurrentSDUser='{2}',CurrentStatus='{3}',creationdate='{4}',ExpectedClousedate='{5}' where TicketID='{6}' and ExternalTicketID='{7}'", ActionForOe, ActionForOe1, UserID, Status, StartDate, EndDate, TicketID, Extenal_Exp_Id);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("Update TicketMasterNOCD010TM set ActionReqDescription='{0}',DescriptionTOdisplay='{1}',CurrentSDUser='{2}',CurrentStatus='{3}',creationdate='{4}',ExpectedClousedate='{5}' where TicketID='{6}' and ExternalTicketID='{7}'", ActionForOe, ActionForOe1, UserID, Status, StartDate, EndDate, TicketID, Extenal_Exp_Id);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateExpectionTicket Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateExpectionTicket Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string UpdateExpectionTicketActivityExcpNotifyPlanning(string Count, string TicketID,string creationdate, string expectedClousedate, string ActionForOe, string ActionForCe)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivityExceptionandNotificationPlanning set ExpiryDate1='{0}',ExpiryDate2='{1}',Action1='{2}',Action2='{3}', status='{4}' where TicketID='{5}'",expectedClousedate,expectedClousedate,ActionForOe,ActionForCe, Count,TicketID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update TicketActivityExceptionandNotificationPlanning set ExpiryDate1='{0}',ExpiryDate2='{1}',Action1='{2}',Action2='{3}', status='{4}' where TicketID='{5}'", expectedClousedate, expectedClousedate, ActionForOe, ActionForCe, Count, TicketID);
                        break;
                }
                objcommon.WriteLog("QueryHandler", "log", "Ticket", " UpdateExpectionTicketActivityExcpNotifyPlanning Query : " + strQuery.ToString(), true);
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "Ticket", "UpdateExpectionTicketActivityExcpNotifyPlanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        ////UpdateOpenExpectionTicket
        //public string UpdateOpenExpectionTicket(string Count, string TicketID)
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("");
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("");
        //                break;
        //        }
        //        objcommon.WriteLog("QueryHandler", "log", "UpdateExpectionTicket MicroService", " UpdateNotificationplanning Query : " + strQuery.ToString(), true);
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "UpdateExpectionTicket MicroService", "UpdateNotificationplanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}
        ////UpdateOpenExpectionTicketActivityExcpNotifyPlanning
        //public string UpdateOpenExpectionTicketActivityExcpNotifyPlanning(string Count, string TicketID)
        //{
        //    StringBuilder strQuery = new StringBuilder();
        //    try
        //    {
        //        switch (dbtype)
        //        {
        //            case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
        //                strQuery.AppendFormat("");
        //                break;
        //            case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
        //                strQuery.AppendFormat("");
        //                break;
        //        }
        //        objcommon.WriteLog("QueryHandler", "log", "UpdateExpectionTicket MicroService", " UpdateNotificationplanning Query : " + strQuery.ToString(), true);
        //    }
        //    catch (Exception ex)
        //    {
        //        objcommon.WriteLog("QueryHandler", "log", "UpdateExpectionTicket MicroService", "UpdateNotificationplanning Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
        //    }
        //    return strQuery.ToString();
        //}
        #endregion
    }
}
