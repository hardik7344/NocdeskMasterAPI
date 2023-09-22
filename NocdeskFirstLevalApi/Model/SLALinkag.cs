using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskFirstLevalApi.Model
{
    public class SLALinkag
    {
        public string action_type { get; set; }

        public string AppicationID { get; set; }

        public string DocumentType { get; set; }

        public string DocumentName { get; set; }

        public string DocumentID { get; set; }
        public string  DocumentSubID { get; set; }

        public string EntityType { get; set; }

        public string EntityId { get; set; }

        public string EntityName { get; set; }

        public string startDate { get; set; }

        public string EndDate { get; set; }

        public string Stutes { get; set; }
        public string TData { get; set; }

    }
}
