using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EPAM.FileStorage.WPF_PL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //FileLogic fileLogic;
        ProfileLogic profileLogic;
        public Profile profile;
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

            string[] AllDirectoriesRight = Directory.GetDirectories(profile.LastDirectoryRight);

            foreach (var folder in AllDirectoriesRight)
            {
                try
                {
                    FileInfo fi = new FileInfo(folder);
                    AppFile appFile = new AppFile((ulong)Directory.GetFiles(folder).Length, fi.CreationTime, fi.LastWriteTime) { };
                    appFile.EditName(fi.Name);
                    appFile.EditType("folder");
                    RightListView.Items.Add(appFile);
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
            if(LeftPath.Text != @"C\\" || LeftPath.Text != @"D\\" || LeftPath.Text != @"E\\")
            {
                LeftPath.Text = Directory.GetParent(LeftPath.Text).FullName;
                profile.LastDirectoryLeft = LeftPath.Text;
                profileLogic.ChangeProfile(profile);
                LoadLeftDirectory();
            }
        }

        private void UpToDirectoryRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightPath.Text != @"C\\" || RightPath.Text != @"D\\" || RightPath.Text != @"E\\")
            {
                RightPath.Text = Directory.GetParent(RightPath.Text).FullName;
                profile.LastDirectoryRight = RightPath.Text;
                profileLogic.ChangeProfile(profile);
                LoadRightDirectory();
            }
        }

        private void ChangeDirectoryLeftButton_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.InitialDirectory = profile.LastDirectoryLeft;
            openFileDialog.IsFolderPicker = true;

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                profile.LastDirectoryLeft = openFileDialog.FileName;
                LeftPath.Text = profile.LastDirectoryLeft;
                profileLogic.ChangeProfile(profile);
                LoadLeftDirectory();
            }
        }

        private void ChangeDirectoryRightButton_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.InitialDirectory = profile.LastDirectoryLeft;
            openFileDialog.IsFolderPicker = true;

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                profile.LastDirectoryRight = openFileDialog.FileName;
                RightPath.Text = profile.LastDirectoryRight;
                profileLogic.ChangeProfile(profile);
                LoadRightDirectory();
            }
        }

        private void ReplaceFromLeftToRightDirectory_Click(object sender, RoutedEventArgs e)
        {
            if(LeftListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)LeftListView.SelectedItem;

                if(fileName.Type != "folder")
                    File.Move(profile.LastDirectoryLeft + @"\" + fileName.Name, profile.LastDirectoryRight + @"\" + fileName.Name);
                else
                    Directory.Move(profile.LastDirectoryLeft + @"\" + fileName.Name, profile.LastDirectoryRight + @"\" + fileName.Name);

                LoadLeftDirectory();
                LoadRightDirectory();
            }
        }

        private void ReplaceFromRightToLeftDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (RightListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)RightListView.SelectedItem;

                if(fileName.Type != "folder")
                    File.Move(profile.LastDirectoryRight + @"\" + fileName.Name, profile.LastDirectoryLeft + @"\" + fileName.Name);
                else
                    Directory.Move(profile.LastDirectoryRight + @"\" + fileName.Name, profile.LastDirectoryLeft + @"\" + fileName.Name);

                LoadLeftDirectory();
                LoadRightDirectory();
            }
        }

        private void DeleteSelectedFromLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)LeftListView.SelectedItem;

                ConfirmDelete confirmDelete = new ConfirmDelete();
                confirmDelete.ShowDialog();
                
                if(confirmDelete.Delete == true)
                {
                    if (fileName.Type != "folder")
                        File.Delete(profile.LastDirectoryLeft + @"\" + fileName.Name);
                    else
                        Directory.Delete(profile.LastDirectoryLeft + @"\" + fileName.Name);

                    LoadLeftDirectory();
                }                
            }
        }

        private void DeleteSelectedFromRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)RightListView.SelectedItem;

                ConfirmDelete confirmDelete = new ConfirmDelete();
                confirmDelete.ShowDialog();

                if (confirmDelete.Delete == true)
                {
                    if (fileName.Type != "folder")
                        File.Delete(profile.LastDirectoryRight + @"\" + fileName.Name);
                    else
                        Directory.Delete(profile.LastDirectoryRight + @"\" + fileName.Name);

                    LoadRightDirectory();
                }
            }
        }

        private void RenameSelectedFromLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)LeftListView.SelectedItem;

                RenameWindow renameWindow = new RenameWindow(fileName);
                renameWindow.ShowDialog();

                if (renameWindow.newName != null)
                {
                    if (fileName.Type != "folder")
                        File.Move(profile.LastDirectoryLeft + @"\" + fileName.Name, profile.LastDirectoryLeft + @"\" + renameWindow.newName);
                    else
                        Directory.Move(profile.LastDirectoryLeft + @"\" + fileName.Name, profile.LastDirectoryLeft + @"\" + renameWindow.newName);

                    LoadLeftDirectory();
                }               
            }
        }

        private void RenameSelectedFromRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)RightListView.SelectedItem;

                RenameWindow renameWindow = new RenameWindow(fileName);
                renameWindow.ShowDialog();

                if (renameWindow.newName != null)
                {
                    if (fileName.Type != "folder")
                        File.Move(profile.LastDirectoryRight + @"\" + fileName.Name, profile.LastDirectoryRight + @"\" + renameWindow.newName);
                    else
                        Directory.Move(profile.LastDirectoryRight + @"\" + fileName.Name, profile.LastDirectoryRight + @"\" + renameWindow.newName);

                    LoadRightDirectory();
                }
            }
        }

        private void OpenSelectedFromLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)LeftListView.SelectedItem;

                if(fileName.Type == "folder")
                {
                    profile.LastDirectoryLeft = profile.LastDirectoryLeft + @"\" + fileName.Name;
                    profileLogic.ChangeProfile(profile);
                    LeftPath.Text = profile.LastDirectoryLeft;
                    LoadLeftDirectory();
                }
                else
                    Process.Start(profile.LastDirectoryLeft + @"\" + fileName.Name);
            }
        }

        private void LeftListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LeftListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)LeftListView.SelectedItem;

                if (fileName.Type == "folder")
                {
                    profile.LastDirectoryLeft = profile.LastDirectoryLeft + @"\" + fileName.Name;
                    profileLogic.ChangeProfile(profile);
                    LeftPath.Text = profile.LastDirectoryLeft;
                    LoadLeftDirectory();
                }
                else
                    Process.Start(profile.LastDirectoryLeft + @"\" + fileName.Name);
            }
        }

        private void OpenSelectedFromRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)RightListView.SelectedItem;

                if (fileName.Type == "folder")
                {
                    profile.LastDirectoryRight = profile.LastDirectoryRight + @"\" + fileName.Name;
                    profileLogic.ChangeProfile(profile);
                    RightPath.Text = profile.LastDirectoryRight;
                    LoadRightDirectory();
                }
                else
                    Process.Start(profile.LastDirectoryRight + @"\" + fileName.Name);
            }
        }

        private void RightListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RightListView.SelectedItem != null)
            {
                AppFile fileName = (AppFile)RightListView.SelectedItem;

                if (fileName.Type == "folder")
                {
                    profile.LastDirectoryRight = profile.LastDirectoryRight + @"\" + fileName.Name;
                    profileLogic.ChangeProfile(profile);
                    RightPath.Text = profile.LastDirectoryRight;
                    LoadRightDirectory();
                }
                else
                    Process.Start(profile.LastDirectoryRight + @"\" + fileName.Name);
            }
        }

        private void CreateLeftButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewFileOrFolder create = new CreateNewFileOrFolder();
            create.ShowDialog();

            if(create.name != null)
            {
                if (create.type == "file")
                    File.Create(profile.LastDirectoryLeft + @"\" + create.name + ".txt");
                if (create.type == "folder")
                    Directory.CreateDirectory(profile.LastDirectoryLeft + @"\" + create.name);

                LoadLeftDirectory();
            }
        }

        private void CreateRightButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewFileOrFolder create = new CreateNewFileOrFolder();
            create.ShowDialog();

            if (create.name != null)
            {
                if (create.type == "file")
                    File.Create(profile.LastDirectoryRight + @"\" + create.name + ".txt");
                if (create.type == "folder")
                    Directory.CreateDirectory(profile.LastDirectoryRight + @"\" + create.name);

                LoadRightDirectory();
            }
        }

        private void ProfileInfo_Click(object sender, RoutedEventArgs e)
        {
            ProfileInfo profileInfo = new ProfileInfo(profile);
            profileInfo.ShowDialog();
        }

        private void SearchLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(SearchTextBoxLeft.Text) && !string.IsNullOrWhiteSpace(SearchTextBoxLeft.Text))
            {
                if (SearchInFolderRButtonLeft.IsChecked == true)
                {
                    SearchResults searchResults = new SearchResults("folder", SearchTextBoxLeft.Text, LeftPath.Text);
                    SearchingLeft(searchResults);
                }
                else if (SearchInDirectoryRButtonLeft.IsChecked == true)
                {
                    SearchResults searchResults = new SearchResults("directory", SearchTextBoxLeft.Text, LeftPath.Text);
                    SearchingLeft(searchResults);
                }
                else
                    MessageBox.Show("You need to pick search option", "Error", MessageBoxButton.OK);
            }
        }
        private void SearchRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchTextBoxRight.Text) && !string.IsNullOrWhiteSpace(SearchTextBoxRight.Text))
            {
                if (SearchInFolderRButtonRight.IsChecked == true)
                {
                    SearchResults searchResults = new SearchResults("folder", SearchTextBoxRight.Text, RightPath.Text);
                    SearchingRight(searchResults);
                }
                else if (SearchInDirectoryRButtonRight.IsChecked == true)
                {
                    SearchResults searchResults = new SearchResults("directory", SearchTextBoxRight.Text, RightPath.Text);
                    SearchingRight(searchResults);
                }
                else
                    MessageBox.Show("You need to pick search option", "Error", MessageBoxButton.OK);
            }
        }
        private void SearchingLeft(SearchResults searchResults)
        {
            searchResults.ShowDialog();
            LeftPath.Text = searchResults.resultPath;
            profile.LastDirectoryLeft = searchResults.resultPath;
            profileLogic.ChangeProfile(profile);
            LoadLeftDirectory();
        }
        private void SearchingRight(SearchResults searchResults)
        {
            searchResults.ShowDialog();
            RightPath.Text = searchResults.resultPath;
            profile.LastDirectoryRight = searchResults.resultPath;
            profileLogic.ChangeProfile(profile);
            LoadRightDirectory();
        }
    }
}
