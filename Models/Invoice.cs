
namespace NonProfitBlazorSite.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int MemberId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
