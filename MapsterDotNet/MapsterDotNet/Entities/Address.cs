namespace MapsterDotNet.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Active { get; set; }
    }
}
