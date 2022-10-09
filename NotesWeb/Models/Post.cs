using System.ComponentModel.DataAnnotations;

namespace NotesWeb.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PostTitle { get; set; }

        public string PostBody { get; set; }

        public DateTime CreatedDate { get; init; } = DateTime.Now;

    }
}
