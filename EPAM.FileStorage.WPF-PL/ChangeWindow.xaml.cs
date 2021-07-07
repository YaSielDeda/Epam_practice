using EPAM.FileStorage.BLL;
using EPAM_Practice.File_storage_and_sharing_system.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EPAM.FileStorage.WPF_PL
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        Profile thisProfile;
        public ChangeWindow(Profile profile)
        {
            InitializeComponent();
            thisProfile = profile;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) 
        {
            ProfileInfo profileInfo = new ProfileInfo(thisProfile);
            profileInfo.Show();
            Close();
        }

        private void ChangeNameButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(CurrentPasswordField.Text) && !string.IsNullOrWhiteSpace(CurrentPasswordField.Text) &&
               !string.IsNullOrEmpty(NewNameTextField.Text) && !string.IsNullOrWhiteSpace(NewNameTextField.Text))
            {
                ProfileLogic profileLogic = new ProfileLogic(thisProfile);
                if(thisProfile.Password == profileLogic.Login(thisProfile.Name, CurrentPasswordField.Text).Password)
                {
                    profileLogic.ChangeProfileName(thisProfile, NewNameTextField.Text);
                    MessageBox.Show("The profile name has been successfully changed", "Success", MessageBoxButton.OK);

                    CurrentPasswordField.Clear();
                    NewNameTextField.Clear();
                }
            }
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentPasswordField.Text) && !string.IsNullOrWhiteSpace(CurrentPasswordField.Text) &&
               !string.IsNullOrEmpty(NewPasswordTextField.Text) && !string.IsNullOrWhiteSpace(NewPasswordTextField.Text))
            {
                ProfileLogic profileLogic = new ProfileLogic(thisProfile);
                try
                {
                    thisProfile.Password = profileLogic.Login(thisProfile.Name, CurrentPasswordField.Text).Password;

                    profileLogic.ChangeProfilePassword(thisProfile, NewPasswordTextField.Text);
                    MessageBox.Show("The profile password has been successfully changed", "Success", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                }
                finally
                {
                    CurrentPasswordField.Clear();
                    NewPasswordTextField.Clear();
                }    
            }
        }

        private void DeleteProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileLogic profileLogic = new ProfileLogic(thisProfile);
            profileLogic.RemoveProfile();

            MessageBox.Show("Profile has been removed. Application will be closed", "Done", MessageBoxButton.OK);
            
            Application.Current.Shutdown();

            Close();
        }
    }
}

