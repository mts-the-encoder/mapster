namespace MapsterDotNet.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? Zip { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }

        public DateTime CreatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn = DateTime.UtcNow;

        public bool Active = true;
    }
}
