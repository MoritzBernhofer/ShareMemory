using System.IO.MemoryMappedFiles;

namespace prop;
class ZuWild {
    static void Main(string[] args) {
        PythonExecutor abc = new(@"C:\Python27\python.exe",
            @"C:\Users\flyti\Desktop\ToDo\ShareMemory\ShareMemory\ShareMemory\ShareMemoryPy.py");



        using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("SharedMemory", 1024)) {
            using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor()) {
                byte[] buffer = new byte[1024];
                accessor.WriteArray(0, buffer, 0, buffer.Length);

                Console.WriteLine("Waiting for Python process to write to shared memory...");
                abc.Execute(10);

                accessor.ReadArray(0, buffer, 0, buffer.Length);
                string message = System.Text.Encoding.ASCII.GetString(buffer);
                Console.WriteLine("Received message from Python process: " + message);
            }
        }

    }
}