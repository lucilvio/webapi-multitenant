using ApiTenant.Api.Models;

namespace ApiTenant.Api.Oi.Controllers
{
    internal class GetDocumentResponse
    {
        public GetDocumentResponse(TargetDocument document)
        {
            this.VatNumber = document.VatNumber;
            this.PeriodReference = document.PeriodReference;
        }

        public string VatNumber { get; }
        public string PeriodReference { get; }
    }
}