using BusinessMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessMVC.ViewModels.AuthorVM
{
    public class AuthorListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card>? Cards { get; set; }
    }
}
