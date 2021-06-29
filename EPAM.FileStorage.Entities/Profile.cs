using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Practice.File_storage_and_sharing_system.entities
{
    public class Profile
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; }
        public Profile(string name, string password)
        {
            Name = name;
            Password = password;
            DateOfCreation = DateTime.Now;
        }
    }
}
