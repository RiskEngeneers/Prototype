namespace DecisionEngineWebPrototype.Models
{
    public class ActivityGroup
    {
        public string Name { get; set; }

        public string Condtition { get; set; }

        public Activity[] Activities { get; set; }

        public ActivityGroup[] Groups { get; set; }
    }
}