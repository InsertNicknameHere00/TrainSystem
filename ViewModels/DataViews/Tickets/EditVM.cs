using System.ComponentModel.DataAnnotations;
using TrainSystem.Entities;

namespace TrainSystem.ViewModels.DataViews.Tickets
{
    public class EditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int RouteId { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public int UserId { get; set; }
    }
}
