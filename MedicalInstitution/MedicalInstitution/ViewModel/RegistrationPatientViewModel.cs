using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalInstitution.Views;

namespace MedicalInstitution.ViewModel
{
    class RegistrationPatientViewModel
    {
        readonly RegistrationPatient registrationPatient;

        public RegistrationPatientViewModel(RegistrationPatient registrationPatient)
        {
            this.registrationPatient = registrationPatient;
        }
    }
}
