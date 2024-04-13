using BlazorApp1.Server.Repository.Interfaces;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]/[action]")] 
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMainInterface<Comment> _comment;
        public CommentsController(IMainInterface<Comment> comment)
        {
            _comment = comment;
        }
        // GET: api/<CommentsController>
        [HttpGet("{id}")]
        public IActionResult GetAllComments(string id)
        {
            return Ok(_comment.GetAll("newsList").Where(c => c.newsListId == int.Parse(id)));
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _comment.GetAll("newsList").Where(c => c.Id == id);
            return Ok(comment);
        }

        // POST api/<CommentsController>
        [HttpPost]
        public IActionResult AddComment([FromBody] Comment Model)
        {
            _comment.Add(Model);
            return Ok(Model);
        }

        // PUT api/<CommentsController>
        public IActionResult UpdateComment([FromBody] Comment Model)
        {
            return Ok(_comment.UpdateById(Model));
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            _comment.DeleteById(id);
        }
    }
}
