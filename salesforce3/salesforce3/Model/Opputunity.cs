namespace salesforce3.Model
{
    public class Opputunity
    {
        public string Name { get; set; }
        public string StageName { get; set; }

        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
