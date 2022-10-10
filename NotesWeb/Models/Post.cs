using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotesWeb.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Title")]
        public string PostTitle { get; set; }

        [Display (Name = "Post")]
        public string PostBody { get; set; }

        public DateTime CreatedDate { get; init; } = DateTime.Now;

    }
}
