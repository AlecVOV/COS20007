using System;
using System.Collections.Generic;
using static Student_Management_System.DataModel;

namespace Student_Management_System
{
    public class Program
    {
        private static List<Student> students = new();
        private static List<Course> courses = new();
        private static List<Enrollment> enrollments = new();

        private static void Main()
        {
            // Load existing data
            var data = FileManager.LoadData();
            students = data.Item1;
            courses = data.Item2;
            enrollments = data.Item3;

            char choice;
            do
            {
                int Equal = 15;
                Console.Clear();
                Console.WriteLine("Student Management System");
                Console.WriteLine("\n" + new string('=', Equal) + "MAIN MENU" + new string('=', Equal) + "\n");

                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Assign course to student");
                Console.WriteLine("7. Insert Marks and Calculate GPA");
                Console.WriteLine("8. View courses");
                Console.WriteLine("9. View departments");
                Console.WriteLine("0. Exit");
                Console.WriteLine(new string('=', Equal * 3));
                Console.Write("Enter your choice: ");
                choice = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (choice)
                {
                    case '1':
                        CreateStudent();
                        break;
                    case '2':
                        ShowStudents();
                        break;
                    case '3':
                        SearchStudent();
                        break;
                    case '4':
                        UpdateStudent();
                        break;
                    case '5':
                        DeleteStudent();
                        break;
                    case '6':
                        AddCourseToStudent();
                        break;
                    case '7':
                        InsertMarksAndCalculateGPA();
                        break;
                    case '8':
                        ShowAvailableCoursesAndInsertNewCourses();
                        break;
                    case '9':
                        ShowAvailableDepartmentsAndInsertNewDepartments();
                        break;
                    case '0':
                        Console.WriteLine("Exiting. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != '0');

            // Save data before exiting
            FileManager.SaveData(students, courses, enrollments);
        }

        private static void CreateStudent()
        {
            try
            {
                Console.WriteLine("\nCreating a new student...");
                Console.Write("Enter ID: ");
                if (!int.TryParse(Console.ReadLine(), out int studentID))
                {
                    Console.WriteLine("Invalid ID format. Please enter a numeric value.");
                    return;
                }
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
                string dateOfBirth = Console.ReadLine();
                Console.Write("Enter Department ID: ");
                int departmentID = int.Parse(Console.ReadLine());

                Student student = new()
                {
                    StudentID = studentID,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = DateTime.Parse(dateOfBirth),
                    DepartmentID = departmentID
                };

                students.Add(student);
                FileManager.SaveData(students, courses, enrollments);

                Console.WriteLine("Student created successfully.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void ShowStudents()
        {
            Console.WriteLine("\nReading students...");
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.StudentID}");
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Date of Birth: {student.DateOfBirth:dd-MM-yyyy}");
                Console.WriteLine($"Department ID: {student.DepartmentID}");
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void UpdateStudent()
        {
            Console.WriteLine("\nUpdating a student...");
            Console.Write("Enter Student ID to update: ");
            int studentID = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.StudentID == studentID);
            if (student != null)
            {
                Console.Write("Enter new First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter new Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter new Date of Birth (yyyy-MM-dd): ");
                string dateOfBirth = Console.ReadLine();
                Console.Write("Enter new Department ID: ");
                int departmentID = int.Parse(Console.ReadLine());

                student.FirstName = firstName;
                student.LastName = lastName;
                student.DateOfBirth = DateTime.Parse(dateOfBirth);
                student.DepartmentID = departmentID;

                FileManager.SaveData(students, courses, enrollments);
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("No student found with the provided ID.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("\nDeleting a student...");
            Console.Write("Enter Student ID to delete: ");
            int studentID = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.StudentID == studentID);
            if (student != null)
            {
                students.Remove(student);
                FileManager.SaveData(students, courses, enrollments);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("No student found with the provided ID.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void AddCourseToStudent()
        {
            Console.WriteLine("\nAdding a course to a student...");
            Console.Write("Enter Student ID: ");
            int studentID = int.Parse(Console.ReadLine());

            Console.WriteLine("Available Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseID}: {course.CourseName}");
            }

            Console.Write("Enter Course ID to add to the student: ");
            int selectedCourseID = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.StudentID == studentID);
            var selectedCourse = courses.Find(c => c.CourseID == selectedCourseID);

            if (student != null && selectedCourse != null)
            {
                Enrollment enrollment = new()
                {
                    StudentID = studentID,
                    CourseID = selectedCourseID
                };

                enrollments.Add(enrollment);
                FileManager.SaveData(students, courses, enrollments);
                Console.WriteLine("Course added to the student successfully.");
            }
            else
            {
                Console.WriteLine("Student or course not found. Please check the IDs.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void InsertMarksAndCalculateGPA()
        {
            Console.WriteLine("\nInserting Marks and Calculating GPA...");
            Console.Write("Enter Student ID: ");
            int studentID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Marks: ");
            decimal marks = decimal.Parse(Console.ReadLine());

            var enrollment = enrollments.Find(e => e.StudentID == studentID && e.CourseID == courseID);
            if (enrollment != null)
            {
                enrollment.Grade = marks;
                CalculateAndSetGPA(enrollment);
                FileManager.SaveData(students, courses, enrollments);
                Console.WriteLine("Marks inserted and GPA calculated successfully.");
            }
            else
            {
                Console.WriteLine("No enrollment found for the given student and course.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void CalculateAndSetGPA(Enrollment enrollment)
        {
            // Example GPA calculation logic based on the grade (marks).
            // This can be adjusted based on actual GPA calculation rules.
            enrollment.Grade = enrollment.Grade / 20; // Simple example: assuming 100 marks = 5 GPA.
        }

        private static void ShowAvailableCoursesAndInsertNewCourses()
        {
            Console.WriteLine("\nViewing Available Courses...");
            foreach (var course in courses)
            {
                Console.WriteLine($"Course ID: {course.CourseID}");
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine($"Department ID: {course.DepartmentID}");
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Insert new course:");
            Console.Write("Enter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();
            Console.Write("Enter Department ID: ");
            int departmentID = int.Parse(Console.ReadLine());

            Course newCourse = new()
            {
                CourseID = courseID,
                CourseName = courseName,
                DepartmentID = departmentID
            };

            courses.Add(newCourse);
            FileManager.SaveData(students, courses, enrollments);
            Console.WriteLine("New course added successfully.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ShowAvailableDepartmentsAndInsertNewDepartments()
        {
            Console.WriteLine("\nViewing Available Departments...");
            var departments = new HashSet<int>();
            foreach (var student in students)
            {
                departments.Add(student.DepartmentID);
            }

            foreach (var course in courses)
            {
                departments.Add(course.DepartmentID);
            }

            foreach (var departmentID in departments)
            {
                Console.WriteLine($"Department ID: {departmentID}");
            }

            Console.WriteLine("Insert new department:");
            Console.Write("Enter Department ID: ");
            int newDepartmentID = int.Parse(Console.ReadLine());

            if (!departments.Contains(newDepartmentID))
            {
                // Since departments are not stored separately, adding a dummy student to create a department
                Student dummyStudent = new()
                {
                    StudentID = -1,
                    FirstName = "Dummy",
                    LastName = "Student",
                    DateOfBirth = DateTime.Now,
                    DepartmentID = newDepartmentID
                };

                students.Add(dummyStudent);
                FileManager.SaveData(students, courses, enrollments);
                Console.WriteLine("New department added successfully.");
            }
            else
            {
                Console.WriteLine("Department already exists.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void SearchStudent()
        {
            Console.WriteLine("\nSearching for a student...");
            Console.Write("Enter Student ID to search: ");
            int studentID = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.StudentID == studentID);
            if (student != null)
            {
                Console.WriteLine($"Student ID: {student.StudentID}");
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Date of Birth: {student.DateOfBirth:dd-MM-yyyy}");
                Console.WriteLine($"Department ID: {student.DepartmentID}");
            }
            else
            {
                Console.WriteLine("No student found with the provided ID.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

}
