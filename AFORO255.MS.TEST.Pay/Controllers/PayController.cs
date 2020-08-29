using System;
using AFORO255.MS.TEST.Pay.DTO;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.RabbitMq.Commands;
using AFORO255.MS.TEST.Pay.Service;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly IServicePay _servicePay;

        public PayController(IEventBus bus, IServicePay servicePay)
        {
            _bus = bus;
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
            
            var payCommand = new PaymentCreateCommand(
                idOperation: operation.IdOperation,
                idInvoice: operation.IdInvoice,
                amount: operation.Amount,
                date: operation.Date);
            _bus.SendCommand(payCommand);
            
            var transactionCommand = new TransactionCreateCommand(
                idOperation: operation.IdOperation,
                idInvoice: operation.IdInvoice,
                amount: operation.Amount,
                date: operation.Date);
            _bus.SendCommand(transactionCommand);

            return Ok(operation);
        }
    }
}