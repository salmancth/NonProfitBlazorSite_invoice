
namespace NonProfitBlazorSite.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; }
        public string MediaUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
