using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskFirstLevalApi.Model
{
    public class ContractMaster
    {
        public string action_type { get; set; }
        public string ApplicationID { get; set; }
        public string DocumentType { get; set; }
        public string VersionNumbar { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string Docclassifier { get; set; }
        public string DocuentJSON { get; set; }
        public string DocParentType { get; set; }
        public string DocParentID { get; set; }
        public string startday { get; set; }
        public string EndDay { get; set; }
        public string Status { get; set; }
        public string strData { get; set; }
        public string vendorID { get; set; }
        public string VendorName { get; set; }
        public string SRNo { get; set; }

    }
}
