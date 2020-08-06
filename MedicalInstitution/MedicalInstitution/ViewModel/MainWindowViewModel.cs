using MedicalInstitution.Command;
using MedicalInstitution.Models;
using MedicalInstitution.Services;
using MedicalInstitution.Views;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MedicalInstitution.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        readonly MainWindow main;

        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.main = mainWindow;
        }

        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exit application
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Da li želite napustiti aplikaciju?", "Izlaz", MessageBoxButton.YesNo);

            if (dialog == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }

        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                }
                return login;
            }
        }

        /// <summary>
        /// Method for login employee or manager
        /// </summary>
        private void LoginExecute()
        {
            try
            {
                string username = main.NameTextBox.Text;

                // Hash password
                var hasher = new SHA256Managed();
                var unhashed = Encoding.Unicode.GetBytes(main.passwordBox.Password);
                var hashed = hasher.ComputeHash(unhashed);
                var hashedPassword = Convert.ToBase64String(hashed);

                string password = hashedPassword;

                Service s = new Service();

                //Checks if there is a username and password in the database
                tblDoctor doctorLogin = s.GetUsernamePasswordDoctor(username, password);
                tblPatient patientLogin = s.GetUsernamePasswordPatient(username, password);

                if (doctorLogin != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show($"{username}, dobrodošli.", "L-Medical Institution");


                    DoctorMenu doctorMenu = new DoctorMenu
                    {
                        Owner = main
                    };
                    main.Hide();
                    doctorMenu.ShowDialog();
                }
                else if (patientLogin != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show($"{username}, dobrodošli.", "L-Medical Institution");


                    PatientMenu patientMenu = new PatientMenu
                    {
                        Owner = main
                    };
                    main.Hide();
                    patientMenu.ShowDialog();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime ili lozinka nisu ispravni,\n pokušajte opet.", "Nalog nije pronađen.");
                }
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLoginExecute()
        {
            return true;
        }
    }
}
