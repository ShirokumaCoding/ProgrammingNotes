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
            if(ModelState.IsValid)
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
            return View(obj);
        }

        // GET
        public IActionResult Edit(Guid id)
        {
            if(id== Guid.Empty || Guid.Equals == null)
            {
                return NotFound();
            }
            var postFromDb = _context.posts.Find(id);
            if(postFromDb==null)
            {
                return NotFound();
            }
            return View(postFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post obj)
        {
            if (ModelState.IsValid)
            {
                _context.posts.Update(obj);
                _context.SaveChanges();
                History historyObj = new History();
                historyObj.PostID = obj.Id;
                historyObj.UpdatedDate = DateTime.Now;
                _context.Add(historyObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty || Guid.Equals == null)
            {
                return NotFound();
            }
            var postFromDb = _context.posts.Find(id);
            if (postFromDb == null)
            {
                return NotFound();
            }
            return View(postFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid id)
        {
            var postFromDb = _context.posts.Find(id);
            if(postFromDb == null)
            {
                return NotFound();
            }
            History historyObj = new History();
            historyObj.PostID = postFromDb.Id;
            historyObj.UpdatedDate = DateTime.Now;
            _context.Add(historyObj);
            _context.SaveChanges();
            _context.posts.Remove(postFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
