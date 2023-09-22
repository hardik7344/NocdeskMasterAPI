using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NocdeskTicketAPIgetway.BusinessLogic;
using NocdeskTicketAPIgetway.DataAccessLayer;
using NocdeskTicketAPIgetway.Model;

namespace NocdeskTicketAPIgetway.Controllers
{
    [Route("NocdeskTicket/[controller]/[action]")]
    [ApiController]
    public class CreateTicketController : ControllerBase
    {
        CreateTicket objCreateTicket = new CreateTicket();
        DataTable dt = new DataTable();
        NocDeskCommon objCom = new NocDeskCommon();
        string jsonvalue = "";
        //POST: NocdeskTicket/CreateTicket/CreateTicketdata
        [HttpPost]
        public string CreateTicketdata([FromBody] ParameterJSON objParam)
        {
            string dt1 = objCreateTicket.CreateTicketdata(objParam.user_json);
            return dt1;
        }
        //GET Ticket 
        // GET: NocdeskTicket/CreateTicket/GetTicket/SRuserID
        [HttpGet("{SRuserID}/{UserType}/{TicketType}")]
        public DataTable GetTicket(string SRuserID, string UserType, string TicketType)
        {
            dt = objCreateTicket.GetTicketdata(SRuserID, UserType, TicketType);
            return dt;
        }

        //GET Ticket 
        // GET: NocdeskTicket/CreateTicket/GetTicketServiceDelivery
        [HttpGet]
        public DataTable GetTicketServiceDelivery()
        {
            dt = objCreateTicket.GetTicketServiceDelivery();
            return dt;
        }

