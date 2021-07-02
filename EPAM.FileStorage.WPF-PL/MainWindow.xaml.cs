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
            profileLogic = new ProfileLogic(profile);

            Load();
        }
        private void Load()
        {
            if (profile != null)
            {
                LeftPath.Text = profile.LastDirectoryLeft;
                RightPath.Text = profile.LastDirectoryRight;
                LoadLeftDirectory();
                LoadRightDirectory();
            }
        }
        private void LoadLeftDirectory()
        {
            LeftListView.Items.Clear();

            string[] AllDirectoriesLeft = Directory.GetDirectories(profile.LastDirectoryLeft);

            foreach (var folder in AllDirectoriesLeft)
            {
                try
                {
                    FileInfo fi = new FileInfo(folder);
                    AppFile appFile = new AppFile((ulong)Directory.GetFiles(folder).Length, fi.CreationTime, fi.LastWriteTime) { };
                    appFile.EditName(fi.Name);
                    appFile.EditType("folder");
                    LeftListView.Items.Add(appFile);
                }
                catch (UnauthorizedAccessException uae)
                {

                }
            }

            string[] AllFilesLeft = Directory.GetFiles(profile.LastDirectoryLeft);

            foreach (var file in AllFilesLeft)
            {
                FileInfo fi = new FileInfo(file);
                AppFile appFile = new AppFile((ulong)fi.Length, fi.CreationTime, fi.LastWriteTime) { };
                appFile.EditName(fi.Name);
                appFile.EditType(fi.Extension);
                LeftListView.Items.Add(appFile);
            }
        }
        private void LoadRightDirectory()
        {
            RightListView.Items.Clear();

            string[] AllDirectoriesRight = Directory.GetDirectories(profile.LastDirectoryLeft);

            foreach (var folder in AllDirectoriesRight)
            {
                try
                {
                    FileInfo fi = new FileInfo(folder);
                    AppFile appFile = new AppFile((ulong)Directory.GetFiles(folder).Length, fi.CreationTime, fi.LastWriteTime) { };
                    appFile.EditName(fi.Name);
                    appFile.EditType("folder");
                    LeftListView.Items.Add(appFile);
                }
                catch (UnauthorizedAccessException uae)
                {

                }
            }

            string[] AllFilesRight = Directory.GetFiles(profile.LastDirectoryRight);

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

        private void LeftGoToButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LeftPath.Text) && !string.IsNullOrWhiteSpace(LeftPath.Text))
            {
                if (Directory.Exists(LeftPath.Text))
                {
                    profile.LastDirectoryLeft = LeftPath.Text;
                    profileLogic.ChangeProfile(profile);
                    LoadLeftDirectory();
                }
                else
                {
                    MessageBox.Show("This path doesn't exist", "Path error", MessageBoxButton.OK);
                    LeftPath.Text = profile.LastDirectoryLeft;
                }
            }
        }

        private void RightGoToButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(RightPath.Text) && !string.IsNullOrWhiteSpace(RightPath.Text))
            {
                if (Directory.Exists(RightPath.Text))
                {
                    profile.LastDirectoryRight = RightPath.Text;
                    profileLogic.ChangeProfile(profile);
                    LoadRightDirectory();
                }
                else
                {
                    MessageBox.Show("This path doesn't exist", "Path error", MessageBoxButton.OK);
                    RightPath.Text = profile.LastDirectoryRight;
                }
            }
        }

        private void UpToDirectoryLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if(LeftPath.Text != @"C\\" || LeftPath.Text != @"D\\")
            {
                LeftPath.Text = Directory.GetParent(LeftPath.Text).FullName;
                profile.LastDirectoryLeft = LeftPath.Text;
                profileLogic.ChangeProfile(profile);
                LoadLeftDirectory();
            }
        }

        private void UpToDirectoryRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightPath.Text != @"C\\" || RightPath.Text != @"D\\")
            {
                RightPath.Text = Directory.GetParent(RightPath.Text).FullName;
                profile.LastDirectoryRight = RightPath.Text;
                profileLogic.ChangeProfile(profile);
                LoadLeftDirectory();
            }
        }
    }
}
