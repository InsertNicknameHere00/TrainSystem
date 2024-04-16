using System.ComponentModel.DataAnnotations;

namespace TrainSystem.ViewModels.DataViews.Stations
{
    public class EditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Location { get; set; }
    }
}