        //GET Ticket 
        // GET: NocdeskTicket/CreateTicket/GetTicketDetailsdata/TicketID/TicketType
        [HttpGet("{TicketID}/{TicketType}")]
        public DataTable GetTicketDetailsdata(string TicketID, string TicketType)
        {
            dt = objCreateTicket.GetTicketDetailsdata(TicketID,TicketType);
            return dt;
        }
        [HttpGet("{TicketID}/{TicketType}")]
        public DataTable GetTicketActiviteData(string TicketID, string TicketType)
        {
            dt = objCreateTicket.GetTicketActiviteData(TicketID, TicketType);
            return dt;
        }
        //
        //GET: NocdeskTicket/CreateTicket/GetGroupTicket/OUID/Category/SubCategory/item
        [HttpGet("{OUID}/{Category}/{SubCategory}/{item}")]
        public DataTable GetGroupTicket(string OUID, string Category, string SubCategory , string item)
        {
            dt = objCreateTicket.GetGroupTicket(OUID, Category, SubCategory, item);
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/CreateGroupTicketdata
        [HttpPost]
        public async Task<DataTable> CreateGroupTicketdata([FromBody] ParameterJSON objParam)
        {
            dt = await objCreateTicket.CreateGroupTicketdata(objParam.user_json);
            return dt;
        }
        //GET: NocdeskTicket/CreateTicket/GetMasterTicket
        [HttpGet]
        public DataTable GetMasterTicket()
        {
            dt = objCreateTicket.GetMasterTicket();
            return dt;
        }
        ////GET: NocdeskTicket/CreateTicket/GetNoramTicketOfMaster
        //[HttpGet("{parentTicketID}/{SDTTemplateID}/{TicketID}")]
        //public DataTable GetNoramTicketOfMaster(string parentTicketID , string SDTTemplateID , string TicketID)
        //{
        //    dt = objCreateTicket.GetNoramTicketOfMaster(parentTicketID, SDTTemplateID, TicketID);
        //    return dt;
        //}
        //GET: NocdeskTicket/CreateTicket/GetNoramTicketOfMaster
        [HttpGet("{parentTicketID}")]
        public DataTable GetNoramTicketOfMaster(string parentTicketID)
        {
            dt = objCreateTicket.GetNoramTicketOfMaster(parentTicketID);
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/CreateMesterTicketdata
        [HttpPost]
        public async Task<DataTable> CreateMesterTicketdata([FromBody] ParameterJSON objParam)
        {
            dt = await objCreateTicket.CreateMesterTicketdata(objParam.user_json);
            return dt;
        }
        //GET: NocdeskTicket/CreateTicket/GetMasterTicket
        [HttpGet]
        public DataTable GetPannedTicket()
        {
            dt = objCreateTicket.GetPannedTicket();
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/CreatePannedTicketdata
        [HttpPost]
        public async Task<DataTable> CreatePannedTicketdata([FromBody] ParameterJSON objParam)
        {
            dt = await objCreateTicket.CreatePanneTicketdata(objParam.user_json);
            return dt;
        }

        #region SDDelivery

        [HttpGet]
        //GET: NocdeskTicket/CreateTicket/GetSDcategoryTebal
        public DataTable GetSDcategoryTebal()
        {
            dt = objCreateTicket.GetSDcategoryTebal();
            return dt;
        }
        [HttpGet("{SDCatID}")]
        //Delete :NocdeskTicket/CreateTicket/DeleteSDcategoryTebal
        public DataTable DeleteSDcategoryTebal(string SDCatID)
        {
            dt = objCreateTicket.DeleteSDcategoryTebal(SDCatID);
            return dt;
        }
        //Get Category

        [HttpGet]
          //GET: NocdeskTicket/CreateTicket/GetCategory
        public DataTable GetCategory()
        {
            dt = objCreateTicket.GetCategory();
            return dt;
        }
        //End Get Category
        //Get Sub Category
        [HttpGet("{category}")]
        //GET: NocdeskTicket/CreateTicket/GetSubCategory/category
        public DataTable GetSubCategory(string category)
        {
            dt = objCreateTicket.GetsubCategory(category);
            return dt;
        }
        //End Get sub Category
        [HttpGet("{Subcategory}")]
        //GET: NocdeskTicket/CreateTicket/Getitem/Subcategory
        public DataTable Getitem(string Subcategory)
        {
            dt = objCreateTicket.Getitem(Subcategory);
            return dt;
        }
        //End Get sub Category
        //POST: NocdeskTicket/CreateTicket/CreateCategory
        [HttpPost]
        public DataTable CreateCategory([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.CreateCategory(objParam.user_json);
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/CreateSubCategory
        [HttpPost]
        public DataTable CreateSubCategory([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.CreateSubCategory(objParam.user_json);
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/Createitem
        [HttpPost]
        public DataTable Createitem([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.Createitem(objParam.user_json);
            return dt;
        }

        //POST: NocdeskTicket/CreateTicket/CreateSDDeliverydata
        [HttpPost]
        public DataTable CreateSDDeliverydata([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.CreateSDDeliverydata(objParam.user_json);
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/CreateChildTicketdata
        [HttpPost]
        public DataTable CreateChildTicketdata([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.CreateChildTicketdata(objParam.user_json);
            return dt;
        }
        #endregion

        #region Ticket_Dashboard
        //GET:Ticket Dashboard Count for Status Wish Ticket
        //GET: NocdeskTicket/CreateTicket/Get_Status_Count_Wish_Ticket
        [HttpGet]
        public DataTable Get_Status_Count_Wish_Ticket()
        {
            dt = objCreateTicket.Get_Count_Status_Wish_Ticket();
            return dt;
        }
        //GET:Ticket Dashboard Count for Engineer Wish Ticket
        //GET: NocdeskTicket/CreateTicket/Get_Engineer_Count_Wish_Ticket
        [HttpGet]
        public DataTable Get_Engineer_Count_Wish_Ticket()
        {
            dt = objCreateTicket.Get_Engineer_Count_Wish_Ticket();
            return dt;
        }
        //GET:Ticket Dashboard Count for Assing Wish Ticket
        //GET: NocdeskTicket/CreateTicket/Get_Assing_Count_Wish_Ticket
        [HttpGet]
        public DataTable Get_Assing_Count_Wish_Ticket()
        {
            dt = objCreateTicket.Get_Assing_Count_Wish_Ticket();
            return dt;
        }
        //GET Ticket Dashboard for Status Wish Ticket
        // GET: NocdeskTicket/CreateTicket/Get_Status_Wish_Ticket
        [HttpGet("{CurrentStatus}")]
        public DataTable Get_Status_Wish_Ticket(string CurrentStatus)
        {
            dt = objCreateTicket.Get_Status_Wish_Ticket(CurrentStatus);
            return dt;
        }
        //GET Ticket Dashboard for Engineer Wish Ticket
        // GET: NocdeskTicket/CreateTicket/Get_Engineer_Wish_Ticket/CurrentSDRollID
        [HttpGet("{SRuserID}")]
        public DataTable Get_Engineer_Wish_Ticket(string SRuserID)
        {
            dt = objCreateTicket.Get_Engineer_Wish_Ticket(SRuserID);
            return dt;
        }

        //GET Ticket Dashboard for Assign Wish Ticket
        // GET: NocdeskTicket/CreateTicket/Get_Assign_Ticket/CurrentStatus/CurrentSDRollID
        [HttpGet("{CurrentStatus}/{CurrentSDRollID}")]
        public DataTable Get_Assign_Ticket(string CurrentStatus,string CurrentSDRollID)
        {
            dt = objCreateTicket.Get_Assign_Ticket(CurrentStatus, CurrentSDRollID);
            return dt;
        }
        #endregion
        #region User
        //Get userside dashboard 
        [HttpGet("{GetUserdashboard}")]
        //GET: NocdeskTicket/CreateTicket/GetUserdashboard/CurrentSDRollID
        public DataTable GetUserdashboard(string GetUserdashboard)
        {
            dt = objCreateTicket.GetUserdashboard(GetUserdashboard);
            return dt;
        }
        #endregion
       
        #region oubind
        //[HttpPost]
        //public async Task<string> selectbranchunit()
        //{
        //    jsonvalue = objCom.GetOUJson();
        //    return jsonvalue;
        //}
        #endregion

        #region Notification Ticket
        //POST: NocdeskTicket/CreateTicket/CreateNotificatinTicket
        [HttpPost]
        public DataTable CreateNotificatinTicket([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.CreateNotificatinTicket(objParam.user_json);
            return dt;
        }
        //GET: NocdeskTicket/CreateTicket/GetNotificatinTicket
        [HttpGet("{TicketType}/{UserID}")]
        public DataTable GetNotificatinTicket(string TicketType,string UserID)
        {
            dt = objCreateTicket.GetNotificatinTicket(TicketType, UserID);
            return dt;
        }
        //GET: NocdeskTicket/CreateTicket/GetUserNotificatinTicket
        [HttpGet("{TicketType}/{GetDeliveryID}")]
        public DataTable GetUserNotificatinTicket(string TicketType, string GetDeliveryID)
        {
            dt = objCreateTicket.GetUserNotificatinTicket(TicketType, GetDeliveryID);
            return dt;
        }
        
        #endregion
        #region exception Ticket

        //GET: NocdeskTicket/CreateTicket/GetExceptionTicket
        [HttpGet("{TicketType}/{UserID}")]
        public DataTable GetExceptionTicket(string TicketType,string UserID)
        {
            dt = objCreateTicket.GetExceptionTicket(TicketType, UserID);
            return dt;
        }
        //GET: NocdeskTicket/CreateTicket/GetUserExceptionTicket
        [HttpGet("{TicketType}/{GetDeliveryID}")]
        public DataTable GetUserExceptionTicket( string TicketType ,string GetDeliveryID)
        {
            dt = objCreateTicket.GetUserExceptionTicket(TicketType, GetDeliveryID);
            return dt;
        }
        //POST: NocdeskTicket/CreateTicket/CreateExceptionTicket
        [HttpPost]
        public DataTable CreateExceptionTicket([FromBody] ParameterJSON objParam)
        {
            dt = objCreateTicket.CreateExceptionTicket(objParam.user_json);
            return dt;
        }
        #endregion
    }

}