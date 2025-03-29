using System;
using System.IO;

namespace FileToHexConverter {
    internal class Program {
        private static void Main() {
            Console.Title = "File to Hex Converter";
            Console.Write("Drag and drop a file here and press Enter: ");
            
            string filePath = Console.ReadLine()?.Trim('"');
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) {
                Console.WriteLine("Invalid file path. Please try again.");
                return;
            }

            try {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string hexString = BitConverter.ToString(fileBytes).Replace("-", " ");

                Console.WriteLine("\nHex Output:\n" + hexString);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
