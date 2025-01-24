using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoAPI.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tittel er påkrevd")]
        [MaxLength(255)]
        public required string Title { get; set; }

        public required string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        public bool Completed { get; set; }
    }
}