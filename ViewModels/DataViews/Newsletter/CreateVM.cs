using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainSystem.Entities;

namespace TrainSystem.ViewModels.DataViews.Newsletter
{
    public class CreateVM
    {
        [Required(ErrorMessage = "This field is Required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public string Text { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public string Author { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public int StationId { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public DateTime CreationDate { get; set; }
    }
}
