import mmap

try:
    shared_memory = mmap.mmap(-1, 1024, tagname="SharedMemory")
    message = "Hello from Python 2.7!"
    shared_memory.write(message)

    #raw_input("Press Enter to read from shared memory in C#...")

    shared_memory.seek(0)
    data = shared_memory.read(1024)
    print("Received message from C# process: " + data)
finally:
    shared_memory.close()