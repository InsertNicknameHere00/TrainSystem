namespace TrainSystem.Entities
{
    public class Train : BaseEntity
    {
       public int TrainNum { get; set; }
        public string TrainType { get; set;}
        public int Capacity { get; set;}
    }
}
