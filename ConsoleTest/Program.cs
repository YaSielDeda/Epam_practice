using System;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\www\source\repos\EPAM_Practice.File_storage_and_sharing_system\Test folder 1";
            string[] names = Directory.GetFiles(path);
            //foreach (var name in names)
            //{
            //    FileInfo fi = new FileInfo(name);
            //    Console.WriteLine($"{fi.Name}\t {fi.Length}\t {fi.CreationTime}\t {fi.LastWriteTime}");
            //}
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }
}
