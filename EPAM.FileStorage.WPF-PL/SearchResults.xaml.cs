using EPAM.FileStorage.Entitiess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SearchResults.xaml
    /// </summary>
    public partial class SearchResults : Window
    {
        string typeOfSearch;
        string searchQuery;
        string pathOfFolder;
        public string resultPath;
        public SearchResults(string type, string search, string path)
        {
            InitializeComponent();

            typeOfSearch = type;
            searchQuery = search;
            pathOfFolder = path;

            LoadResults(type, search, path);
        }

        private void LoadResults(string type, string search, string path)
        {
            string[] resultsFilesNames = null;
            string[] resultsFoldersNames = null;

            if (type == "folder")
            {
                resultsFilesNames = new DirectoryInfo(path).GetFiles(string.Format("*{0}*", search), SearchOption.TopDirectoryOnly).Select(f => f.FullName).ToArray();
                resultsFoldersNames = new DirectoryInfo(path).GetDirectories(string.Format("*{0}*", search), SearchOption.TopDirectoryOnly).Select(f => f.FullName).ToArray();
            }               
            else if (type == "directory")
            {
                resultsFilesNames = new DirectoryInfo(path).GetFiles(string.Format("*{0}*", search), SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
                resultsFoldersNames = new DirectoryInfo(path).GetDirectories(string.Format("*{0}*", search), SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
            }

            if (resultsFilesNames != null)
            {
                foreach (var file in resultsFilesNames)
                {
                    FileInfo fi = new FileInfo(file);
                    SearchResult resultFile = new SearchResult(fi.Name, fi.Extension, fi.FullName);
                    SearchResultsListView.Items.Add(resultFile);
                }
            }

            if(resultsFoldersNames != null)
            {
                foreach (var file in resultsFoldersNames)
                {
                    FileInfo fi = new FileInfo(file);
                    SearchResult resultFile = new SearchResult(fi.Name, "folder", fi.FullName);
                    SearchResultsListView.Items.Add(resultFile);
                }
            }
        }

        private void CloseSearchButton_Click(object sender, RoutedEventArgs e) => Close();

        private void GoToSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchResultsListView.SelectedItem != null)
            {
                SearchResult resultFile = (SearchResult)SearchResultsListView.SelectedItem;
                resultPath = resultFile.Path.Replace(resultFile.Name, "");

                Close();
            }
            else
                MessageBox.Show("You need to choose file or folder from the list", "Error", MessageBoxButton.OK);
        }
    }
}
