using EPAM.FileStorage.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileStorage.BLL
{
    public class FileLogic
    {
        private FileDAO _dao;
        public FileLogic(FileDAO dao)
        {
            _dao = dao;
        }
        public void CreateTextFile(string fileName)
        {
            _dao.CreateTextFile(fileName);
        }
        public void CreateTextFile(string fileName, string text)
        {
            _dao.CreateTextFile(fileName, text);
        }
        public void MoveFile(string destFilePath, string fileName)
        {
            _dao.MoveFile(destFilePath, fileName);
        }
        public void UpdateTextFile(string fileName, string text)
        {
            _dao.UpdateTextFile(fileName, text);
        }
        public void DeleteFile(string fileName)
        {
            _dao.DeleteFile(fileName);
        }
    }
}
