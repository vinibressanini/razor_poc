﻿namespace RazorApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email{ get; set; } = "";
        public ICollection<Course> Courses { get; set; } = [];
    }
}
