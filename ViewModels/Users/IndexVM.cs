using System.ComponentModel;
using TrainSystem.Entities;

namespace TrainSystem.ViewModels.Users
{
    public class IndexVM
    {
        public List<User> Items { get; set; }

        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [DisplayName("Last Name")]
        public string Lastname { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
