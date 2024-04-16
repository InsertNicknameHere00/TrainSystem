using System.ComponentModel.DataAnnotations;

namespace TrainSystem.ViewModels.Home
{
    public class LoginVM
    {
        public string Url { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }

    }
}
