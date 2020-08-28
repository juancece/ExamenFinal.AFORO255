using System;
using MS.AFORO255.Cross.RabbitMQ.Src.Commands;

namespace AFORO255.MS.TEST.Pay.RabbitMq.Commands
{
    public class PaymentCommand : Command
    {
        public int IdOperation { get; set; }
        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}