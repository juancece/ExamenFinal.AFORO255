using System;

namespace AFORO255.MS.TEST.Pay.RabbitMq.Commands
{
    public class TransactionCreateCommand : TransactionCommand
    {
        public TransactionCreateCommand(int idOperation, int idInvoice, decimal amount, DateTime date)
        {
            IdOperation = idOperation;
            IdInvoice = idInvoice;
            Amount = amount;
            Date = date;
        }
    }
}