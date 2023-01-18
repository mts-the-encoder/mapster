namespace MapsterDotNet.Entities
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string CNPJ { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public DateTime CreatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn = DateTime.UtcNow;

        public bool Active = true;
    }
}