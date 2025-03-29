using System;
using System.IO;
using System.Text;

namespace FileToByteArrayConverter {
    internal class Program {
        private static void Main() {
            Console.Title = "File to Byte Array Converter";

            Console.Write("Drag and drop a file here and press Enter: ");
            string filePath = Console.ReadLine()?.Trim('"');

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) {
                Console.WriteLine("Invalid file path. Please try again.");
                return;
            }

            try {
                byte[] fileBytes = File.ReadAllBytes(filePath);

                Console.Write("Include '0x' prefix before each byte? (Y/N): ");
                bool includePrefix = Console.ReadLine()?.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase) == true;

                StringBuilder byteArrayOutput = new StringBuilder();
                for (int i = 0; i < fileBytes.Length; i++) {
                    byteArrayOutput.Append(includePrefix ? $"0x{fileBytes[i]:X2}" : $"{fileBytes[i]}");
                    if (i < fileBytes.Length - 1)
                        byteArrayOutput.Append(", ");
                }

                Console.WriteLine("\nByte Array Output:\n" + byteArrayOutput);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
