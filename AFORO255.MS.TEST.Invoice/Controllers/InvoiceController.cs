using AFORO255.MS.TEST.Invoice.Service;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Invoice.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IServiceInvoice _serviceInvoice;

        public InvoiceController(IServiceInvoice serviceInvoice)
        {
            _serviceInvoice = serviceInvoice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceInvoice.GetAll());
        }
    }
}