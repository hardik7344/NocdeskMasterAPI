using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskAPIgetway.Model
{
    public class MasterUserJson
    {
        public string action_type { get; set; }
        public string ApplicationID { get; set; }
        public string TemplateID { get; set; }
        public string ParentID { get; set; }
        public string ParentType { get; set; }
        public string DefaultPriority{ get; set; }
        public string TemplateType{ get; set; }
        public string TemplateName{ get; set; }
        public string Description { get; set; }
        public string serialNo { get; set; }
        public string ChildPreSeq{ get; set; }
        public string strData{ get; set; }
    }
}
