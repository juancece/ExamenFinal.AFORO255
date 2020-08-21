using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Model
{
    public class Operation
    {
        [Key]
        [Column("id_operation")]
        public int Id_Operation { get; set; }
        [Column("id_invoice")]
        public int Id_Invoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}