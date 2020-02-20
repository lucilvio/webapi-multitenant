using System;
using System.Collections.Generic;

namespace ApiTenant.Api.Models
{
    public class TargetDocument
    {
        public string VatNumber { get; set; }
        public string ContractNumber { get; set; }
        public string BusinessId { get; set; }
        public string PeriodReference { get; set; }
        public string Tenant { get; set;  }

        public List<Integration> Integrations { get; set; }
    }

    public class Integration
    {
        public string System { get; set; }
        public DateTime Date { get; set; }
    }
}
