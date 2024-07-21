using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using static Student_Management_System.DataModel;

namespace Student_Management_System
{
    public class FileManager
    {
        private static readonly string StudentsFilePath = "students.csv";
        private static readonly string CoursesFilePath = "courses.csv";
        private static readonly string EnrollmentsFilePath = "enrollments.csv";

        public static void SaveData(List<Student> students, List<Course> courses, List<Enrollment> enrollments)
        {
            SaveStudents(students);
            SaveCourses(courses);
            SaveEnrollments(enrollments);
        }

        public static (List<Student>, List<Course>, List<Enrollment>) LoadData()
        {
            var students = LoadStudents();
            var courses = LoadCourses();
            var enrollments = LoadEnrollments();

            return (students, courses, enrollments);
        }

        private static void SaveStudents(List<Student> students)
        {
            using var writer = new StreamWriter(StudentsFilePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(students);
        }

        private static List<Student> LoadStudents()
        {
            if (!File.Exists(StudentsFilePath)) return new List<Student>();

            using var reader = new StreamReader(StudentsFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<Student>(csv.GetRecords<Student>());
        }

        private static void SaveCourses(List<Course> courses)
        {
            using var writer = new StreamWriter(CoursesFilePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(courses);
        }

        private static List<Course> LoadCourses()
        {
            if (!File.Exists(CoursesFilePath)) return new List<Course>();

            using var reader = new StreamReader(CoursesFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<Course>(csv.GetRecords<Course>());
        }

        private static void SaveEnrollments(List<Enrollment> enrollments)
        {
            using var writer = new StreamWriter(EnrollmentsFilePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(enrollments);
        }

        private static List<Enrollment> LoadEnrollments()
        {
            if (!File.Exists(EnrollmentsFilePath)) return new List<Enrollment>();

            using var reader = new StreamReader(EnrollmentsFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new List<Enrollment>(csv.GetRecords<Enrollment>());
        }
    }
}
