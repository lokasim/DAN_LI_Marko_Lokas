using MedicalInstitution.ViewModel;
using System.Windows;
using System.Windows.Markup;

namespace MedicalInstitution.Views
{
    /// <summary>
    /// Interaction logic for Choice.xaml
    /// </summary>
    public partial class Choice : Window
    {
        public Choice()
        {
            InitializeComponent();
            this.Name = "Choice";
            this.DataContext = new ChoiceViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
        }

        private void BtnPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDoctor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
