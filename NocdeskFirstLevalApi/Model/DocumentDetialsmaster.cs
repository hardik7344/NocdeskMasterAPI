using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskFirstLevalApi.Model
{
    public class DocumentDetialsmaster
    {
        public string action_type { get; set; }
        public string ApplicationID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentId { get; set; }
        public string DocumentsubID { get; set; }
        public string DocPLID1Id { get; set; }
        public string DocPLName1 { get; set; }
        public string DocPLID2Id { get; set; }
        public string DocPLName2 { get; set; }
        public string DocPLID3Id { get; set; }
        public string DocPLName3 { get; set; }
        public string DocV1 { get; set; }
        public string Docv2 { get; set; }
        public string Docv3 { get; set; }
        public string Document_detail_json { get; set; }
        public string startdate { get; set; }
        public string Enddate { get; set; }
        public string Status { get; set; }
    }
}
