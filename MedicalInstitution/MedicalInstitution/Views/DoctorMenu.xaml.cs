using System.Windows;

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
