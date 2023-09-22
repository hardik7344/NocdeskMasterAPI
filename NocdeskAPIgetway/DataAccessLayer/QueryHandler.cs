using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskAPIgetway.DataAccessLayer
{
    public class QueryHandler
    {
        //DatabaseCommon objcommon = new DatabaseCommon();
        NocDeskCommon objcommon = new NocDeskCommon();

        OwnYITConstant.DatabaseTypes dbtype;
        #region Document_Master
        public string GetDocumentMaster()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select ApplicationID,DocumentType,DocumentID,VersionNumbar,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentType,DocumentParentID,Startdate,enddate,Status FROM DocumentMasersdsy111");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select ApplicationID,DocumentType,DocumentID,VersionNumbar,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentType,DocumentParentID,Startdate,enddate,Status FROM DocumentMasersdsy111");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentMaster Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetDocumentMasterbyDoctypeandId(string DocumentID,string DocumentType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct ApplicationID,DocumentType,DocumentID,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentID,DocumentParentType,Startdate,enddate,Status from DocumentMasersdsy111 where DocumentID='{0}' And DocumentType='{1}'", DocumentID, DocumentType );
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct ApplicationID,DocumentType,DocumentID,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentID,DocumentParentType,Startdate,enddate,Status from DocumentMasersdsy111 where DocumentID='{0}' And DocumentType='{1}'", DocumentID, DocumentType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentMasterbyDoctypeandId Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetDocumentMasterbyDoctypeandParentId(string DocumentID, string DocumentType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct ApplicationID,DocumentType,DocumentID,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentID,DocumentParentType,Startdate,enddate,Status,SRNO from DocumentMasersdsy111 where DocumentParentID='{0}' And DocumentType='{1}'", DocumentID, DocumentType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct ApplicationID,DocumentType,DocumentID,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentID,DocumentParentType,Startdate,enddate,Status,SRNO from DocumentMasersdsy111 where DocumentParentID='{0}' And DocumentType='{1}'", DocumentID, DocumentType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "secondlevel Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetDocumentMasterbyDoctype(string DocumentType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct ApplicationID,DocumentType,DocumentID,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentID,DocumentParentType,Startdate,enddate,Status,VenderName,VenderID from DocumentMasersdsy111 where DocumentType='{0}'", DocumentType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct ApplicationID,DocumentType,DocumentID,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentID,DocumentParentType,Startdate,enddate,Status,VenderName,VenderID from DocumentMasersdsy111 where DocumentType='{0}'", DocumentType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentMaster Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string CheckUserExist(string DocumentType, string Status,string DocumentName, string DocumentDescription)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from DocumentMasersdsy111 where DocumentType='{0}' and Status='{1}' and DocumentName='{2}' and DocumentDescription='{3}'", DocumentType, Status,DocumentName,DocumentDescription);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from DocumentMasersdsy111 where DocumentType='{0}' and Status='{1}' and DocumentName='{2}' and DocumentDescription='{3}'", DocumentType, Status, DocumentName, DocumentDescription);
                        //strQuery.AppendFormat("select count(*) from DocumentMasersdsy111 where DocumentType='{0}' and DocumentID='{1}' and Status={2}", DocumentType, DocumentID, Status);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "CheckUserExist Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        //SDRoutingLinkagChack
        public string SDRoutingLinkagChack()
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
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "SDRoutingLinkagChack Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string LinkageChack(string DocumentID, string DocumentType,string EntityType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from DocumentLinkageSDSY131 where DocumentID='{0}' And DocumentType='{1}' And EntityType='{2}'", DocumentID,DocumentType, EntityType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select count(*) from DocumentLinkageSDSY131 where DocumentID='{0}' And DocumentType='{1}' And EntityType='{2}'", DocumentID, DocumentType, EntityType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "LinkageChack Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //
        public string GetDocumentID(string ApplicationID, string DocumentType, string DocumentName, string DocumentDesc)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select top 1 DocumentID from DocumentMasersdsy111 where ApplicationID='{0}' and DocumentType='{1}' and DocumentName='{2}' and DocumentDescription='{3}' and Status=1", ApplicationID, DocumentType, DocumentName, DocumentDesc);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select DocumentID from DocumentMasersdsy111 where ApplicationID='{0}' and DocumentType='{1}' and DocumentName='{2}' and DocumentDescription='{3}' and Status=1 limit 1", ApplicationID, DocumentType, DocumentName, DocumentDesc);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetcontractName(string DocumentID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct DocumentName from DocumentMasersdsy111 where DocumentID='{0}'",DocumentID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct DocumentName from DocumentMasersdsy111 where DocumentID='{0}'", DocumentID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetcontractName Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertDocumentMasterData(string ApplicationID, string DocumentType, string VersionNumbar, string DocumentName, string DocumentDescription, string Docclassifier, string DocuentJSON, string DocParentType, string DocParentID, string startday, string EndDay, string Status , string SRNO, string venderId, string VenderName)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        //"insert into I34EmpActivityUserDetails002(username,password,eid,ename,edesignation,entityid,entityname,startdate,enddate,status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',CONVERT(date, convert(date,'{7}',103),120),CONVERT(date, convert(date,'{8}',103),120),1)", UserName, UserPassword, EmployeeID, EmployeeName, UserType, EntityID, EntityName, startdate, enddate
                        strQuery.AppendFormat("insert into DocumentMasersdsy111(ApplicationID,DocumentType,VersionNumbar,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentType,DocumentParentID,Status,Startdate,enddate,SRNO,VenderID,VenderName) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',CONVERT(date, convert(date,'{10}',103),120),CONVERT(date, convert(date,'{11}',103),120),'{12}','{13}','{14}')", ApplicationID, DocumentType, VersionNumbar, DocumentName, DocumentDescription, Docclassifier, DocuentJSON, DocParentType, DocParentID, Status, startday, EndDay,SRNO,venderId,VenderName);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentMasersdsy111(ApplicationID,DocumentType,VersionNumbar,DocumentName,DocumentDescription,DocumentClassifier,DocumentJSON,DocumentParentType,DocumentParentID,Status,Startdate,enddate,SRNO,VenderID,VenderName) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',CONVERT(date, convert(date,'{10}',103),120),CONVERT(date, convert(date,'{11}',103),120),'{12}','{13}','{14}')", ApplicationID, DocumentType, VersionNumbar, DocumentName, DocumentDescription, Docclassifier, DocuentJSON, DocParentType, DocParentID, Status, startday, EndDay,SRNO,venderId,VenderName);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertDocumentMasterData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertRoutingLinkag(string SDLinkType, string ContractID, string ClauseID, string SLAID, string SLALevel, string OrgID, string OUID, string OULinkType, string SDRollID, string SDPersonID, string SDReceivingID, string UserID, string DeviceID, string SDTTemplateID, string EndDate, string Stutes, string CatID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCurrentRoutingSDSY133(SDLinkageType,ContractID,ClauseID,SLAID,SLALeval,ORGID,OUID,OULinkType,SDrollID,SDPersonID,SDRecevingID,UserID,DeviceID,SDTTemplatelID,Startdate,Enddate,status,CatID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',GetDate(),'{14}','{15}','{16}')", SDLinkType,ContractID,ClauseID,SLAID, SLALevel, OrgID, OUID, OULinkType, SDRollID, SDPersonID, SDReceivingID, UserID, DeviceID, SDTTemplateID,EndDate,Stutes,CatID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into SDCurrentRoutingSDSY133(SDLinkageType,ContractID,ClauseID,SLAID,SLALeval,ORGID,OUID,OULinkType,SDrollID,SDPersonID,SDRecevingID,UserID,DeviceID,SDTTemplatelID,Startdate,Enddate,status,CatID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',GetDate(),'{14}','{15}','{16}')", SDLinkType,ContractID,ClauseID,SLAID, SLALevel, OrgID, OUID, OULinkType, SDRollID, SDPersonID, SDReceivingID, UserID, DeviceID, SDTTemplateID,EndDate,Stutes,CatID);
                        //strQuery.AppendFormat("insert into SDCurrentRoutingSDSY133(SDLinkageType,ContractID,ClauseID,SLAID,SLALeval,ORGID,OUID,OULinkType,SDrollID,SDPersonID,SDRecevingID,UserID,DeviceID,SDTTemplatelID,Startdate,Enddate,status,CatID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',CONVERT(date, convert(date,'{14}',103),120),CONVERT(date, convert(date,'{15}',103),120),'{16}','{17}')", SDLinkType,ContractID,ClauseID,SLAID, SLALevel, OrgID, OUID, OULinkType, SDRollID, SDPersonID, SDReceivingID, UserID, DeviceID, SDTTemplateID,EndDate,Stutes,CatID);
                        //strQuery.AppendFormat("insert into SDCurrentRoutingSDSY133(SDLinkageType,ContractID,ClauseID,SLAID,SLALeval,ORGID,OUID,OULinkType,SDrollID,SDPersonID,SDRecevingID,UserID,DeviceID,SDTTemplatelID,Startdate,Enddate,status,CatID)values()");

                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertRoutingLinkag Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertDocumentSLALInkag(string AppicationID, string DocumentType, string DocumentID, string DocumentSubID, string EntityType, string EntityId, string status)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentLinkageSDSY131(ApplicationID,DocumentType,DocumentID,DocumentSubID,EntityType,Startdate,Enddate,status,EntityID)values('{0}','{1}','{2}','{3}','{4}',GetDate(),Null,'{5}','{6}')", AppicationID, DocumentType,DocumentID, DocumentSubID, EntityType, status, EntityId);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentLinkageSDSY131(ApplicationID,DocumentType,DocumentID,DocumentSubID,EntityType,Startdate,Enddate,status,EntityID)values('{0}','{1}','{2}','{3}','{4}',GetDate(),Null,'{5}','{6}')", AppicationID, DocumentType, DocumentID, DocumentSubID, EntityType, status, EntityId);
                        //strQuery.AppendFormat("insert into DocumentLinkageSDSY131(ApplicationID,DocumentType,DocumentID,DocumentSubID,EntityType,Startdate,Enddate,status,EntityID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7},'{8}')", AppicationID, DocumentType, DocumentID, DocumentSubID, EntityType, Startdate, Enddate, status, EntityId);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertDocumentSLALInkag Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertDocumentInsert(string ApplicationID, string L1Type, string L1ID, string L2Type, string L2ID, string L3Type, string L3ID, string DocumentAttachmentJson ,string Status)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentAttachment(ApplicationID,SourceL1type,SourceL1ID,SourceL2type,SourceL2ID,SourceL3type,SourceL3ID,DocAttachmentJSON,status,DateOfAttachment)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',getdate())", ApplicationID, L1Type, L1ID, L2Type, L2ID, L3Type, L3ID, DocumentAttachmentJson, Status);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentAttachment(ApplicationID,SourceL1type,SourceL1ID,SourceL2type,SourceL2ID,SourceL3type,SourceL3ID,DocAttachmentJSON,status,DateOfAttachment)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',getdate())", ApplicationID, L1Type, L1ID, L2Type, L2ID, L3Type, L3ID, DocumentAttachmentJson, Status);
                        //strQuery.AppendFormat("insert into DocumentLinkageSDSY131(ApplicationID,DocumentType,DocumentID,DocumentSubID,EntityType,Startdate,Enddate,status,EntityID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7},'{8}')", AppicationID, DocumentType, DocumentID, DocumentSubID, EntityType, Startdate, Enddate, status, EntityId);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertDocumentInsert Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string SLACSLinkage(string Categary, string SubCategary)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDCatID from SDCategorizationLinkageSDSY121 where SDCatL1ID='{0}' and SDcatL2ID={1}",Categary,SubCategary);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDCatID from SDCategorizationLinkageSDSY121 where SDCatL1ID='{0}' and SDcatL2ID={1}", Categary, SubCategary);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "SLACSLinkage Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string UpdateDocumentMasterData(string ApplicationID, string DocumentType, string VersionNumbar, string DocumentName, string DocumentDescription, string Docclassifier, string DocuentJSON, string DocParentType, string DocParentID, string startday, string EndDay, string Status)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("update DocumentMasersdsy111 set VersionNumbar='{0}',DocumentName='{1}',DocumentDescription='{2}',DocumentClassifier='{3}',DocumentJSON='{4}',DocumentParentType='{5}',Startdate='{6}',enddate='{7}' where DocumentType='{8}'", VersionNumbar, DocumentName, DocumentDescription, Docclassifier, DocuentJSON, DocParentType, startday, EndDay, DocumentType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("update DocumentMasersdsy111 set VersionNumbar='{0}',DocumentName='{1}',DocumentDescription='{2}',DocumentClassifier='{3}',DocumentJSON='{4}',DocumentParentType='{5}',Startdate='{6}',enddate='{7}' where DocumentType='{8}'", VersionNumbar, DocumentName, DocumentDescription, Docclassifier, DocuentJSON, DocParentType, startday, EndDay, DocumentType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "UpdateDocumentMasterData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string DeleteDocumentMaster(string DocumentID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("DELETE FROM DocumentMasersdsy111 WHERE DocumentID='{0}'", DocumentID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("DELETE FROM DocumentMasersdsy111 WHERE DocumentID = '{0}'", DocumentID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "DeleteDocumentMaster Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #endregion
        public string GetDocumentDetails()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select RecordSerialNumber,ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,startdate,enddate,status From DocumentDetailsSDSY112");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select RecordSerialNumber,ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,startdate,enddate,status From DocumentDetailsSDSY112");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //
        public string GetDocumentDetailsbyDocTypeAndID(string DocumentID, string DocumentType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct RecordSerialNumber,ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,startdate,enddate,status from DocumentDetailsSDSY112 where DocumentType = '{0}' And DocumentID = '{1}'", DocumentType, DocumentID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct RecordSerialNumber,ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,startdate,enddate,status from DocumentDetailsSDSY112 where DocumentType = '{0}' And DocumentID = '{1}'", DocumentType, DocumentID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentDetailsbyDocTypeAndID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetDocumentDetailsbyDocType(string DocumentType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select distinct RecordSerialNumber,ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,startdate,enddate,status from DocumentDetailsSDSY112 where DocumentType = '{0}'", DocumentType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select distinct RecordSerialNumber,ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,startdate,enddate,status from DocumentDetailsSDSY112 where DocumentType = '{0}'", DocumentType);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentDetailsbyDocType Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertDocumentDetailsData(/*string Record_Serial_Number, */string ApplicationID, string DocumentType, string DocumentId, string DocumentsubID, string DocPLID1Id, string DocPLName1, string DocPLID2Id, string DocPLName2, string DocPLID3Id, string DocPLName3, string DocV1, string Docv2, string Docv3, string Document_detail_json, string startdate, string Enddate, string Status)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentDetailsSDSY112(ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,status,startdate,enddate) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',CONVERT(date, convert(date,'{15}',103),120),CONVERT(date, convert(date,'{16}',103),120))", ApplicationID, DocumentType, DocumentId, DocumentsubID, DocPLID1Id, DocPLName1, DocPLID2Id, DocPLName2, DocPLID3Id, DocPLName3, DocV1, Docv2, Docv3, Document_detail_json, Status, startdate, Enddate);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentDetailsSDSY112(ApplicationID,DocumentType,DocumentID,DocumentSubId,Docparalelevel1ID,Docparalelevel1Name,Docparalelevel2ID,Docparalelevel2Name,Docparalelevel3ID,Docparalelevel3Name,Documentvalue1,Documentvalue2,Documentvalue3,DocDetailJson,status,startdate,enddate) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',CONVERT(date, convert(date,'{15}',103),120),CONVERT(date, convert(date,'{16}',103),120))", ApplicationID, DocumentType, DocumentId, DocumentsubID, DocPLID1Id, DocPLName1, DocPLID2Id, DocPLName2, DocPLID3Id, DocPLName3, DocV1, Docv2, Docv3, Document_detail_json, Status, startdate, Enddate);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertDocumentDetailsData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetDocumentDetailsID()
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
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetDocumentDetailsID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //
        public string UpdateDocumentDetailsData(string UserID, string UserPassword, string enddate)
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
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "UpdateDocumentDetailsData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string DeleteDocumentDetails(string DocumentID, string RecordSerialNumber)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("DELETE FROM DocumentDetailsSDSY112 WHERE DocumentID='{0}' and RecordSerialNumber='{1}'", DocumentID, RecordSerialNumber);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("DELETE FROM DocumentDetailsSDSY112 WHERE DocumentID='{0}' and RecordSerialNumber='{1}'", DocumentID, RecordSerialNumber);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "DeleteDocumentDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #region TemplateDetails

        public string GetTemplateDetails()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,SDTTEmplateType,SDChildTTSerialNo,SDChildPreSeq,SDChildTTID,SDChildTTDesc,CONVERT(nvarchar,Startdate,103) as Startdate,CONVERT(nvarchar,Enddate,103) as Enddate,Status from TemplateFlowSDSY142");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,SDTTEmplateType,SDChildTTSerialNo,SDChildPreSeq,SDChildTTID,SDChildTTDesc,CONVERT(nvarchar,Startdate,103) as Startdate,CONVERT(nvarchar,Enddate,103) as Enddate,Status from TemplateFlowSDSY142");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetTemplateList( string SDTTEmplateType)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,SDTTemplateName from TemplateMasterSDSY141 where SDTTEmplateType='{0}'", SDTTEmplateType);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,SDTTemplateName from TemplateMasterSDSY141 where SDTTEmplateType='{0}'", SDTTEmplateType);
                        //strQuery.AppendFormat("select SDTTemplateID,SDTTemplateName from TemplateMasterSDSY141 where SDTTEmplateType='Master'");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateList Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetTemplateDetailsByID(string TemplateID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select TM.SDTTEmplateType,TF.SDChildTTSerialNo,TM.SDTTemplateName,TF.SDChildTTDesc,TF.Status from TemplateMasterSDSY141 TM, TemplateFlowSDSY142 TF where TM.SDTTemplateID= TF.SDChildTTID AND TF.SDTTemplateID='{0}'", TemplateID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select TM.SDTTEmplateType,TF.SDChildTTSerialNo,TM.SDTTemplateName,TF.SDChildTTDesc,TF.Status from TemplateMasterSDSY141 TM, TemplateFlowSDSY142 TF where TM.SDTTemplateID= TF.SDChildTTID AND TF.SDTTemplateID='{0}'", TemplateID);

                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateDetailsByID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetTemplateDetailsByName(string Templatename)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        
                        strQuery.AppendFormat("select SDTTemplateName,SDTTemplateID,SDTTemplateDesc from TemplateMasterSDSY141 where SDTTemplateName='{0}'", Templatename);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateName,SDTTemplateID,SDTTemplateDesc from TemplateMasterSDSY141 where SDTTemplateName='{0}'", Templatename);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateDetailsByName Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertTemplateDetailsData(string TemplateID, string TemplateType, string serialNo, string ChildPreSeq, string ChildId, string Description)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        //strQuery.AppendFormat("insert into TemplateFlowSDSY142(SDTTemplateID,SDTTEmplateType,SDChildTTSerialNo,SDChildPreSeq,SDChildTTID,SDChildTTDesc,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", TemplateID, TemplateType, serialNo, ChildPreSeq, ChildId, Description, StartDate, EndDate, Status);
                        strQuery.AppendFormat("insert into TemplateFlowSDSY142(SDTTemplateID,SDTTEmplateType,SDChildTTSerialNo,SDChildPreSeq,SDChildTTID,SDChildTTDesc,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}',getdate(),'','1')", TemplateID, TemplateType, serialNo, ChildPreSeq, ChildId, Description);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        //strQuery.AppendFormat("insert into TemplateFlowSDSY142(SDTTemplateID,SDTTEmplateType,SDChildTTSerialNo,SDChildPreSeq,SDChildTTID,SDChildTTDesc,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", TemplateID, TemplateType, serialNo, ChildPreSeq, ChildId, Description, StartDate, EndDate, Status);
                        strQuery.AppendFormat("insert into TemplateFlowSDSY142(SDTTemplateID,SDTTEmplateType,SDChildTTSerialNo,SDChildPreSeq,SDChildTTID,SDChildTTDesc,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}',getdate(),'','1')", TemplateID, TemplateType, serialNo, ChildPreSeq, ChildId, Description);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertTemplateDetailsData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetTemplateID()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("SELECT NEXT VALUE FOR TemplateID");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("SELECT NEXT VALUE FOR TemplateID");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateID Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #endregion
        #region TemplateMaster

        public string GetTemplateMaster()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,CONVERT(nvarchar,Startdate,103) as Startdate,CONVERT(nvarchar,Enddate,103) as Enddate,Status from TemplateMasterSDSY141");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,CONVERT(nvarchar,Startdate,103) as Startdate,CONVERT(nvarchar,Enddate,103) as Enddate,Status from TemplateMasterSDSY141");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateMaster Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string GetTemplateMasterDetailsByTemplateType()
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,ApplicationID,SDTTemplateName,SDParentTTmpID,SDTTemplateDesc,DefaultPriority,CONVERT(nvarchar,Startdate,103) as Startdate,CONVERT(nvarchar,Enddate,103) as Enddate,Status from TemplateMasterSDSY141 where SDTTEmplateType='Normal'");
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDTTemplateID,ApplicationID,SDTTemplateName,SDParentTTmpID,SDTTemplateDesc,DefaultPriority,CONVERT(nvarchar,Startdate,103) as Startdate,CONVERT(nvarchar,Enddate,103) as Enddate,Status from TemplateMasterSDSY141 where SDTTEmplateType='Normal'");
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateMasterDetailsByTemplateType Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertTemplateMasterData(string TemplateID, string ApplicationID, string TemplateType, string TemplateName, string ParentID, string ParentType, string Description, string DefaultPriority)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        //strQuery.AppendFormat("insert into TemplateMasterSDSY141(ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",ApplicationID,TemplateType,TemplateName,ParentID, ParentType,Description, DefaultPriority,StartDate,EndDate,Status);
                        strQuery.AppendFormat("insert into TemplateMasterSDSY141(ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,Startdate,Enddate,Status,SDTTemplateID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'','1','{7}')", ApplicationID, TemplateType, TemplateName, ParentID, ParentType, Description, DefaultPriority,TemplateID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        //strQuery.AppendFormat("insert into TemplateMasterSDSY141(ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", ApplicationID, TemplateType, TemplateName, ParentID, ParentType,Description, DefaultPriority, StartDate, EndDate, Status);
                        //strQuery.AppendFormat("insert into TemplateMasterSDSY141(ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'','1')", ApplicationID, TemplateType, TemplateName, ParentID, ParentType, Description, DefaultPriority);
                        strQuery.AppendFormat("insert into TemplateMasterSDSY141(ApplicationID,SDTTEmplateType,SDTTemplateName,SDParentTTmpID,SDParentTTmpType,SDTTemplateDesc,DefaultPriority,Startdate,Enddate,Status,SDTTemplateID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'','1','{7}')", ApplicationID, TemplateType, TemplateName, ParentID, ParentType, Description, DefaultPriority,TemplateID);

                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertTemplateMasterData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string UpdateTemplateMasterData()
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
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "UpdateTemplateMasterData Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #endregion

        #region Template Workflow

        public string GetTemplateWorkflowDetails()
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
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateWorkflowDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        public string InsertTemplateWorkflowDetails(string TemplateID, string TemplateType, string serialNo, string ActName, string ActDetails1,string ActDetails2,string FlowJson)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'','1')", TemplateID, TemplateType, serialNo, ActName, ActDetails1, ActDetails2, FlowJson);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'','1')", TemplateID, TemplateType, serialNo, ActName, ActDetails1, ActDetails2, FlowJson);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertTemplateWorkflowDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }


        #endregion

        #region Template Workflow Steps

        public string GetTemplateWorkflowStepsDetails()
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
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetTemplateWorkflowStepsDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertAddTemplateWorkflowStepsDetails(string TemplateID, string SerialNO, string keyleval, string valueleval)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowStepsSDSY144(SDTTemplateID,SDPActCurrent,SDPActNext,Choice,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}',getdate(),'','1')", TemplateID, SerialNO, valueleval,keyleval);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowStepsSDSY144(SDTTemplateID,SDPActCurrent,SDPActNext,Choice,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}',getdate(),'','1')", TemplateID, SerialNO, valueleval, keyleval);
                        //strQuery.AppendFormat("insert into TemplateWorkFlowStepsSDSY144(SDTTemplateID,SDTTEmplateType,Choice,Startdate,Enddate,Status) values('{0}','{1}','{2}',getdate(),'','1')", TemplateID, TemplateType, ActivityData);
                        //strQuery.AppendFormat("insert into TemplateWorkFlowStepsSDSY144(SDTTemplateID,SDTTEmplateType,SDPActCurrent,SDPActNext,Choice,Startdate,Enddate,Status) values('{0}','{1}','{2}','{3}','{4}',getdate(),'','1')", TemplateID, TemplateType, ActivityData);
                        break;
                }
        }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertAddTemplateWorkflowStepsDetails Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        //InsertTemplatetypeDetails
        public string InsertTemplatetyperaisetException(string TemplateID, string TemplateType,string ActName)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','1','{2}','','','',getdate(),'','1')", TemplateID, TemplateType, ActName);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','1','{2}','','','',getdate(),'','1')", TemplateID, TemplateType, ActName);
                        //strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','0','{2}','{4}','{5}','{6}',getdate(),'','1')", TemplateID, TemplateType,raisetException);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertTemplatetyperaisetException Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertTemplatetypeCloseException(string TemplateID, string TemplateType, string ActName)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','2','{2}','','','',getdate(),'','1')", TemplateID, TemplateType, ActName);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','2','{2}','','','',getdate(),'','1')", TemplateID, TemplateType, ActName);
                        //strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','0','{2}','{4}','{5}','{6}',getdate(),'','1')", TemplateID, TemplateType,raisetException);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertTemplatetypeCloseException Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string InsertTemplatetyperaiseNotifaction(string TemplateID, string TemplateType, string ActName)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','1','{2}','','','',getdate(),'','1')", TemplateID, TemplateType, ActName);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','1','{2}','','','',getdate(),'','1')", TemplateID, TemplateType, ActName);
                        //strQuery.AppendFormat("insert into TemplateWorkFlowSDSY143(SDTTemplateID,SDTTEmplateType,SDPActSerialNo,ActName,ActDet1,ActDet2,FlowJSON,Startdate,Enddate,Status) values('{0}','{1}','0','{2}','{4}','{5}','{6}',getdate(),'','1')", TemplateID, TemplateType,raisetException);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertTemplatetyperaiseNotifaction Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        // Normal Templat Linkag

        public string NormalTemplatLinkag( string Category, string SubCategory, string Item)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select SDCatID from SDCategorizationLinkageSDSY121 where SDCatL1ID = '{0}' and SDcatL2ID = '{1}' and SDcatL3ID = '{2}'", Category,SubCategory,Item);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select SDCatID from SDCategorizationLinkageSDSY121 where SDCatL1ID = '{0}' and SDcatL2ID = '{1}' and SDcatL3ID = '{2}'", Category,SubCategory,Item);
                        //strQuery.AppendFormat("select SDCatID from SDCategorizationLinkageSDSY121 where SDCatL1Name = '{0}' and SDCatL2Name = '{1}' and SDCatL3Name = '{2}'", Category, SubCategory, Item);

                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "NormalTemplatLinkag Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }

        //Insert Document Linkag
        public string InsertNormalTemplatLinkag(string ApplicationID,string DocumentType,string DocumentID,string EntityType, string EntityID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentLinkageSDSY131(ApplicationID, DocumentType, DocumentID, DocumentSubID, EntityType, Startdate, Enddate, status, EntityID)values('{0}', '{1}', '{2}', '', '{3}', getdate(), '', '1', '{4}')", ApplicationID, DocumentType, DocumentID, EntityType, EntityID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("insert into DocumentLinkageSDSY131(ApplicationID, DocumentType, DocumentID, DocumentSubID, EntityType, Startdate, Enddate, status, EntityID)values('{0}', '{1}', '{2}', '', '{3}', getdate(), '', '1', '{7}')", ApplicationID, DocumentType, DocumentID, EntityType, EntityID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "InsertNormalTemplatLinkag Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        public string GetLinkageMaster(string DocumentID)
        {
            StringBuilder strQuery = new StringBuilder();
            try
            {
                switch (dbtype)
                {
                    case OwnYITConstant.DatabaseTypes.MSSQL_SERVER:
                        strQuery.AppendFormat("select DocumentAttachmentID,DocAttachmentJSON from DocumentAttachment where SourceL1ID = '{0}'", DocumentID);
                        break;
                    case OwnYITConstant.DatabaseTypes.MYSQL_SERVER:
                        strQuery.AppendFormat("select DocumentAttachmentID,DocAttachmentJSON from DocumentAttachment where SourceL1ID = '{0}'", DocumentID);
                        break;
                }
            }
            catch (Exception ex)
            {
                objcommon.WriteLog("QueryHandler", "log", "secondlevel", "GetLinkageMaster Exception : " + ex.Message.ToString() + " , Query : " + strQuery.ToString(), true);
            }
            return strQuery.ToString();
        }
        #endregion
    }
}
