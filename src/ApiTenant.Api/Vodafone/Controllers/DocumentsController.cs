using System;
using System.Linq;
using ApiTenant.Api.Filters;

using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Api.Vodafone.Controllers
{
    [TenantPermission(Tenants.Vodafone)]
    [Route("api/" + Tenants.Vodafone)]
    public class DocumentsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public DocumentsController(IDataAccess dataAcess)
        {
            this._dataAccess = dataAcess;
        }

        [HttpGet]
        [Route("documents")]
        [ApiExplorerSettings(GroupName = Tenants.Vodafone)]
        public IActionResult Get()
        {
            return Ok(this._dataAccess.Documents.Where(d => d.Tenant == Tenants.Vodafone).Select(d => new GetDocumentResponse(d)));
        }

        [HttpGet]
        [Route("document")]
        [ApiExplorerSettings(GroupName = Tenants.Vodafone)]
        public IActionResult Get([FromQuery]GetDocumentRequest request)
        {
            if (string.IsNullOrEmpty(request.ContractNumber))
                throw new ArgumentNullException("Contract Number is required");

            if (string.IsNullOrEmpty(request.VatNumber))
                throw new ArgumentNullException("Vat Number is required");

            var document = this._dataAccess.Documents.FirstOrDefault(d => d.Tenant == Tenants.Vodafone && d.ContractNumber == request.ContractNumber
                && d.VatNumber == request.VatNumber);

            if (document == null)
                return NotFound();

            return Ok(new GetDocumentResponse(document));
        }
    }
}
