using Mapster;
using MapsterDotNet.Entities;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MapsterDotNet.Models
{
    public class BarberShopModel : BaseModel<BarberShopModel, BarberShop>
    {
        public string Company { get; set; }
        public string CNPJ { get; set; }
        public Address? Address { get; set; }
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
            string title = "";
            title = textInfo.ToTitleCase(titleCase);
            titleCase = title;
            return titleCase;
        }
    }
}

