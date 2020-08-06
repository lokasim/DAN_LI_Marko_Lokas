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

namespace MedicalInstitution.Views
{
    /// <summary>
    /// Interaction logic for RegistrationPatient.xaml
    /// </summary>
    public partial class RegistrationPatient : UserControl
    {
        public bool imeBool;
        public bool prezimeBool;
        public bool korisnickoBool;
        public bool datumBool;
        public bool emailBool;
        public bool lozinkaBool;
        public bool reLozinkaBool;
        public bool jmbgBool;
        public bool accountNumberBool;
        public bool positionBool;
        public bool salaryBool;
        public static bool napravljenaIzmena = false;

        MainWindow mainWindow = new MainWindow();

        public RegistrationPatient()
        {
            InitializeComponent();
            this.Name = "RegistrationDoctor";
            this.DataContext = new RegistrationPatientViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");

            mainWindow.Images1.Visibility = Visibility.Visible;
            mainWindow.Images0.Visibility = Visibility.Collapsed;
        }

        //public bool korisnik;
        //public bool lozinka;

        //private void KorekcijaImena(object sender, TextChangedEventArgs e)
        //{
        //    if (NameTextBox.Text.Length <= 5)
        //    {
        //        NameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
        //        NameTextBox.Foreground = new SolidColorBrush(Colors.Red);
        //        korisnik = false;
        //    }
        //    else
        //    {
        //        NameTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
        //        NameTextBox.Foreground = new SolidColorBrush(Colors.Black);
        //        korisnik = true;
        //    }
        //    Prijavi();
        //}

        //private void KorekcijaLozinke(object sender, RoutedEventArgs e)
        //{
        //    if (passwordBox.Password.Length <= 5)
        //    {
        //        passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
        //        passwordBox.Foreground = new SolidColorBrush(Colors.Red);
        //        lozinka = false;
        //    }
        //    else
        //    {
        //        passwordBox.BorderBrush = new SolidColorBrush(Colors.Green);
        //        passwordBox.Foreground = new SolidColorBrush(Colors.Black);
        //        lozinka = true;
        //    }
        //    Prijavi();
        //}

        //private void KorekcijaLozinkeTxt(object sender, RoutedEventArgs e)
        //{
        //    if (txtPasswordBox.Text.Length <= 5)
        //    {
        //        passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
        //        passwordBox.Foreground = new SolidColorBrush(Colors.Red);
        //        lozinka = false;
        //    }
        //    else
        //    {
        //        passwordBox.BorderBrush = new SolidColorBrush(Colors.Green);
        //        passwordBox.Foreground = new SolidColorBrush(Colors.Black);
        //        lozinka = true;
        //    }
        //    Prijavi();
        //}


        //private void TxtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    e.Handled = e.Key == Key.Space;
        //    if (e.Key == Key.Space)
        //    {
        //        SystemSounds.Beep.Play();
        //    }
        //}

        //private Boolean TextAllowedVelikaSlova(String s)
        //{
        //    foreach (Char c in s.ToCharArray())
        //    {
        //        if (Char.IsLower(c) || Char.IsUpper(c) || Char.IsDigit(c) || Char.IsControl(c))
        //        {
        //            loginFail.Visibility = Visibility.Collapsed;
        //            tbCapsLock.Visibility = Visibility.Collapsed;
        //            continue;
        //        }
        //        else
        //        {
        //            tbCapsLock.Visibility = Visibility.Visible;
        //            tbCapsLock.Text = "Only letters and numbers are allowed";
        //            SystemSounds.Beep.Play();
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        ////samo mala slova i brojevi
        //private void PreviewTextInputHandlerVelika(Object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = !TextAllowedVelikaSlova(e.Text);
        //}
        //private void Prijavi()
        //{
        //    if (lozinka == true && korisnik == true)
        //    {
        //        btnPrijavi.IsEnabled = true;
        //    }
        //    else
        //    {
        //        btnPrijavi.IsEnabled = false;
        //    }
        //}

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
            Environment.Exit(0);
        }


