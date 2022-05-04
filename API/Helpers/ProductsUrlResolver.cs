using AutoMapper;
using Core.Entities;
using API.DTOS;
using Microsoft.Extensions.Configuration;
namespace API.Helpers
{
    public class ProductsUrlResolver : IValueResolver<Product, ProductToRetunDto, string>
    {
        private readonly IConfiguration _config;
        public ProductsUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToRetunDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureURL))
            {
                return _config["ApiUrl"] + source.PictureURL;
            }

            return null;
        }
    }
}