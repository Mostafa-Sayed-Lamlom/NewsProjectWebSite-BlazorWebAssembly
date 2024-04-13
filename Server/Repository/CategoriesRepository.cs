//using BlazorApp1.Server.Models;
//using BlazorApp1.Server.Repository.Interfaces;
//using BlazorApp1.Shared.Models;

//namespace BlazorApp1.Server.Repository
//{
//    public class CategoriesRepository : IMainInterface<Category>
//    {
//        private readonly AppDbContext _db;
//        public CategoriesRepository(AppDbContext db)
//        {
//            _db = db;
//        }

//        public Category Add(Category category)
//        {
//            _db.Categories.Add(category);
//            _db.SaveChanges();
//            return category;
//        }

//        public void DeleteById(int id)
//        {
//            var Category = GetById(id);
//            _db.Categories.Remove(Category);
//            _db.SaveChanges();
//        }

//        public IEnumerable<Category> GetAll()
//        {
//            return _db.Categories;
//        }

//        public Category GetById(int id)
//        {
//            var Category = _db.Categories.FirstOrDefault(c => c.Id == id);
//            return Category;
//        }

//        public Category UpdateById(int id, Category category)
//        {
//            var Category = GetById(id);
//            Category.CategoryName = category.CategoryName;
//            _db.SaveChanges();
//            return Category;
//        }
//    }
//}
