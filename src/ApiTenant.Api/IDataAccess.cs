using ApiTenant.Api.Models;
using System;
using System.Collections.Generic;

namespace ApiTenant.Api
{
    public interface IDataAccess
    {
        public IList<TargetDocument> Documents { get; }
    }

    public class MemoryDataAccess : IDataAccess
    {
        public IList<TargetDocument> Documents => new List<TargetDocument>
        {
            new TargetDocument { Tenant = "oi", VatNumber = "432432", PeriodReference = "09/09" },
            new TargetDocument { Tenant = "oi", VatNumber = "666666", PeriodReference = "09/10" },
            new TargetDocument { Tenant = "btc", BusinessId = "12345", 
                Integrations = new List<Integration> { new Integration { Date = DateTime.Now, System  = "DOC" }, new Integration { Date = DateTime.Now, System = "DOC" } } },
            new TargetDocument { Tenant = "btc", BusinessId = "54335",
                Integrations = new List<Integration> { new Integration { Date = DateTime.Now, System  = "DOC" }, new Integration { Date = DateTime.Now, System = "Notification" } } },
            new TargetDocument { Tenant = "btc", BusinessId = "32423" },
            new TargetDocument { Tenant = "btc", BusinessId = "76575" },
            new TargetDocument { Tenant = "btc", BusinessId = "2121" },
            new TargetDocument { Tenant = "vodafone", VatNumber = "111111", ContractNumber = "323232" },
            new TargetDocument { Tenant = "vodafone", VatNumber = "222222", ContractNumber = "79809" },
            new TargetDocument { Tenant = "vodafone", VatNumber = "432432", ContractNumber = "43252" },
            new TargetDocument { Tenant = "vodafone", VatNumber = "432432", ContractNumber = "99999" }
        };
    }
}