namespace Student_Management_System
{
    public class DataModel
    {
        public class Student
        {
            public int StudentID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int DepartmentID { get; set; }
        }

        public class Course
        {
            public int CourseID { get; set; }
            public string CourseName { get; set; }
            public int DepartmentID { get; set; }
        }

        public class Enrollment
        {
            public int StudentID { get; set; }
            public int CourseID { get; set; }
            public decimal Grade { get; set; }
        }
    }
}
