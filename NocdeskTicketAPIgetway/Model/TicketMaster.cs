using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskTicketAPIgetway.Model
{
    public class TicketMaster
    {
        public string action_type { get; set; }
        public string ApplicationID { get; set; }
        public int TicketID { get; set; }
        public string TicketType { get; set; }
        public string TicketTemplateID { get; set; }
        public string ParentTicketID { get; set; }
        public string ParentTicketType { get; set; }
        public string Ticketpriority { get; set; }
        public string UserID { get; set; }
        public string DeliveryID { get; set; }
        public string SDrollID { get; set; }
        public string OuId { get; set; }
        public string DeviceID { get; set; }
        public string SLAID { get; set; }
        public string SLALeval { get; set; }
        public string CurrentStatus { get; set; }
        public string Creationdate { get; set; }
        public string CurrentDate { get; set; }
        public string Expecteddate { get; set; }
        public string Visible { get; set; }
        public string CategorizationID { get; set; }
        public string CategorizationL1 { get; set; }
        public string CategorizationL2 { get; set; }
        public string CategorizationL3 { get; set; }
        public string ActionDescription { get; set; }
        public string displayDescription { get; set; }
        public string TicketJson { get; set; }
    }
}
