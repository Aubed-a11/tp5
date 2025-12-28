using System.ComponentModel.DataAnnotations;
namespace TP07.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [MaxLength(100, ErrorMessage = "Le titre ne doit pas dépasser 100 caractères.")]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
 