using System.ComponentModel.DataAnnotations;

namespace TrainSystem.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
