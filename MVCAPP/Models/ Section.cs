public class Section
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public int Order { get; set; }
    public string CourseId { get; set; }
    public Course Course { get; set; }
}