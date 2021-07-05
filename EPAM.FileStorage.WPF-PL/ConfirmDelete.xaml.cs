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
    /// Логика взаимодействия для ConfirmDelete.xaml
    /// </summary>
    public partial class ConfirmDelete : Window
    {
        public bool Delete;
        public ConfirmDelete()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete = true;
            Close();
        }

        private void CancelDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete = false;
            Close();
        }
    }
}
