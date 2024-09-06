namespace RazorApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Person> Students { get; set; } = [];
    }
}
