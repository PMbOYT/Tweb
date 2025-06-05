using System.ComponentModel.DataAnnotations;

namespace BudgetBliss.Web.Models
{
    public class LoginViewModels
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
