using EPAM.FileStorage.DAO;
using EPAM_Practice.File_storage_and_sharing_system.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileStorage.BLL
{
    public class ProfileLogic
    {
        private ProfileDAO _dao;
        public ProfileLogic(Profile profile)
        {
            _dao = new ProfileDAO(profile);
        }
        public void CreateProfile(string name, string password)
        {
            Profile profile = new Profile();
            profile.SetName(name);
            profile.SetPassword(EncryptPassword(password));
            _dao.CreateNewProfile(profile);
        }
        public Profile Login(string name, string password)
        {
            Profile profile = new Profile();
            profile.SetName(name);
            profile.SetPassword(EncryptPassword(password));

            profile = _dao.Login(profile);

            if (profile != null)
                return profile;
            else throw new Exception("Profile doesn't exist");
        }
        private string EncryptPassword(string rawPassword)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
            return Convert.ToBase64String(hash);
        }
        public void ChangeProfile(Profile profile)
        {
            _dao.ChangeProfileInfo(profile);
        }
        public void RemoveProfile()
        {
            _dao.RemoveProfile();
        }
    }
}
