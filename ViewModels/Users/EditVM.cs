using System.ComponentModel.DataAnnotations;

namespace TrainSystem.ViewModels.Users
{
    public class EditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Email { get; set; }
    }
}
