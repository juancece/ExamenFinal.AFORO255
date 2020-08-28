using System.Threading;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Pay.RabbitMq.Commands;
using AFORO255.MS.TEST.Pay.RabbitMq.Events;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.Pay.RabbitMq.CommandHandlers
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public PaymentCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }


        public Task<bool> Handle(PaymentCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new PaymentCreatedEvent(
                request.IdOperation,
                request.IdInvoice,
                request.Amount,
                request.Date));
            return Task.FromResult(true);
        }
    }
}