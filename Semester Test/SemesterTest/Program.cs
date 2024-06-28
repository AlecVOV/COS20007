namespace SemesterTest
{
    public class Program
    {
        public static void Main()
        {
            // a) Creating a FileSystem
            FileSystem fs = new FileSystem();

            // b) Adding files to the file system
            File file1 = new File("AnImage", "jpg", 5342);
            File file2 = new File("SomeFile", "txt", 832);
            fs.AddFile(file1);
            fs.AddFile(file2);

            // c) Adding a folder that contains files to the file system
            Folder folder1 = new Folder("Save files");
            File file3 = new File("Save 1 - The Citadel", "data", 2348);
            File file4 = new File("Save 2 - Artemis Tau", "data", 6378);
            File file5 = new File("Save 3 - Serpent Nebula", "data", 973);
            folder1.Add(file3);
            folder1.Add(file4);
            folder1.Add(file5);
            fs.AddFolder(folder1);

            // d) Adding a folder that contains a folder that contains files to the file system
            Folder subFolder = new Folder("Subfolder");
            File file6 = new File("Subfile1", "txt", 1234);
            subFolder.Add(file6);
            Folder folder2 = new Folder("ParentFolder");
            folder2.Add(subFolder);
            fs.AddFolder(folder2);

            // e) Adding an empty folder to the file system
            Folder emptyFolder = new Folder("Empty folder");
            fs.AddFolder(emptyFolder);

            // f) Calling the PrintContents method
            fs.PrintContents();
        }
    }
}
