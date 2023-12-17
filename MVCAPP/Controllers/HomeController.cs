using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCAPP.Models;

namespace MVCAPP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
private readonly appdbcontext _dbContext;
    public HomeController(ILogger<HomeController> logger,appdbcontext dbContext)
    {
        _logger = logger;
        _dbContext=dbContext;
    }
//List course 
    public IActionResult Index()
    {
           // Retrieve data from Entity Framework
        var sectionsFromDb = _dbContext.Sections.Include(s => s.Course).ToList();

        // Map data from Entity Framework to ViewModel
        var sectionViewModels = sectionsFromDb.Select(s => new SectionViewModel
        {
            Name = s.Name,
            Order = s.Order,
            CourseId = s.CourseId,
            CourseName = s.Course.Name // Map CourseName property
        }).ToList();

        return View(sectionViewModels);
    }

  public IActionResult Add()
    {
         Viewbag.Courses = GetCourses(); // Populate courses again for the dropdown
        return View();
    }
[HttpPost]
    public IActionResult SubmitForm(SectionViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // Map ViewModel to Data Model
            var section = new Section
            {
                Name = viewModel.Name,
                Order = viewModel.Order,
                CourseId = viewModel.CourseId
            };

            // Save using Entity Framework Core
            _dbContext.Sections.Add(section);
            _dbContext.SaveChanges();

            return RedirectToAction("Index"); // Redirect to another action or page
        }

        // If validation fails, return to the form with errors
        Viewbag.Courses = GetCourses(); // Populate courses again for the dropdown
        return View("FormSubmission", viewModel);
    }
  public List<Course> GetCourses()
{
    // Assuming YourDbContext is the Entity Framework DbContext class
    var courses = _dbContext.Courses.ToList();

    return courses;
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
