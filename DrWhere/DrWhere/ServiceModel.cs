namespace DrWhere {
    // Information retrieved from database
    public class ServiceModel {
        public string Postcode { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Private { get; set; }

        // Extra information
        public string Distance { get; set; }
    }
}