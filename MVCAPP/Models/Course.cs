public class Course
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
}