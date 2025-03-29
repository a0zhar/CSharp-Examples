# CSharp Based Code Examples
A collection of C# console application samples for various purposes, primarily serving as proof-of-concept projects.

# Files
## [CompileInMemory.cs](./CompileInMemory.cs)
A PoC demonstrating how to dynamically compile and execute C# code at runtime, either from a raw string or a pre-compiled byte array. By executing the compiled code directly from memory, it avoids creating an actual executable file on disk, which can bypass traditional antivirus scans since no malicious code exists in the main executable.

## Features:
- Dynamically compiles and executes C# code in memory.
- Supports both raw string input and pre-compiled byte arrays.
- Prevents the compiled payload from being written to disk.

---
## [FileToHex.cs](./FileToHex.cs)  
A simple C# console application that converts the contents of a file into a hexadecimal string representation. This can be useful for analyzing binary files, debugging, or encoding data.  

---
## [FileToBytes.cs](./FileToBytes.cs)  
A C# console application that reads a file and converts its contents into a byte array format. This is useful for embedding file data directly into C# source code or working with binary data.  


