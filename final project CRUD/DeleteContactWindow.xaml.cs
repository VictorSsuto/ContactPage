﻿using System;
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
    /// Interaction logic for DeleteContactWindow.xaml
    /// </summary>
    public partial class DeleteContactWindow : Window
    {
        public DeleteContactWindow()
        {
            InitializeComponent();
        }

 

        private void Delete(object sender, RoutedEventArgs e)
        {
            DeleteContact DC = new DeleteContact();
            DC.Show();
        }
    }
}
