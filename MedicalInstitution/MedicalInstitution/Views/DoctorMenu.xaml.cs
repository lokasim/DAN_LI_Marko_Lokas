﻿using MedicalInstitution.ViewModel;
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

namespace MedicalInstitution.Views
{
    /// <summary>
    /// Interaction logic for DoctorMenu.xaml
    /// </summary>
    public partial class DoctorMenu : Window
    {
        public DoctorMenu()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            MainWindow main = new MainWindow();

            main.ShowDialog();
        }
    }
}