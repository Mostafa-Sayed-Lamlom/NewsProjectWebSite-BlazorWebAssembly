using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repository;
using BlazorApp1.Server.Repository.Interfaces;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMainInterface<Category> _categories;
        public CategoriesController(IMainInterface<Category> categories)
        {
            _categories = categories;
        }
        // GET: api/<CategoriesController/ActionName>
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categories.GetAll());
        }

        // GET api/<CategoriesController>/ActionName/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var Category = _categories.GetById(id);
            return Ok(Category);
        }

        // POST api/<CategoriesController/ActionName>
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category Model)
        {
            if(ModelState.IsValid)
            {
                var catName = _categories.GetAll().Where(c => c.CategoryName == Model.CategoryName).FirstOrDefault(); 
                if(catName != null)
                {
                    ModelState.AddModelError("Error", "Category name is already exists");
                    //return BadRequest(ModelState);
                    return BadRequest(ModelState.First().Value.Errors.First().ErrorMessage);
                }
                _categories.Add(Model);
                return Ok(Model);
            }
            return BadRequest(ModelState);
        }

		// PUT api/<CategoriesController>/ActionName/5
		public IActionResult UpdateCategory([FromBody] Category Model)
        {
            return Ok(_categories.UpdateById(Model));
        }

        // DELETE api/<CategoriesController>/ActionName/5
        [HttpDelete("{id}")]
        public  void DeleteCategory(int id)
        {
            _categories.DeleteById(id);
        }
    }
}
