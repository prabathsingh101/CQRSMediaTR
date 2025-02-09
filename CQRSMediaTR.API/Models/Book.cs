
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace CQRSMediaTR.API.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int? AuthorID { get; set; }
        public int? PublisherID { get; set; }
        public string? ISBN { get; set; }
        public int? PublicationYear { get; set; }
        public string? Bookcategory { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual Author? Authors { get; set; }
        public virtual Publisher? Publisher { get; set; }
    }
}
