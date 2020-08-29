using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Transaction.DTO;
using AFORO255.MS.TEST.Transaction.Service;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceTransaction _serviceTransaction;

        public TransactionController(IServiceTransaction serviceTransaction)
        {
            _serviceTransaction = serviceTransaction;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceTransaction.GetAll());
        }

        // [HttpPost]
        // public async Task<IActionResult> Post([FromBody] Model.Transaction transaction)
        // {
        //     await _serviceTransaction.Add(transaction);
        //     return Ok();
        // }

        [HttpGet("{idinvoice}")]
        public async Task<IActionResult> Get(int idinvoice)
        {
            List<TransactionDto> model = null;
            
            var result = await _serviceTransaction.GetAll();
            model = result.Where(x => x.IdInvoice == idinvoice).ToList();
            
            return Ok(model);
        }
    }
}