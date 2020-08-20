using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.Model
{
    [Table("invoice")]
    public class Invoice
    {
        [Column("id")] 
        public int Id { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("state")]
        public int State { get; set; }
    }
}