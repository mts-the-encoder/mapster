using MapsterDotNet.Entities;

namespace MapsterDotNet.Models
{
    public class AddressModel : BaseModel<AddressModel, Address>
    {
        public string Zip { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}
