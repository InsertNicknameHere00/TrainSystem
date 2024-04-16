using System.ComponentModel.DataAnnotations.Schema;

namespace TrainSystem.Entities
{
    public class News: BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int StationId { get; set; }
        [ForeignKey(nameof(StationId))]
        public Station Station { get; set; }
    }
}
