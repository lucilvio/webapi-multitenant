using System;
using System.Linq;

using ApiTenant.Api.Filters;

using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Api.Btc.Controllers
{
    [TenantPermission(Tenants.Btc)]
    [Route("api/" + Tenants.Btc)]
    public class DocumentsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public DocumentsController(IDataAccess dataAcess)
        {
            this._dataAccess = dataAcess;
        }

        [HttpGet]
        [Route("documents")]
        [ApiExplorerSettings(GroupName = Tenants.Btc)]
        public IActionResult Get()
        {
            return Ok(this._dataAccess.Documents.Where(d => d.Tenant == Tenants.Btc).Select(d => new GetDocumentResponse(d)));
        }

        [HttpGet]
        [Route("document/{businessId}")]
        [ApiExplorerSettings(GroupName = Tenants.Btc)]
        public IActionResult Get(string businessId)
        {
            if (string.IsNullOrEmpty(businessId))
                throw new ArgumentNullException("BusinessId is required");

            var document = this._dataAccess.Documents.FirstOrDefault(d => d.Tenant == Tenants.Btc && d.BusinessId == businessId);

            if (document == null)
                return NotFound();

            return Ok(new GetDocumentResponse(document));
        }

        [HttpGet]
        [Route("document/{businessId}/integrations")]
        [ApiExplorerSettings(GroupName = Tenants.Btc)]
        public IActionResult GetIntegrations(string businessId)
        {
            if (string.IsNullOrEmpty(businessId))
                throw new ArgumentNullException("BusinessId is required");

            var document = this._dataAccess.Documents.FirstOrDefault(d => d.Tenant == Tenants.Btc && d.BusinessId == businessId);

            if (document == null)
                return NotFound();

            return Ok(document.Integrations);
        }
    }
}
