namespace DecisionEngineWebPrototype.Models
{
    public class Activity
    {
        public string Name { get; set; }

        public string Condition { get; set; }

        public Rule[] ApproveRules { get; set; }

        public Rule[] RejectRules { get; set; }

        public Rule[] SuspendRules { get; set; }
    }
}