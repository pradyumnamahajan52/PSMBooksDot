using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMBooksDot.API.Models
{
    [Table("books_category")]
    public class BooksCategory
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment in Database
        public int Id { get; set; }

        [Column("type", TypeName = "varchar(250)")]
        [StringLength(250)]
        public string Type { get; set; } = "Other";

        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default value

        [Column("updated_at", TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }
    }
}
