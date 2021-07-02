using EPAM_Practice.File_storage_and_sharing_system.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileStorage.DAO
{
    public class ProfileDAO
    {
        Profile _profile;
        public ProfileDAO(Profile profile)
        {
            _profile = profile;
        }
        public const string JsonFilesPath = @"C:\Users\www\source\repos\EPAM_Practice.File_storage_and_sharing_system\profiles\";
        public void CreateNewProfile(Profile profile)
        {
            string json = JsonConvert.SerializeObject(profile);

            if (!File.Exists($"{JsonFilesPath}\\{profile.Name}"))
                File.WriteAllText($"{JsonFilesPath}\\{profile.Name}", json);
            else throw new FileLoadException("File with this name can't be created, because file with this name already exists");
        }
        public void ChangeProfileInfo(Profile profile)
        {            
            if (File.Exists($"{JsonFilesPath}\\{profile.Name}"))
            {
                string json = JsonConvert.SerializeObject(profile);
                File.WriteAllText($"{JsonFilesPath}\\{profile.Name}", json);
            }                
            else throw new FileLoadException("File with this name doesn't exists");
        }
        public void RemoveProfile()
        {
            if (File.Exists($"{JsonFilesPath}\\{_profile.Name}"))
                File.Delete($"{JsonFilesPath}\\{_profile.Name}");
            else throw new FileNotFoundException("File with this name doesn't exists");
        }
        public Profile Login(Profile profile)
        {
            if (File.Exists($"{JsonFilesPath}\\{profile.Name}"))
            {
                Profile checkProfile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText($"{JsonFilesPath}\\{profile.Name}"));
                if (profile.Password == checkProfile.Password)
                    return checkProfile;
                else return null;
            }
            else throw new FileNotFoundException("File with this name doesn't exists");
        }
    }
}
