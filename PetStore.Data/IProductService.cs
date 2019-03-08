using PetStore.Core.Models;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductService
    {
        Task<ProductDetail> GetProductDetailAsync(string productId);
    }
}
