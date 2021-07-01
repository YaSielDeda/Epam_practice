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
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Window
    {
        public Profile profile;
        public Enter()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            profile = login.profile;
            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProfile create = new CreateNewProfile();
            create.ShowDialog();
            profile = create.profile;
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
