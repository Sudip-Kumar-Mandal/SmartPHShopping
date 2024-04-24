using SmartPHShoppingWeb.Models;

namespace SmartPHShoppingWeb.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
