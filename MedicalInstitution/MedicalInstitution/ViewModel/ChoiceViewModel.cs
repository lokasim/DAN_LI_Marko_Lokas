using System;
using System.Windows.Input;
using MedicalInstitution.Command;
using MedicalInstitution.Views;

namespace MedicalInstitution.ViewModel
{
    class ChoiceViewModel : ViewModelBase
    {
        readonly Choice choice;
        public static int choosen = 0;

        public ChoiceViewModel(Choice choice)
        {
            this.choice = choice;
        }

        private ICommand patient;
        public ICommand Patient
        {
            get
            {
                if (patient == null)
                {
                    patient = new RelayCommand(param => PatientExecute(), param => CanPatientExecute());
                }
                return patient;
            }
        }
        //View patient registration
        private void PatientExecute()
        {
            try
            {
                choosen = 1;
                choice.Close();
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }
        
        private bool CanPatientExecute()
        {
            return true;
        }

        private ICommand doctor;
        public ICommand Doctor
        {
            get
            {
                if (doctor == null)
                {
                    doctor = new RelayCommand(param => DoctorExecute(), param => CanDoctorExecute());
                }
                return doctor;
            }
        }

        //View dialog for doctor registration
        private void DoctorExecute()
        {
            try
            {

                choosen = 2;
                choice.Close();
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }
        
        private bool CanDoctorExecute()
        {
            return true;
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
            choice.Close();
        }

        private bool CanExitExecute()
        {
            return true;
        }
    }
}
