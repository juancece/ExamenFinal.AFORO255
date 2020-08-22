using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Model
{
    public class Operation
    {
        [Key]
        [Column("idoperation")]
        public int IdOperation { get; set; }
        [Column("idinvoice")]
        public int IdInvoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}