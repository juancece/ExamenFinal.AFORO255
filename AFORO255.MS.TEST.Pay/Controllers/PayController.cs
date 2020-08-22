using System;
using AFORO255.MS.TEST.Pay.DTO;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Service;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IServicePay _servicePay;

        public PayController(IServicePay servicePay)
        {
            _servicePay = servicePay;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servicePay.GetAll());
        }

        [HttpPost]
        public IActionResult PostPay([FromBody] PayDto payDto)
        {
            var operation = new Operation
            {
                IdInvoice = payDto.IdInvoice,
                Amount = payDto.Amount,
                Date = DateTime.Now
            };

            operation = _servicePay.RegisterPay(operation);

            return Ok(operation);
        }
    }
}