using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Practice.File_storage_and_sharing_system.entities
{
    public class AppFile
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public ulong Size { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastChange { get; set; }
        public AppFile()
        {

        }
        public AppFile(ulong size, DateTime creationDate, DateTime lastChangeDate)
        {
            Size = size;
            DateOfCreation = creationDate;
            DateOfLastChange = lastChangeDate;
        }
        public void EditName(string str)
        {
            if (str == null)
                throw new ArgumentException("Name can't be null");
            Name = str;
        }
        public void EditType(string str)
        {
            if (str == null)
                throw new ArgumentException("Type can't be null");
            Type = str;
        }
    }
}
