using EPAM_Practice.File_storage_and_sharing_system.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileStorage.DAO
{
    public class FileDAO
    {
        private string _path;
        public FileDAO(string path)
        {
            if (Directory.Exists(path))
                _path = path;
            else throw new NullReferenceException("This path does't exists");
        }
        public void CreateTextFile(string fileName)
        {
            if (!File.Exists($"{_path}\\{fileName}"))
                File.WriteAllText($"{_path}\\{fileName}", "");
            else throw new Exception("File already exists");
        }
        public void CreateTextFile(string fileName, string text)
        {
            if (!File.Exists($"{_path}\\{fileName}"))
                File.WriteAllText($"{_path}\\{fileName}", text);
            else throw new Exception("File already exists");
        }
        public void MoveFile(string destFilePath, string fileName)
        {
            if (!File.Exists($"{_path}\\{fileName}"))
                throw new FileNotFoundException($"File '{fileName}' does't exists");

            Directory.Move($"{_path}\\{fileName}", $"{destFilePath}\\{fileName}");
        }
        public void UpdateTextFile(string fileName, string text)
        {
            if(!File.Exists($"{_path}\\{fileName}"))
                throw new FileNotFoundException($"File '{fileName}' does't exists");

            File.WriteAllText($"{_path}\\{fileName}", text);
        }
        public void DeleteFile(string fileName)
        {
            if (File.Exists($"{_path}\\{fileName}"))
                File.Delete($"{_path}\\{fileName}");
            else throw new FileNotFoundException($"File '{fileName}' does't exists");
        }
    }
}
