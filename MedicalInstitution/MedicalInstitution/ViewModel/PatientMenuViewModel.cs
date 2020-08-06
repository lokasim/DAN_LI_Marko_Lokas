using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalInstitution.Models;
using MedicalInstitution.Services;
using MedicalInstitution.Views;

namespace MedicalInstitution.ViewModel
{
    class PatientMenuViewModel
    {
        readonly PatientMenu patientMenu;

        public PatientMenuViewModel(PatientMenu patientMenu)
        {
            this.patientMenu = patientMenu;

            DoctorCount();
        }

        public async void DoctorCount()
        {
            Service s = new Service();
            await Task.Delay(1000);
            List<tblDoctor> doctor = s.GetAllDoctor();
            if (doctor.Count == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Trenutno u sistemu ne postoji ni jedan lekar.", "Nema lekara");
            }
        }
    }
}
