using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Dispose;

static class FileFunctions
{
    // Win32 constants for accessing files.
    internal const int GENERIC_READ = unchecked((int)0x80000000);

    // Allocate a file object in the kernel, then return a handle to it.
    [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    internal extern static IntPtr CreateFile(String fileName,
       int dwDesiredAccess, System.IO.FileShare dwShareMode,
       IntPtr securityAttrs_MustBeZero, System.IO.FileMode dwCreationDisposition,
       int dwFlagsAndAttributes, IntPtr hTemplateFile_MustBeZero);

    // Use the file handle.
    [DllImport("kernel32", SetLastError = true)]
    internal extern static int ReadFile(IntPtr handle, byte[] bytes,
       int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

    // Free the kernel's file object (close the file).
    [DllImport("kernel32", SetLastError = true)]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    internal extern static bool CloseHandle(IntPtr handle);
}


class MySuperFileReader : IDisposable
{
    // Unmanaged/natív erőforrás leírója
    private IntPtr fileHandle = IntPtr.Zero;
    // Managed/felügyelt erőforrás
    private StreamWriter streamWriter;
    bool isDisposed = false;

    public MySuperFileReader(String fileName)
    {
        // Open a file, and save its handle in _handle.
        fileHandle = FileFunctions.CreateFile(fileName, FileFunctions.GENERIC_READ,
            FileShare.Read, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

        // Determine if file is opened successfully.
        if ((int)fileHandle == -1)
            throw new Win32Exception(Marshal.GetLastWin32Error(), fileName);

        // Kimeneti file megnyitása, ...
        streamWriter = new StreamWriter(@"out.txt");
        // ...

    }

    ~MySuperFileReader()
    {
        dispose(false);
    }

    #region IDisposable Members

    public void Dispose()
    {
        dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

    void dispose(bool isDisposing)
    {
        if (!isDisposed)
        {
            // Managed resources
            if (isDisposing)
                streamWriter.Dispose();

            // Unmanaged
            FileFunctions.CloseHandle(fileHandle);
        }
        isDisposed = true;
    }

}

class MyProcessor
{
    public void Process()
    {
        // A, módon
        MySuperFileReader f1 = null;
        try
        {
            f1 = new MySuperFileReader(@"..\..\..\x.txt");
            // ...
            Console.WriteLine("No exception: file open is successful.");

        }
        finally
        {
            if (f1 != null)
                f1.Dispose();
        }

        //B, módon
        using (MySuperFileReader f2 = new MySuperFileReader(@"..\..\..\x.txt"))
        {
            //...
            Console.WriteLine("No exception: file open is successful.");

        }
    }
    //..
}

class Program
{
    static void Main(string[] args)
    {
        MyProcessor p = new MyProcessor();
        p.Process();
        // ...

    }
}
