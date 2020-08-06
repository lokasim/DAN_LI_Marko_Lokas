using MedicalInstitution.ViewModel;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
