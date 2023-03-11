namespace Lib;

public class DirCopy
{
    //public delegate void FileCopyDelegate(int fileCount, int index, string fileName);

    string srcDir;
    string targetDir;

    //public event FileCopyDelegate FileCopy;

    public DirCopy(string srcDir, string targetDir)
    {
        if (!Directory.Exists(srcDir))
            throw new ArgumentException("srcDir does not exist");

        this.srcDir = srcDir;
        this.targetDir = targetDir;
    }

    public void Run()
    {
        string[] files = Directory.GetFiles(srcDir);

        if (!Directory.Exists(targetDir))
            Directory.CreateDirectory(targetDir);

        int i = 0;
        string targetPath;
        foreach (string file in files)
        {
            targetPath = Path.Combine(targetDir, Path.GetFileName(file));
            File.Copy(file, targetPath, true);

            //if (FileCopy != null)
            //    FileCopy(files.Length, i, file);
            
            ++i;
        }
    }
}
