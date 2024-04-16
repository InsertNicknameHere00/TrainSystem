using System.ComponentModel.DataAnnotations;

namespace TrainSystem.ViewModels.DataViews.Trains
{
    public class CreateVM
    {
        [Required(ErrorMessage = "This field is Required!")]
        public int TrainNum { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public string TrainType { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public int Capacity { get; set; }
    }
}
