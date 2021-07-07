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
            Profile profile = new Profile(name, EncryptPassword(password));
            ProfileDAO profileDAO = new ProfileDAO(profile);
            profileDAO.CreateNewProfile(profile);
        }
        public Profile Login(string name, string password)
        {
            Profile profile = new Profile();
            profile.SetName(name);
            profile.SetPassword(EncryptPassword(password));
            try
            {
                profile = _dao.Login(profile);                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return profile;
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
        public void ChangeProfileName(Profile profile, string newName)
        {
            _dao.ChangeProfileName(profile, newName);
        }
        public void ChangeProfilePassword(Profile profile, string newPassword)
        {
            _dao.ChangeProfilePassword(profile, EncryptPassword(newPassword));
        }
        public void RemoveProfile()
        {
            _dao.RemoveProfile();
        }
    }
}
