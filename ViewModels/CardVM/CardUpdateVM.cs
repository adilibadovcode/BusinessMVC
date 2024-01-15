using BusinessMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessMVC.ViewModels.CardVM
{
    public class CardUpdateVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required, MaxLength(32)]
        public string Title { get; set; }
        [Required, MaxLength(64)]
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
