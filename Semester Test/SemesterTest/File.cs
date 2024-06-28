using System;
namespace SemesterTest
{
    public class File
    {
        private string _name;
        private string _extension;
        private int _size;

        // Constructor
        public File(string name, string extension, int size)
        {
            _name = name;
            _extension = extension;
            _size = size;
        }

        // Method to get the size of the file
        public int Size()
        {
            return _size;
        }

            // Method to print file details
        public void Print()
        {
            Console.WriteLine($"File '{_name}.{_extension}' -- {_size} bytes");
        }

        // Read-only property for the file name
        public string Name
        {
            get { return _name; }
        }
    }
}