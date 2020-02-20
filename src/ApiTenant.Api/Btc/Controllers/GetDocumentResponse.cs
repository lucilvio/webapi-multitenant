using System.Collections.Generic;
using ApiTenant.Api.Models;

namespace ApiTenant.Api.Btc.Controllers
{
    internal class GetDocumentResponse
    {
        public GetDocumentResponse(TargetDocument document)
        {
            this.BusinessId = document.BusinessId;
            this.Integrations = document.Integrations;
        }

        public string BusinessId { get; }

        public List<Integration> Integrations { get; }
    }
}