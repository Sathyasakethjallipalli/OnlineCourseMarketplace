using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    private readonly OnlineCourseDbContext _context;

    public AdminController(OnlineCourseDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        // Admin page: list all courses
        return View(_context.Courses.ToList());
    }

    [HttpGet]
    public IActionResult CreateCourse() => View();

    [HttpPost]
    public IActionResult CreateCourse(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(course);
    }
}