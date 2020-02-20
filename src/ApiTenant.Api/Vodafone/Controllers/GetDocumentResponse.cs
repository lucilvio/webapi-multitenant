using ApiTenant.Api.Models;

namespace ApiTenant.Api.Vodafone.Controllers
{
    internal class GetDocumentResponse
    {
        public GetDocumentResponse(TargetDocument document)
        {
            this.VatNumber = document.VatNumber;
            this.ContractNumber = document.ContractNumber;
        }

        public string VatNumber { get; }
        public string ContractNumber { get; }
    }
}