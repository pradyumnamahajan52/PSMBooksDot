using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMBooksDot.API.Models
{

    [Table("books")]
    public class Books
    {
        [Key]
        [Column("id", TypeName = "char(36)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid(); // Auto-generate GUID

        [Column("title", TypeName = "varchar(255)")]
        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        [Column("author", TypeName = "varchar(255)")]
        [StringLength(255)]
        [Required]
        public string Author { get; set; }

        [Column("category_id", TypeName = "int")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public BooksCategory Category { get; set; }

        [Column("description", TypeName = "text")]
        public string? Description { get; set; }


        [Column("published_year", TypeName = "int")]
        public int PublishedYear { get; set; }

        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column("image_url", TypeName = "varchar(1200)")]
        [StringLength(1200)]
        public string? ImageUrl { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