        private void Ime(object sender, TextChangedEventArgs e)
        {
            if (txtIme.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Minimum 3 karaktera";
            }
            if (txtIme.Text.Length <= 2)
            {
                txtIme.BorderBrush = new SolidColorBrush(Colors.Red);
                txtIme.Foreground = new SolidColorBrush(Colors.Red);
                imeBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtIme.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtIme.Foreground = new SolidColorBrush(Colors.Blue);
                imeBool = true;
            }
            txtIme.MaxLength = 30;
            if (txtIme.Text.Length >= txtIme.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Korisnicko(object sender, TextChangedEventArgs e)
        {
            if (txtKorisnickoIme.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Korisničko ime treba da \nsadrži minimum 6 karaktera";
            }
            if (txtKorisnickoIme.Text.Length <= 5)
            {
                txtKorisnickoIme.BorderBrush = new SolidColorBrush(Colors.Red);
                txtKorisnickoIme.Foreground = new SolidColorBrush(Colors.Red);
                korisnickoBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtKorisnickoIme.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtKorisnickoIme.Foreground = new SolidColorBrush(Colors.Blue);
                korisnickoBool = true;
            }
            txtKorisnickoIme.MaxLength = 30;
            if (txtKorisnickoIme.Text.Length >= txtKorisnickoIme.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }




        private void Lozinka(object sender, TextChangedEventArgs e)
        {
            if (txtLozinkaRegistracija.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Lozinka treba dasadrži\nminimum 6 karaktera";
            }
            string lozinka = txtLozinkaRegistracija.Text.ToString();
            string reLozinka = txtReLozinkaRegistracija.Text.ToString();
            if (txtLozinkaRegistracija.Text.Length <= 5)
            {
                txtLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                lozinkaBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Blue);
                lozinkaBool = true;
            }

            if (reLozinka != lozinka)
            {
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                reLozinkaBool = false;
                Registruj();
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Blue);
                reLozinkaBool = true;
                Registruj();
            }

            Registruj();
        }
        private void LozinkaRe(object sender, TextChangedEventArgs e)
        {

            if (txtReLozinkaRegistracija.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Ponovljena lozinka se ne poklapa";
            }
            string lozinka = txtLozinkaRegistracija.Text.ToString();
            string reLozinka = txtReLozinkaRegistracija.Text.ToString();
            //if(reLozinka == lozinka)

            if (reLozinka != lozinka)
            {
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                reLozinkaBool = false;
                Registruj();
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Blue);
                reLozinkaBool = true;
                Registruj();
            }
            Registruj();
        }

        private void JMBG(object sender, TextChangedEventArgs e)
        {
            if (txtJMBG.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "JMBG mora da sadrži 13 cifara";
            }

            if (txtJMBG.Text.Length != 13)
            {
                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Red);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Red);
                jmbgBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Blue);
                jmbgBool = true;
            }
            txtJMBG.MaxLength = 13;
            if (txtJMBG.Text.Length >= txtJMBG.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void AccountNumber(object sender, TextChangedEventArgs e)
        {
            if (txtHealthNumber.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Broj zdravstvenog  osiguranja\nmora da sadrži minimum 12 cifara";
            }
            if (txtHealthNumber.Text.Length != 12)
            {
                txtHealthNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtHealthNumber.Foreground = new SolidColorBrush(Colors.Red);
                accountNumberBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtHealthNumber.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtHealthNumber.Foreground = new SolidColorBrush(Colors.Blue);
                accountNumberBool = true;
            }
            txtHealthNumber.MaxLength = 12;
            if (txtHealthNumber.Text.Length >= txtHealthNumber.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }


        private void Registruj()
        {
            if (imeBool == true &&
                korisnickoBool == true &&
                lozinkaBool == true &&
                reLozinkaBool == true &&
                jmbgBool == true &&
                accountNumberBool == true &&
                txtLozinkaRegistracija.Text.ToString().Equals(txtReLozinkaRegistracija.Text.ToString()))
            {
                btnRegistracija.IsEnabled = true;
            }
            else
            {
                btnRegistracija.IsEnabled = false;
            }
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

        private void BtnVratiPrijavu_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NameTextBox.Focus();
            mainWindow.Images1.Visibility = Visibility.Visible;

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
                    tbCapsLock.Visibility = Visibility.Collapsed;
                    tbCapsLock.Visibility = Visibility.Collapsed;
                    continue;
                }
                else
                {
                    tbCapsLock.Visibility = Visibility.Visible;
                    tbCapsLock.Text = "Dozvoljen je upis samo slova i brojeva";
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

        private void BtnRegistracija_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
