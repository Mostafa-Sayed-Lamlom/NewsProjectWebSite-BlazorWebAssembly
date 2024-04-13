//using BlazorApp1.Server.Models;
//using BlazorApp1.Server.Repository.Interfaces;
//using BlazorApp1.Shared.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BlazorApp1.Server.Repository
//{
//    public class NewsListRepository : IMainInterface<NewsList>
//    {
//        private readonly AppDbContext _db;
//        public NewsListRepository(AppDbContext db)
//        {
//            _db = db;
//        }
//        public NewsList Add(NewsList item)
//        {
//            _db.NewsLists.Add(item);
//            _db.SaveChanges();
//            return item;
//        }

//        public void DeleteById(int id)
//        {
//            var New = GetById(id);
//            _db.NewsLists.Remove(New);
//            _db.SaveChanges();
//        }

//        public IEnumerable<NewsList> GetAll()
//        {
//            return _db.NewsLists.Include(c => c.category);
//        }

//        public NewsList GetById(int id)
//        {
//            var New = _db.NewsLists.Include(c=> c.category).FirstOrDefault(c => c.Id == id);
//            return New;
//        }

//        public NewsList UpdateById(int id, NewsList item)
//        {
//            var New = GetById(id);
//            New.Title = item.Title;
//            New.SubTiltle = item.SubTiltle;
//            New.ShortDetails = item.ShortDetails;
//            New.Details = item.Details;
//            New.ImgPath = item.ImgPath;
//            New.categoryId = item.categoryId;
//            _db.SaveChanges();
//            return New;
//        }
//    }
//}
