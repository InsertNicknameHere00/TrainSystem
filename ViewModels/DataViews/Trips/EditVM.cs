using System.ComponentModel.DataAnnotations;
using TrainSystem.Entities;

namespace TrainSystem.ViewModels.DataViews.Trips
{
    public class EditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int TrainId { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public int StartPoint { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public int EndPoint { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public DateTime DepartureTime { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public DateTime ArrivalTime { get; set; }
    }
}
