using System.Threading.Tasks;
using AFORO255.MS.TEST.Transaction.RabbitMq.Events;
using AFORO255.MS.TEST.Transaction.Service;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.Transaction.RabbitMq.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly IServiceTransaction _serviceTransaction;

        public TransactionEventHandler(IServiceTransaction serviceTransaction)
        {
            _serviceTransaction = serviceTransaction;
        }

        public Task Handle(TransactionCreatedEvent @event)
        {
            _serviceTransaction.Add(new Model.Transaction
            {
                IdTransaction = @event.IdOperation,
                IdInvoice = @event.IdInvoice,
                Amount = @event.Amount,
                Date = @event.Date
            });
            
            return Task.CompletedTask;
        }
    }
}