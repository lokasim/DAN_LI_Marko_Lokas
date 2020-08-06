﻿using MedicalInstitution.ViewModel;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace MedicalInstitution.Views
{
    /// <summary>
    /// Interaction logic for RegistrationDoctor.xaml
    /// </summary>
    public partial class RegistrationDoctor : UserControl
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

        public RegistrationDoctor()
        {
            InitializeComponent();
            this.Name = "RegistrationDoctor";
            this.DataContext = new RegistrationDoctorViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");

            mainWindow.Images1.Visibility = Visibility.Visible;
            mainWindow.Images0.Visibility = Visibility.Collapsed;
        }
        

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
                tbCapsLock.Foreground = new SolidColorBrush(Colors.Red);
                tbCapsLock.Text = "Minimum 3 slova";
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

        private void Prezime(object sender, TextChangedEventArgs e)
        {
            if (txtPrezime.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.Red);
                tbCapsLock.Text = "Minimum 3 slova";
            }

            if (txtPrezime.Text.Length <= 2)
            {
                txtPrezime.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPrezime.Foreground = new SolidColorBrush(Colors.Red);
                prezimeBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtPrezime.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtPrezime.Foreground = new SolidColorBrush(Colors.Blue);
                prezimeBool = true;
            }
            txtPrezime.MaxLength = 30;
            if (txtPrezime.Text.Length >= txtPrezime.MaxLength)
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
                tbCapsLock.Foreground = new SolidColorBrush(Colors.Red);
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
                //tbCapsLock.Foreground = new SolidColorBrush(Colors.White);
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
            if (txtAccountNumber.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Broj tekućeg računa mora da \nsadrži minimum 18 cifara";
            }
            if (txtAccountNumber.Text.Length != 18)
            {
                txtAccountNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAccountNumber.Foreground = new SolidColorBrush(Colors.Red);
                accountNumberBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtAccountNumber.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAccountNumber.Foreground = new SolidColorBrush(Colors.Blue);
                accountNumberBool = true;
            }
            txtAccountNumber.MaxLength = 18;
            if (txtAccountNumber.Text.Length >= txtAccountNumber.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }
        

        private void Registruj()
        {
            if (imeBool == true &&
                prezimeBool == true &&
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
                    tbCapsLock.Text = "Dozvoljena su samo slova i brojevi";
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
