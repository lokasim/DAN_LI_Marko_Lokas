using MedicalInstitution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace MedicalInstitution.Services
{
    class Service
    {
        /// <summary>
        /// Checks if there is a username in the database - doctor
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public tblDoctor GetDoctorUsername(string username)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblDoctor user = (from e in context.tblDoctors where e.UsernameLogin.Equals(username) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblDoctor GetDoctorJMBG(string jmbg)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblDoctor user = (from e in context.tblDoctors where e.JMBG.Equals(jmbg) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblDoctor GetAccountNumber(string accountNumber)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblDoctor user = (from e in context.tblDoctors where e.AccountNumber.Equals(accountNumber) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Checks if there is a username in the database - patient
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public tblPatient GetPatientUsername(string username)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblPatient user = (from e in context.tblPatients where e.UsernameLogin.Equals(username) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatientJMBG(string jmbg)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblPatient user = (from e in context.tblPatients where e.JMBG.Equals(jmbg) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatientHealthInsuranceCardNumber(string cardNumber)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblPatient user = (from e in context.tblPatients where e.HealthInsuranceCardNumber.Equals(cardNumber) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for adding new Doctor
        /// </summary>
        /// <param name="user">new doctor</param>
        /// <returns></returns>
        public tblDoctor AddDoctor(tblDoctor user)
        {
            try
            {

                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    if (user.DoctorID == 0)
                    {
                        tblDoctor newUser = new tblDoctor
                        {
                            DoctorID = user.DoctorID,
                            DoctorName = user.DoctorName,
                            DoctorSurname = user.DoctorSurname,
                            AccountNumber = user.AccountNumber,
                            JMBG = user.JMBG,
                            UsernameLogin = user.UsernameLogin,
                            PasswordLogin = user.PasswordLogin
                        };

                        context.tblDoctors.Add(newUser);
                        context.SaveChanges();
                        user.DoctorID = newUser.DoctorID;
                        return user;
                    }
                    else
                    {
                        tblDoctor userToEdit = (from r in context.tblDoctors where r.DoctorID == user.DoctorID select r).First();

                        userToEdit.DoctorID = user.DoctorID;
                        userToEdit.DoctorName = user.DoctorName;
                        userToEdit.DoctorSurname = user.DoctorSurname;
                        userToEdit.AccountNumber = user.AccountNumber;
                        userToEdit.JMBG = user.JMBG;
                        userToEdit.UsernameLogin = user.UsernameLogin;
                        userToEdit.PasswordLogin = user.PasswordLogin;
                        context.SaveChanges();
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nešto je pošlo po zlu prilikom registracije", "Greška");
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for adding new Patient
        /// </summary>
        /// <param name="user">new patient</param>
        /// <returns></returns>
        public tblPatient AddPatient(tblPatient user)
        {
            try
            {

                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    if (user.PatientID == 0)
                    {
                        tblPatient newUser = new tblPatient
                        {
                            PatientID = user.PatientID,
                            PatientNameSurname = user.PatientNameSurname,
                            HealthInsuranceCardNumber = user.HealthInsuranceCardNumber,
                            JMBG = user.JMBG,
                            UsernameLogin = user.UsernameLogin,
                            PasswordLogin = user.PasswordLogin
                        };

                        context.tblPatients.Add(newUser);
                        context.SaveChanges();
                        user.PatientID = newUser.PatientID;
                        return user;
                    }
                    else
                    {
                        tblPatient userToEdit = (from r in context.tblPatients where r.PatientID == user.PatientID select r).First();

                        userToEdit.PatientID = user.PatientID;
                        userToEdit.PatientNameSurname = user.PatientNameSurname;
                        userToEdit.HealthInsuranceCardNumber = user.HealthInsuranceCardNumber;
                        userToEdit.JMBG = user.JMBG;
                        userToEdit.UsernameLogin = user.UsernameLogin;
                        userToEdit.PasswordLogin = user.PasswordLogin;
                        context.SaveChanges();
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nešto je pošlo po zlu prilikom registracije", "Greška");
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblDoctor GetUsernamePasswordDoctor(string username, string password)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblDoctor doctor = (from e in context.tblDoctors where e.UsernameLogin.Equals(username) where e.PasswordLogin.Equals(password) select e).First();


                    return doctor;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetUsernamePasswordPatient(string username, string password)
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    tblPatient patient = (from e in context.tblPatients where e.UsernameLogin.Equals(username) where e.PasswordLogin.Equals(password) select e).First();


                    return patient;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblDoctor> GetAllDoctor()
        {
            try
            {
                using (MedicalInstitutionEntities context = new MedicalInstitutionEntities())
                {
                    List<tblDoctor> list = new List<tblDoctor>();
                    list = (from x in context.tblDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
    }
}
