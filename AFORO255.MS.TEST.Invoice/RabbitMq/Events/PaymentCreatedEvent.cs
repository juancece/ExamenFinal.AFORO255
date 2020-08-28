using System;
using MS.AFORO255.Cross.RabbitMQ.Src.Events;

namespace AFORO255.MS.TEST.Invoice.RabbitMq.Events
{
    public class PaymentCreatedEvent : Event
    {
        public int IdOperation { get; set; }
        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public PaymentCreatedEvent(int idOperation, int idInvoice, decimal amount, DateTime date)
        {
            IdOperation = idOperation;
            IdInvoice = idInvoice;
            Amount = amount;
            Date = date;
        }
    }
}