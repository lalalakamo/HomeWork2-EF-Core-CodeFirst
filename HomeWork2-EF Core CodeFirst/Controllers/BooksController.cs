using HomeWork2_EF_Core_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork2_EF_Core_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly WebContext _webContext;

        public BooksController(WebContext webContext)
        {
            _webContext = webContext;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            var search = _webContext.Book.OrderByDescending(a => a.Price).ToList();
            return Ok(search);
        }

        // GET api/<BooksController>/5
        [HttpGet("expensive")]
        public IActionResult GetExpensive()
        {
            var search = _webContext.Book.Where(a => a.Price > 500).OrderByDescending(a => a.Price).ToList();
            return Ok(search);
        }

        // GET api/<BooksController>/5
        [HttpGet("search")]
        public IActionResult GetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("請輸入收尋名稱");
            }
            var search = _webContext.Book.Where(a => a.Title.Contains(name)).OrderByDescending(a => a.Price).ToList();
            return Ok(search);
        }

        // GET api/<BooksController>/5
        [HttpGet("{price}")]
        public IActionResult Get(int price)
        {
            var search = _webContext.Book.Where(a => a.Price > price).OrderByDescending(a => a.Price).ToList();
            return Ok(search);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
