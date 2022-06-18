using System.ComponentModel.DataAnnotations;

namespace IdentityUI.ViewModels
{
    public class LoginVm
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? returnUrl { get; set; }
    }
}
