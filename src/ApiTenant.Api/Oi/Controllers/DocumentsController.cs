using System;
using System.Linq;
using ApiTenant.Api.Filters;

using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Api.Oi.Controllers
{
    [TenantPermission(Tenants.Oi)]
    [Route("api/" + Tenants.Oi)]
    public class DocumentsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;
        private readonly ILogger logger;

        public DocumentsController(IDataAccess dataAcess, ILogger logger)
        {
            this._dataAccess = dataAcess;
            this.logger = logger;
        }

        [HttpGet]
        [Route("documents")]
        [ApiExplorerSettings(GroupName = Tenants.Oi)]
        public IActionResult Get()
        {
            this.logger.Log("nidfonfsiofsd");
            return Ok(this._dataAccess.Documents.Where(d => d.Tenant == Tenants.Oi).Select(d => new GetDocumentResponse(d)));
        }

        [HttpGet]
        [Route("document")]
        [ApiExplorerSettings(GroupName = Tenants.Oi)]
        public IActionResult Get([FromQuery]GetDocumentRequest request)
        {
            if (string.IsNullOrEmpty(request.VatNumber))
                throw new ArgumentNullException("Vat Number is required");

            if (string.IsNullOrEmpty(request.PeriodReference))
                throw new ArgumentNullException("Period Reference is required");

            var document = this._dataAccess.Documents.FirstOrDefault(d => d.Tenant == Tenants.Oi && d.VatNumber == request.VatNumber
                && d.PeriodReference == request.PeriodReference);

            if (document == null)
                return NotFound();

            return Ok(new GetDocumentResponse(document));
        }
    }
}
