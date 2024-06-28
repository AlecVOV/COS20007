using System;
using System.Collections.Generic;

namespace SemesterTest 
{
    public class Folder
    {
        private List<File> _contents;
        private List<Folder> _subFolders;
        private string _name;

        // Constructor
        public Folder(string name)
        {
            _name = name;
            _contents = new List<File>();
            _subFolders = new List<Folder>(); // Initialize the subfolders list
        }

        // Method to add a file
        public void Add(File toAdd)
        {
            _contents.Add(toAdd);
        }

        public void Add(Folder toAdd)
        {
            _subFolders.Add(toAdd);
        }

        // Method to calculate the size of the folder
        public int Size()
        {
            int totalSize = 0;
            foreach (var file in _contents)
            {
                totalSize += file.Size();
            }
            foreach (var folder in _subFolders) // Include sizes of subfolders
            {
                totalSize += folder.Size();
            }
            return totalSize;
        }


        public void Print()
        {
            if (_contents.Count == 0 && _subFolders.Count == 0)
            {
                Console.WriteLine($"The folder '{_name}' is empty!");
            }
            else
            {
                Console.WriteLine($"The folder '{_name}' contains {Size()} bytes total:");
                foreach (var file in _contents)
                {
                    file.Print();
                }
                foreach (var folder in _subFolders) // Print subfolders
                {
                    folder.Print();
                }
            }
        }

        // Read-only property for the folder name
        public string Name
        {
            get { return _name; }
        }
    }
}