using Mapster;
using MapsterDotNet.Entities;
using System.Globalization;

namespace MapsterDotNet.Models
{
    public class BarberShopModel : BaseModel<BarberShopModel, BarberShop>
    {
        public string Company { get; set; }
        public string CNPJ { get; set; }
        public Address? Address { get; set; }

        public DateTime CreatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn = DateTime.UtcNow;

        public bool Active = true;
    }

    public class BarberShopResultModel : IRegister
    {
        public string Company { get; set; }
        public string CNPJ { get; set; }
        public Address? Address { get; set; }
        
        private static string cnpj = "********";

        public static TypeAdapterConfig GetMapsterConfig()
        {
            return new TypeAdapterConfig()
                .NewConfig<BarberShop,BarberShopResultModel>()
                .Map(dest => dest.Company,src => ConvertToTitleCase(src.Company))
                .Map(dest => dest.CNPJ, src => $"{cnpj}{src.CNPJ.Remove(0,8)}")
                .Config;
        }

        public void Register(TypeAdapterConfig config)
        {
            config.ForType<BarberShop,BarberShopResultModel>()
                .Map(dest => dest.Company,src => ConvertToTitleCase(src.Company))
                .Map(dest => dest.CNPJ,src => $"{cnpj}{src.CNPJ.Remove(0,8)}");
        }

        private static string ConvertToTitleCase(string titleCase)
        {
            var textInfo = new CultureInfo("en-US",false).TextInfo;
            var title = textInfo.ToTitleCase(titleCase);
            titleCase = title;
            return titleCase;
        }
    }
}

