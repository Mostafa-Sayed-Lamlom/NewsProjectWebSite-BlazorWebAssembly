using BlazorApp1.Server.Repository.Interfaces;
using BlazorApp1.Shared.Dtos;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsListController : ControllerBase
    {
        private readonly IMainInterface<NewsList> _newsList;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsListController(IMainInterface<NewsList> newsList, IWebHostEnvironment webHostEnvironment)
        {
            _newsList = newsList;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<NewsListController>
        [HttpGet]
        public IActionResult GetAllNews()
        {
            return Ok(_newsList.GetAll("category").OrderByDescending(c => c.NewDate));
        }

        // GET api/<NewsListController>/5
        [HttpGet("{id}")]
        public IActionResult GetNew(int id)
        {
            return Ok(_newsList.GetAll("category").Where(c => c.Id == id).FirstOrDefault());
        }
        // GET: api/<NewsListController>
        public IActionResult GetAllNewsByCategoryId(int id)
        {
            return Ok(_newsList.GetAll("category").Where(c => c.categoryId == id));
        }
        // GET: api/<NewsListController>
        public IActionResult GetAllNewsByTitle(string title)
        {
            return Ok(_newsList.GetAll("category").Where(c => c.Title.Contains(title)));
        }
        // GET: api/<NewsListController>
        public IActionResult GetAllNewsByCategoryName(string catName)
        {
            return Ok(_newsList.GetAll("category").Where(c => c.category.CategoryName.Contains(catName)));
        }

        // POST api/<NewsListController>
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] NewsListDto ModelDTo)
        {
            string fileName = "";
            if(ModelDTo.NewImg != null)
            {
                string FullPath = Path.Combine(_webHostEnvironment.WebRootPath, "NewsImges");
                if (!Directory.Exists(FullPath))
                {
                    Directory.CreateDirectory(FullPath);
                }
                //fileName = Guid.NewGuid() + "_" + ModelDTo.NewImg.FileName;
                fileName = Guid.NewGuid() + "_" + ModelDTo.ImgPath;
                string ImagPath = Path.Combine(FullPath, fileName);
                //new => from body
                await using var stream = new FileStream(ImagPath, FileMode.Create);
                stream.Write(ModelDTo.NewImg, 0, ModelDTo.NewImg.Length);
                //old from form
                //using(var stream = new FileStream(ImagPath, FileMode.Create))
                //{
                //    await ModelDTo.NewImg.CopyToAsync(stream);
                //    stream.Dispose();
                //}
            }
            NewsList Model = new NewsList()
            {
                ShortDetails = ModelDTo.ShortDetails,
                Title = ModelDTo.Title,
                SubTiltle = ModelDTo.SubTiltle,
                Details = ModelDTo.Details,
                categoryId = ModelDTo.categoryId,
                ImgPath = fileName
            };
            _newsList.Add(Model);
            return Ok(Model);
        }

        // PUT api/<NewsListController>/5
        public IActionResult UpdateNew([FromBody] NewsList Model)
        {
            return Ok(_newsList.UpdateById(Model));
        }

        // DELETE api/<NewsListController>/5
        [HttpDelete("{id}")]
        public void DeleteNew(int id)
        {
            _newsList.DeleteById(id);
        }
    }
}
