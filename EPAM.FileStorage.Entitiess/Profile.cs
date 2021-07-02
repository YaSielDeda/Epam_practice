using System;
using System.Collections.Generic;
using System.IO;
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
        public DateTime LastActivity { get; set; }
        public string LastDirectoryLeft { get; set; }
        public string LastDirectoryRight { get; set; }
        public Profile()
        {
            DateOfCreation = DateTime.Now;
            LastActivity = DateTime.Now;
            //LastDirectoryLeft = Directory.GetCurrentDirectory();
            //LastDirectoryRight = Directory.GetCurrentDirectory();
        }
        public void SetPassword(string password)
        {
            if (password != null)
                Password = password;
            else throw new ArgumentException("Password can't be nullable");
        }
        public void SetName(string name)
        {
            if (name != null)
                Name = name;
            else throw new ArgumentException("Name can't be nullable");
        }
    }
}
