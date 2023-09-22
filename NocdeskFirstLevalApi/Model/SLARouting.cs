using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskFirstLevalApi.Model
{
    public class SLARouting
    {
        public string action_type { get; set; }
        public string ApplicationID { get; set; }
        public string SRuserID { get; set; }
        public string SDLinkType { get; set; }
        public string SDLinkID { get; set; }
        public string ContractID { get; set; }
        public string ClauseID { get; set; }
        public string SLAID { get; set; }
        public string SLALevel { get; set; }
        public string OrgID { get; set; }
        public string OUID { get; set; }
        public string OULinkType { get; set; }
        public string SDRollID { get; set; }
        public string SDPersonID { get; set; }
        public string UserID { get; set; }
        public string DeviceID { get; set; }
        public string SDTTemplateID { get; set; }
        public string CatID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string SDReceivingID { get; set; }
        public string TData { get; set; }
    }
}
