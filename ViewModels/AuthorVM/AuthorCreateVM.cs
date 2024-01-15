using System.ComponentModel.DataAnnotations;

namespace BusinessMVC.ViewModels.AuthorVM
{
    public class AuthorCreateVM
    {
        [Required,MaxLength(32)]
        public string Name { get; set; }
    }
}
