﻿namespace lab2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerId { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Trainee>? Trainees { get; set; }
    }
}
