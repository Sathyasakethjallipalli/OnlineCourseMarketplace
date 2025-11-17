using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AccountController : Controller
{
    private readonly OnlineCourseDbContext _context;

    public AccountController(OnlineCourseDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register() => View();
    
    [HttpPost]
    public IActionResult Register(User user)
    {
        if(ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        return View(user);
    }

    [HttpGet]
    public IActionResult Login() => View();
    
    [HttpPost]
    public IActionResult Login(User user)
    {
        var found = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (found != null)
        {
            // For demo: store login info in session
            HttpContext.Session.SetInt32("UserId", found.UserId);
            HttpContext.Session.SetString("Username", found.Username);
            HttpContext.Session.SetInt32("IsAdmin", found.IsAdmin ? 1 : 0);
            return RedirectToAction("Index", "Courses");
        }
        ViewBag.Error = "Invalid credentials";
        return View(user);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}