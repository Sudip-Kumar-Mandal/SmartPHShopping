using SmartPHShoppingWeb.Data;
using SmartPHShoppingWeb.Models;
using SmartPHShoppingWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace SmartPHShoppingWeb.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
