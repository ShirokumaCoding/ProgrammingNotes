using Microsoft.AspNetCore.Mvc;
using NotesWeb.Data;
using NotesWeb.Models;

namespace NotesWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Post> objBlogList = _context.posts.OrderByDescending(m => m.CreatedDate);
            return View(objBlogList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post obj)
        {
            _context.posts.Add(obj);
            _context.SaveChanges();
            History historyObj = new History();
            historyObj.PostID = obj.Id;
            historyObj.UpdatedDate = DateTime.Now;
            _context.Add(historyObj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
