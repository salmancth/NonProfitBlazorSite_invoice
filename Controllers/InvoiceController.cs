
using Microsoft.AspNetCore.Mvc;
using NonProfitBlazorSite.Models;
using System.Linq;

namespace NonProfitBlazorSite.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("generate")]
        public IActionResult GenerateInvoices()
        {
            var members = _context.Members.ToList();
            foreach (var member in members)
            {
                var invoice = new Invoice
                {
                    MemberId = member.MemberId,
                    InvoiceNumber = $"INV-{DateTime.Now:yyyyMMddHHmmss}-{member.MemberId}",
                    Amount = 50.00m, // Fixed fee, can be dynamic
                    InvoiceDate = DateTime.Now,
                    IsPaid = false
                };
                _context.Add(invoice);
            }

            _context.SaveChanges();
            return Ok(new { message = "Invoices generated for all users!" });
        }

        [HttpGet("list/{memberId}")]
        public IActionResult GetMemberInvoices(int memberId)
        {
            var invoices = _context.Invoices.Where(i => i.MemberId == memberId).ToList();
            return Ok(invoices);
        }
    }
}
