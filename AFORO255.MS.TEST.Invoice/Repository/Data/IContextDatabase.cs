using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Invoice.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Model.Invoice> Invoices { get; set; }
    }
}