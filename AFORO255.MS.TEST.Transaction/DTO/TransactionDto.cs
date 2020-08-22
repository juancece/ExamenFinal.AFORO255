using System;

namespace AFORO255.MS.TEST.Transaction.DTO
{
    public class TransactionDto
    {
        public int IdTransaction { get; set; }
        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}