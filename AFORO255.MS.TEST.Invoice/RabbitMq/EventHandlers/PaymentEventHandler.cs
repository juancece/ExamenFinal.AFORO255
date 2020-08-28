using System.Threading.Tasks;
using AFORO255.MS.TEST.Invoice.RabbitMq.Events;
using AFORO255.MS.TEST.Invoice.Service;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.Invoice.RabbitMq.EventHandlers
{
    public class PaymentEventHandler : IEventHandler<PaymentCreatedEvent>
    {
        private readonly IServiceInvoice _serviceInvoice;

        public PaymentEventHandler(IServiceInvoice serviceInvoice)
        {
            _serviceInvoice = serviceInvoice;
        }

        public Task Handle(PaymentCreatedEvent @event)
        {
            _serviceInvoice.Pay(@event.IdInvoice);
            return Task.CompletedTask;
        }
    }
}