using SmartPHShoppingWeb.Models;

namespace SmartPHShoppingWeb.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
