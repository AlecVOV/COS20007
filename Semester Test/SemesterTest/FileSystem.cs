using System;
using System.Collections.Generic;

namespace SemesterTest
{
    public class FileSystem
    {
        private List<Folder> _folders;
        private List<File> _files;

        // Constructor
        public FileSystem()
        {
            _folders = new List<Folder>();
            _files = new List<File>();
        }

        // Method to add a folder
        public void AddFolder(Folder toAdd)
        {
            _folders.Add(toAdd);
        }

        // Method to add a file
        public void AddFile(File toAdd)
        {
            _files.Add(toAdd);
        }

        // Method to print contents of the file system
        public void PrintContents()
        {
            Console.WriteLine("This file system contains:");
            
            foreach (var folder in _folders)
            {
                folder.Print();
            }

            foreach (var file in _files)
            {
                file.Print();
            }
        }
    }
}