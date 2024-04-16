using System.ComponentModel.DataAnnotations.Schema;

namespace TrainSystem.Entities
{
    public class Ticket: BaseEntity
    {
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Trip Trip { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
