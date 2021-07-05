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
    /// Логика взаимодействия для CreateNewFileOrFolder.xaml
    /// </summary>
    public partial class CreateNewFileOrFolder : Window
    {
        public string type;
        public string name;
        public CreateNewFileOrFolder()
        {
            InitializeComponent();
        }

        private void CancelCreateButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ConfirmCreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(TextBoxName.Text) && !string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                name = TextBoxName.Text;
                if (FileRadioButton.IsChecked == true)
                {
                    type = "file";
                    Close();
                }   
                if (FolderRadioButton.IsChecked == true)
                {
                    type = "folder";
                    Close();
                }                   
            }
        }
    }
}
