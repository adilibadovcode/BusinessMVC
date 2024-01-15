using BusinessMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessMVC.ViewModels.CardVM
{
    public class CardListItemVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
