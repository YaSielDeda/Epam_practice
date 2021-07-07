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
    /// Логика взаимодействия для ProfileInfo.xaml
    /// </summary>
    public partial class ProfileInfo : Window
    {
        Profile thisProfile;
        public ProfileInfo(Profile profile)
        {
            InitializeComponent();
            thisProfile = profile;
            Initialization();
        }
        private void Initialization()
        {
            LabelName.Content = thisProfile.Name;
            LabelCreatedIn.Content = thisProfile.DateOfCreation;
            LabelLastActivity.Content = thisProfile.LastActivity;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ChangeProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindow change = new ChangeWindow(thisProfile);
            change.Show();
            Close();
        }
    }
}
