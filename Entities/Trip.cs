using System.ComponentModel.DataAnnotations.Schema;

namespace TrainSystem.Entities
{
    public class Trip : BaseEntity
    {
        
        public int TrainId { get; set; }
        [ForeignKey(nameof(TrainId))]
        public Train Train { get; set; }
        public int StartPoint { get; set; }
        [ForeignKey(nameof(StartPoint))]
        public Station StartStation { get; set; }
        public int EndPoint { get; set; }
        [ForeignKey(nameof(EndPoint))]
        public Station EndStation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}
