using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainSystem.Entities;

namespace TrainSystem.ViewModels.DataViews.Trips
{
    public class CreateVM
    {
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
