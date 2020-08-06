using MedicalInstitution.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalInstitution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Name = "MainWindow";
            this.DataContext = new MainWindowViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
            NameTextBox.Focus();
            SignUp.Visibility = Visibility.Collapsed;
            Images1.Visibility = Visibility.Visible;
        }


        public bool korisnik;
        public bool lozinka;

        private void KorekcijaImena(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text.Length <= 5)
            {
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                NameTextBox.Foreground = new SolidColorBrush(Colors.Red);
                korisnik = false;
            }
            else
            {
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
                NameTextBox.Foreground = new SolidColorBrush(Colors.Black);
                korisnik = true;
            }
            Prijavi();
        }

        private void KorekcijaLozinke(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length <= 5)
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
                lozinka = false;
            }
            else
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Green);
                passwordBox.Foreground = new SolidColorBrush(Colors.Black);
                lozinka = true;
            }
            Prijavi();
        }
        

        private void TxtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            if (e.Key == Key.Space)
            {
                SystemSounds.Beep.Play();
            }
        }

        private Boolean TextAllowedVelikaSlova(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLower(c) || Char.IsUpper(c) || Char.IsDigit(c) || Char.IsControl(c))
                {
                    loginFail.Visibility = Visibility.Collapsed;
                    tbCapsLock.Visibility = Visibility.Collapsed;
                    continue;
                }
                else
                {
                    tbCapsLock.Visibility = Visibility.Visible;
                    tbCapsLock.Text = "Only letters and numbers are allowed";
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        //samo mala slova i brojevi
        private void PreviewTextInputHandlerVelika(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowedVelikaSlova(e.Text);
        }
        private void Prijavi()
        {
            if (lozinka == true && korisnik == true)
            {
                btnPrijavi.IsEnabled = true;
            }
            else
            {
                btnPrijavi.IsEnabled = false;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private Boolean TextAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLetter(c) || Char.IsControl(c))
                {

                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowed(e.Text);
        }

        // banned pasting value
        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            String s = (String)e.DataObject.GetData(typeof(String));
            if (!TextAllowed(s)) e.CancelCommand();
        }

        private Boolean NumberAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {

                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        //only numbers
        private void PreviewNumberInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumberAllowed(e.Text);
        }

        private void Registruj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
