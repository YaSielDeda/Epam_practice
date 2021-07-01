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
    /// Логика взаимодействия для CreateNewProfile.xaml
    /// </summary>
    public partial class CreateNewProfile : Window
    {
        public Profile profile;
        ProfileLogic profileLogic;
        public CreateNewProfile()
        {
            InitializeComponent();
        }

        private void CancelCreateProfileButton_Click(object sender, RoutedEventArgs e) => Close();

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(NameTextBox.Text) && !string.IsNullOrWhiteSpace(NameTextBox.Text) &&
               !string.IsNullOrEmpty(PasswordTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text) &&
               !string.IsNullOrEmpty(PasswordConfirmTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordConfirmTextBox.Text))
            {
                if(PasswordTextBox.Text == PasswordConfirmTextBox.Text)
                {
                    try
                    {
                        profile = new Profile();
                        profileLogic = new ProfileLogic(profile);
                        profile.SetName(NameTextBox.Text);
                        profile.SetPassword(PasswordTextBox.Text);

                        profileLogic.CreateProfile(profile.Name, profile.Password);

                        MessageBox.Show("The new profile has been successfully created!", "Success", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Message, MessageBoxButton.OK);
                    }
                    finally
                    {
                        NameTextBox.Clear();
                        PasswordTextBox.Clear();
                        PasswordConfirmTextBox.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill in all the fields", "Error", MessageBoxButton.OK);
            }
        }
    }
}
