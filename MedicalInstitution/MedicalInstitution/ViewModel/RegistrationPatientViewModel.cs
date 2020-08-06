using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MedicalInstitution.Command;
using MedicalInstitution.Models;
using MedicalInstitution.Services;
using MedicalInstitution.Views;

namespace MedicalInstitution.ViewModel
{
    class RegistrationPatientViewModel :ViewModelBase
    {
        readonly RegistrationPatient registrationPatient;
        MainWindow main = new MainWindow();

        private List<tblPatient> patientList;
        public List<tblPatient> PatientList
        {
            get
            {
                return patientList;
            }
            set
            {
                patientList = value;
                OnPropertyChanged("PatientList");
            }
        }

        private tblPatient patient;
        public tblPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }
        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }

        public RegistrationPatientViewModel(RegistrationPatient registrationPatient)
        {
            this.registrationPatient = registrationPatient;

            patient = new tblPatient();
        }

        private ICommand backToLogin;
        public ICommand BackToLogin
        {
            get
            {
                if (backToLogin == null)
                {
                    backToLogin = new RelayCommand(param => BackLoginExecute(), param => CanBackLoginExecute());
                }
                return backToLogin;
            }
        }

        //Logout Admin
        private void BackLoginExecute()
        {
            
            main.login.Visibility = Visibility.Visible;
            main.Images0.Visibility = Visibility.Collapsed;
            main.Images1.Visibility = Visibility.Visible;
            registrationPatient.SignUp.Visibility = Visibility.Collapsed;
            main.NameTextBox.Focus();
            registrationPatient.txtIme.Text = "";
            registrationPatient.txtJMBG.Text = "";
            registrationPatient.txtHealthNumber.Text = "";
            registrationPatient.txtKorisnickoIme.Text = "";
            registrationPatient.txtLozinkaRegistracija.Text = "";
            registrationPatient.txtReLozinkaRegistracija.Text = "";
            main.ShowDialog();
            //return;
        }
        private bool CanBackLoginExecute()
        {
            return true;
        }

        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }
        //Create new employee/manager
        private void SignUpExecute()
        {
            try
            {
                Service s = new Service();

                string jmbg = Patient.JMBG;
                string AN = Patient.HealthInsuranceCardNumber;
                string user = Patient.UsernameLogin;

                if (!ValidationJMBG.CheckJMBG(jmbg))
                {
                    return;
                }

                //uniqueness chech doctor JMBG
                tblDoctor doctorJMBG = s.GetDoctorJMBG(jmbg);

                if (doctorJMBG != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisnik već postoji sa tim JMBG-om, pokušajte opet.", "JMBG");
                    return;
                }

                //uniqueness check JMBG
                tblPatient patientJMBG = s.GetPatientJMBG(jmbg);

                if (patientJMBG != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisnik već postoji sa tim JMBG-om, pokušajte opet.", "JMBG");
                    return;
                }

                //uniqueness check Health Insurance Card Number
                tblPatient patientAN = s.GetPatientHealthInsuranceCardNumber(AN);

                if (patientAN != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Broj zdravstvenog osiguranja već neko koristi, pokušajte sa drugim brojem.", "Broj zdravstvenog osiguranja");
                    return;
                }

                //uniqueness check usernameDoctor
                tblDoctor employeeUserDoctor = s.GetDoctorUsername(user);

                if (employeeUserDoctor != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime je zauzeto, pokušajte neko drugo.", "Korisničko ime");
                    return;
                }

                //uniqueness check username
                tblPatient employeeUserPatient = s.GetPatientUsername(user);

                if (employeeUserPatient != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime je zauzeto, pokušajte neko drugo.", "Korisničko ime");
                    return;
                }

                // Hash Password
                var hasher = new SHA256Managed();
                var unhashed = Encoding.Unicode.GetBytes(this.Patient.PasswordLogin);
                var hashed = hasher.ComputeHash(unhashed);
                var hashedPassword = Convert.ToBase64String(hashed);

                this.Patient.PasswordLogin = hashedPassword;


                s.AddPatient(Patient);
                IsUpdateEmployee = true;
                main.NameTextBox.Text = "";
                main.passwordBox.Password = "";
                main.login.Visibility = Visibility.Visible;
                main.Images0.Visibility = Visibility.Collapsed;
                main.Images1.Visibility = Visibility.Visible;
                main.SignUp.Visibility = Visibility.Collapsed;

                string poruka = Patient.PatientNameSurname + ",\nUspešno ste se registrovali.";
                Xceed.Wpf.Toolkit.MessageBox.Show(poruka, "Registracija pacijenta", MessageBoxButton.OK);
                main.NameTextBox.Focus();
                main.ShowDialog();
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }


        private bool CanSignUpExecute()
        {
            if (String.IsNullOrEmpty(patient.PatientNameSurname) ||
                String.IsNullOrEmpty(patient.JMBG) ||
                String.IsNullOrEmpty(patient.HealthInsuranceCardNumber) ||
                String.IsNullOrEmpty(patient.UsernameLogin) ||
                String.IsNullOrEmpty(patient.PasswordLogin))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
