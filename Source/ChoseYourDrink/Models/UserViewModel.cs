using System.ComponentModel.DataAnnotations;

namespace ChoseYourDrink.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        [Range(18, 120,ErrorMessage ="Age must be greater than 18.")]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}({Age})";
        }
    }
}
