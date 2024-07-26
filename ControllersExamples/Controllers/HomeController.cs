using ControllersExamples.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExamples.Controllers
{
    public class HomeController : Controller
    {
        [Route("SayIndex")]
        public IActionResult Index()
        {
            return View();
        }

        
        public ContentResult GetAll()
        {
            return Content("<h1>Welcome</h1> <h2> Hello from the other side</h2>", "text/html");
        }
        [Route("Person")]
        public JsonResult GetPersonData()
        {
            Response.StatusCode = 200;
            Person person = new Person() { Id = Guid.NewGuid(),
                FirstName = "Assem", LastName = "Aly" };
            return Json(person);
        }
        [Route("Books")]
        public IActionResult GetBookData()
        {           
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
                return BadRequest("Book id is not supplied");
            }
            var id = Request.Query["bookid"];
            if (string.IsNullOrEmpty(id.ToString()))
            {
                //Response.StatusCode = 400;
                //return Content("Book id cant be null or empty");
                return BadRequest("Book id cant be null or empty");
            }

            if (Convert.ToInt16(id) < 0)
            {                
                return NotFound("Book id cant be less than 0");
            }
            if (Convert.ToInt16(id) > 1000)
            {                
                return NotFound("Book id cant be greater than 1000");
            }

            return File("/pass.txt", "application/txt");
        }

    }
}
