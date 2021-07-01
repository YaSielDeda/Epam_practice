using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EPAM.FileStorage.BLL;
using EPAM_Practice.File_storage_and_sharing_system.entities;

namespace EPAM.FileStorage.WPF_PL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileLogic fileLogic;
        ProfileLogic profileLogic;
        Profile profile;
        public MainWindow()
        {
            InitializeComponent();

            Enter enter = new Enter();
            enter.ShowDialog();
            profile = enter.profile;

            Load();
        }
        private void Load()
        {
            if (profile != null)
            {
                LeftPath.Text = profile.LastDirectoryLeft;
                RightPath.Text = profile.LastDirectoryRight;
                LoadDirectories();
            }
        }
        private void AddBack()
        {
            AppFile appFile = new AppFile() { };
            appFile.EditName("...");
            LeftListView.Items.Add(appFile);
            RightListView.Items.Add(appFile);
        }
        private void LoadDirectories()
        {
            string[] AllFilesLeft = Directory.GetFiles(profile.LastDirectoryLeft);
            string[] AllFilesRight = Directory.GetFiles(profile.LastDirectoryRight);
            AddBack();
            foreach (var file in AllFilesLeft)
            {
                FileInfo fi = new FileInfo(file);
                AppFile appFile = new AppFile((ulong)fi.Length, fi.CreationTime, fi.LastWriteTime) { };
                appFile.EditName(fi.Name);
                appFile.EditType(fi.Extension);
                LeftListView.Items.Add(appFile);
            }
            foreach (var file in AllFilesRight)
            {
                FileInfo fi = new FileInfo(file);
                AppFile appFile = new AppFile((ulong)fi.Length, fi.CreationTime, fi.LastWriteTime) { };
                appFile.EditName(fi.Name);
                appFile.EditType(fi.Extension);
                RightListView.Items.Add(appFile);
            }
        }

        private void CreateNewProfile_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProfile createProfile = new CreateNewProfile();
            createProfile.ShowDialog();
            profile = createProfile.profile;
            Load();
        }

        private void LoadProfile_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            profile = login.profile;
            Load();
        }
    }
}
