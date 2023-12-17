public class SectionViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Order is required")]
    public int Order { get; set; }

    [Required(ErrorMessage = "Course is required")]
    public string CourseId { get; set; }

    public List<Course> Courses { get; set; }
}
