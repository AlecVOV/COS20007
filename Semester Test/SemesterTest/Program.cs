namespace SemesterTest
{
    public class Program
    {
        public static void Main()
        {
            // a) Creating a FileSystem.
            FileSystem fileSystem = new FileSystem();

            // b) Adding files to the file system.
            File file1 = new File("Document", "txt", 100);
            File file2 = new File("Presentation", "pptx", 2000);
            fileSystem.Add(file1);
            fileSystem.Add(file2);

            // c) Adding a folder that contains files to the file system.
            Folder folder1 = new Folder("Folder1");
            File file3 = new File("Image", "jpg", 500);
            folder1.Add(file3);
            fileSystem.Add(folder1);

            // d) Adding a folder that contains a folder that contains files to the file system.
            Folder folder2 = new Folder("Folder2");
            Folder subFolder1 = new Folder("SubFolder1");
            File file4 = new File("Video", "mp4", 10000);
            subFolder1.Add(file4);
            folder2.Add(subFolder1);
            fileSystem.Add(folder2);

            // e) Adding an empty folder to the file system.
            Folder emptyFolder = new Folder("EmptyFolder");
            fileSystem.Add(emptyFolder);

            // f) Calling the PrintContents method.
            fileSystem.PrintContents();
        }
    }
}
