using System.ComponentModel.DataAnnotations;

namespace NotesWeb.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
     
        public Guid PostID { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
