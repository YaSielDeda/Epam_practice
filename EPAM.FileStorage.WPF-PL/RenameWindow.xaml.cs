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
    /// Логика взаимодействия для RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        public string newName = null;
        AppFile file;
        public RenameWindow(AppFile appFile)
        {
            InitializeComponent();
            file = appFile;
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(NewNameTextBox.Text) && !string.IsNullOrWhiteSpace(NewNameTextBox.Text))
            {
                if(TypeCheckBox.IsChecked == true)
                    newName = NewNameTextBox.Text + file.Type;
                else
                    newName = NewNameTextBox.Text;
                Close();
            }
        }

        private void CancelRenameButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
