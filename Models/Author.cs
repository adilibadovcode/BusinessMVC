using System.ComponentModel.DataAnnotations;

namespace BusinessMVC.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required,MaxLength(32)]
        public string Name { get; set; }
        public List<Card>? Cards { get; set; }
    }
}
