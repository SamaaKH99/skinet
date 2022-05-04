using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        // The task is to get the product by id
        Task<Product> GetProductByIdAsync(int id);
        // The type of the returned list is a list of products
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}