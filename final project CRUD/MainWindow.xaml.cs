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

namespace final_project_CRUD
{
    /// <summary>
    /// Interaction logic for Mainwindow.xaml
    /// </summary>
    public partial class Mainwindow : Window
    {
        public Mainwindow()
        {
            InitializeComponent();
        }
        private void EditButton(object sender, RoutedEventArgs e)
        {

            EditingContactWindow ew = new EditingContactWindow();
            ew.Show();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            CreateDetailsWindow cr = new CreateDetailsWindow();
            cr.Show();
        }

        private void View(object sender, RoutedEventArgs e)
        {
            ViewContactWindow vw = new ViewContactWindow();
            vw.Show();

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            DeleteContactWindow DW = new DeleteContactWindow();
            DW.Show();
        }
    }
}
