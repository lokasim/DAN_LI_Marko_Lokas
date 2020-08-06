using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public RegistrationDoctorViewModel(RegistrationDoctor registrationDoctor)
        {
            this.registrationDoctor = registrationDoctor;
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

            return;
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

                //string jmbg = Employee.JMBG;
                //string AN = Employee.AccountNumber;
                //string user = Employee.UsernameLogin;
                //string email = Employee.EMail;

                //if (!ValidationJMBG.CheckJMBG(jmbg))
                //{
                //    return;
                //}
                ////uniqueness check JMBG
                //tblEmployee employee = s.GetEmployeeJMBG(jmbg);

                //if (employee != null)
                //{
                //    Xceed.Wpf.Toolkit.MessageBox.Show("JMBG already exists in the database, try another.", "JMBG");
                //    return;
                //}

                ////uniqueness check Account Number
                //tblEmployee employeeAN = s.GetEmployeeAccountNumber(AN);

                //if (employeeAN != null)
                //{
                //    Xceed.Wpf.Toolkit.MessageBox.Show("Account Number already exists in the database, try another.", "Account Number");
                //    return;
                //}

                ////uniqueness check username
                //tblEmployee employeeUser = s.GetEmployeeUsername(user);

                //if (employeeUser != null)
                //{
                //    Xceed.Wpf.Toolkit.MessageBox.Show("Username already exists in the database, try another.", "Username");
                //    return;
                //}

                ////uniqueness check email address
                //tblEmployee employeeEmail = s.GetEmployeeEmail(email);

                //if (employeeEmail != null)
                //{
                //    Xceed.Wpf.Toolkit.MessageBox.Show("E-mail already exists in the database, try another.", "E-mail");
                //    return;
                //}

                //if (main.cbxSector.Text != "" && main.cbxAccessLevel.Text != "")
                //{
                //    Employee.SectorName = Convert.ToInt32(Sector.SectorID);
                //    Employee.AccessLevel = Convert.ToInt32(AccessLevel.AccessLevelID);
                //}
                //CreateManager.logName = main.txtIme.Text.ToString();
                //CreateManager.logSurname = main.txtPrezime.Text.ToString();
                //CreateManager.logJMBG = main.txtJMBG.Text.ToString();
                //CreateManager.logEmail = main.txtEmail.Text.ToString();
                //CreateManager.logUsername = main.txtKorisnickoIme.Text.ToString();
                //CreateManager.logPassword = main.txtLozinkaRegistracija.Text.ToString();
                //CreateManager.logSector = main.cbxSector.Text.ToString();
                //CreateManager.logAccess = main.cbxAccessLevel.Text.ToString();
                //CreateManager.logPosition = main.txtPosition.Text.ToString();

                ////Save manager in txt file
                //string logMessage = $"Manager: [{CreateManager.logName} {CreateManager.logSurname }] Position: [{CreateManager.logPosition}] Sector: [{ CreateManager.logSector}] " +
                //    $"Access Level: [{ CreateManager.logAccess}] Username: [{CreateManager.logUsername }] Password: [{CreateManager.logPassword }] Email: [{ CreateManager.logEmail}] JMBG: [{CreateManager.logJMBG }] ";

                //if (main.cbxSector.Text != "" && main.cbxAccessLevel.Text != "")
                //{
                //    Thread logThread = new Thread(() => LogMethod(logMessage));
                //    logThread.Start();
                //}

                //s.AddEmployee(Employee);
                //IsUpdateEmployee = true;
                //main.NameTextBox.Text = "";
                //main.passwordBox.Password = "";
                //main.txtPasswordBox.Text = "";
                //main.login.Visibility = Visibility.Visible;
                //main.Images0.Visibility = Visibility.Collapsed;
                //main.Images1.Visibility = Visibility.Visible;
                //main.SignUp.Visibility = Visibility.Collapsed;

                //string poruka = "Add Employee: " + Employee.EmployeeName + " " + Employee.EmployeeSurname;
                //Xceed.Wpf.Toolkit.MessageBox.Show(poruka, "successfully added employee", MessageBoxButton.OK);

                //main.txtIme.Text = "";
                //main.txtPrezime.Text = "";
                //main.txtJMBG.Text = "";
                //main.dpDatumRodjenja.Text = "";
                //main.txtAccountNumber.Text = "";
                //main.txtEmail.Text = "";
                //main.txtKorisnickoIme.Text = "";
                //main.txtLozinkaRegistracija.Text = "";
                //main.txtReLozinkaRegistracija.Text = "";
                //main.txtSalary.Text = "";
                //main.txtPosition.Text = "";
                //main.cbxSector.Text = "";
                //main.cbxAccessLevel.Text = "";
                //main.NameTextBox.Focus();
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
