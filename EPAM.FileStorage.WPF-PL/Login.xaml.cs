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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Profile profile;
        ProfileLogic profileLogic;
        public Login()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text) && !string.IsNullOrWhiteSpace(NameTextBox.Text) &&
                !string.IsNullOrEmpty(PasswordTextBox.Text) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                try
                {
                    profile = new Profile();
                    profileLogic = new ProfileLogic(profile);
                    profile.SetName(NameTextBox.Text);
                    profile.SetPassword(PasswordTextBox.Text);

                    profile = profileLogic.Login(profile.Name, profile.Password);

                    MessageBox.Show($"You are logged in as {profile.Name}", "Success", MessageBoxButton.OK);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Message, MessageBoxButton.OK);
                }
                finally
                {
                    NameTextBox.Clear();
                    PasswordTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Fill in all the fields", "Error", MessageBoxButton.OK);
            }
        }
    }
}
