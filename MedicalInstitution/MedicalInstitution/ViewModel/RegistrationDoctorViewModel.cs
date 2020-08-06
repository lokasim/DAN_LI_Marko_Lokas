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
    class RegistrationDoctorViewModel : ViewModelBase
    {
        readonly RegistrationDoctor registrationDoctor;
        MainWindow main = new MainWindow();

        private List<tblDoctor> doctorList;
        public List<tblDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("DoctorList");
            }
        }

        private tblDoctor doctor;
        public tblDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }
        private bool isUpdateDoctor;
        public bool IsUpdateDoctor
        {
            get
            {
                return isUpdateDoctor;
            }
            set
            {
                isUpdateDoctor = value;
            }
        }


        public RegistrationDoctorViewModel(RegistrationDoctor registrationDoctor)
        {
            this.registrationDoctor = registrationDoctor;

            doctor = new tblDoctor();
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
            registrationDoctor.SignUp.Visibility = Visibility.Collapsed;
            main.NameTextBox.Focus();
            registrationDoctor.txtIme.Text = "";
            registrationDoctor.txtPrezime.Text = "";
            registrationDoctor.txtJMBG.Text = "";
            registrationDoctor.txtAccountNumber.Text = "";
            registrationDoctor.txtKorisnickoIme.Text = "";
            registrationDoctor.txtLozinkaRegistracija.Text = "";
            registrationDoctor.txtReLozinkaRegistracija.Text = "";
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

                string jmbg = Doctor.JMBG;
                string AN = Doctor.AccountNumber;
                string user = Doctor.UsernameLogin;

                if (!ValidationJMBG.CheckJMBG(jmbg))
                {
                    return;
                }
                //uniqueness check JMBG
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

                //uniqueness check Account Number
                tblDoctor doctorAN = s.GetAccountNumber(AN);

                if (doctorAN != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Broj tekućeg računa već neko koristi, pokušajte sa drugim brojem.", "Broj tekućeg računa");
                    return;
                }

                //uniqueness check username
                tblDoctor employeeUserDoctor = s.GetDoctorUsername(user);

                if (employeeUserDoctor != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime je zauzeto, pokušajte neko drugo.", "Korisničko ime");
                    return;
                }

                //uniqueness check usernamePatient
                tblPatient employeeUserPatient = s.GetPatientUsername(user);

                if (employeeUserPatient != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime je zauzeto, pokušajte neko drugo.", "Korisničko ime");
                    return;
                }

                // Hash Password
                var hasher = new SHA256Managed();
                var unhashed = Encoding.Unicode.GetBytes(this.Doctor.PasswordLogin);
                var hashed = hasher.ComputeHash(unhashed);
                var hashedPassword = Convert.ToBase64String(hashed);

                this.Doctor.PasswordLogin = hashedPassword;

                s.AddDoctor(Doctor);
                IsUpdateDoctor = true;
                main.NameTextBox.Text = "";
                main.passwordBox.Password = "";
                main.login.Visibility = Visibility.Visible;
                main.Images0.Visibility = Visibility.Collapsed;
                main.Images1.Visibility = Visibility.Visible;
                main.SignUp.Visibility = Visibility.Collapsed;

                string poruka = doctor.DoctorName + " " + doctor.DoctorSurname + ",\nUspešno ste se registrovali.";
                Xceed.Wpf.Toolkit.MessageBox.Show(poruka, "Registracija", MessageBoxButton.OK);

                main.ShowDialog();
                
                main.NameTextBox.Focus();
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSignUpExecute()
        {
            if (String.IsNullOrEmpty(doctor.DoctorName) ||
                String.IsNullOrEmpty(doctor.DoctorSurname) ||
                String.IsNullOrEmpty(doctor.JMBG) ||
                String.IsNullOrEmpty(doctor.AccountNumber) ||
                String.IsNullOrEmpty(doctor.UsernameLogin) ||
                String.IsNullOrEmpty(doctor.PasswordLogin))
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
