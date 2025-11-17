using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class CoursesController : Controller
{
    private readonly OnlineCourseDbContext _context;
    public CoursesController(OnlineCourseDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var courses = _context.Courses.ToList();
        return View(courses);
    }

    [HttpPost]
    public IActionResult Enroll(int courseId)
    {
        if (HttpContext.Session.GetInt32("UserId") is int userId)
        {
            _context.Enrollments.Add(new Enrollment
            {
                UserId = userId,
                CourseId = courseId,
                EnrolledOn = DateTime.Now
            });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Login", "Account");
    }
}