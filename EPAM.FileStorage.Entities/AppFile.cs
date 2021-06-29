using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Practice.File_storage_and_sharing_system.entities
{
    public class AppFile
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ulong Size { get; private set; }
        public DateTime DateOfCreation { get; }
        public DateTime DateOfLastChange { get; private set; }
        public AppFile(string name, string type, ulong size)
        {
            ID = Guid.NewGuid();
            Name = name;
            Type = type;
            Size = size;
            DateOfCreation = DateTime.Now;
            DateOfLastChange = DateTime.Now;
        }
    }
}
