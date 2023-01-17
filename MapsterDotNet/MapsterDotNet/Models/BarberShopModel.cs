using Mapster;
using MapsterDotNet.Entities;

namespace MapsterDotNet.Models
{
    public class BarberShopModel : BaseModel<BarberShopModel, BarberShop>
    {
        public string Company { get; set; }
        public string CNPJ { get; set; }
        public Address Address { get; set; }

        public DateTime CreatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn = DateTime.UtcNow;

        public bool Active = true;
    }
}
