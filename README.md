# CSharp-Examples
A collection of C# console application samples for various purposes, primarily serving as proof-of-concept projects.

# Files
## [CompileInMemory.cs](./CompileInMemory.cs)
### What is this?

A PoC demonstrating how to dynamically compile and execute C# code at runtime, either from a raw string or a pre-compiled byte array. By executing the compiled code directly from memory, it avoids creating an actual executable file on disk, which can bypass traditional antivirus scans since no malicious code exists in the main executable.

## Features:
- Dynamically compiles and executes C# code in memory.
- Supports both raw string input and pre-compiled byte arrays.
- Prevents the compiled payload from being written to disk.

## Usage:
The program contains an embedded "Hello, World" example encoded as a byte array, which gets compiled and executed at runtime.

