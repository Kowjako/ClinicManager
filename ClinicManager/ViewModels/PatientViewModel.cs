﻿using ClinicManager.Controls;
using ClinicManager.DataAccessLayer;
using ClinicManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using static Test.Form1;

namespace ClinicManager.ViewModels
{
    public class PatientViewModel : IPatientDetailsViewModel
    {
        public void AddPatient()
        {
            var form = new PatientDetails(DetailsMode.Add);
            form.ShowDialog();
        }

        public void DeletePatient(PatientRow patient)
        {
            using (var context = new ClinicDataEntities())
            {
                var deletePatient = context.Patients.Find(patient.Id);
                var deleteData = context.Data.Find(deletePatient.DataId); /* Usuwanie kaskadowe - usuniecie danych osobowych => usuniecie pracownika */
                context.Data.Remove(deleteData);
                context.SaveChanges();
            }
        }

        public void EditPatient(PatientRow row)
        {
            var form = new PatientDetails(DetailsMode.Edit);
            using (var context = new ClinicDataEntities())
            {
                var patient = context.Patients.Find(row.Id);
                form.BindingSource = new List<Patients> { patient };
            }
            form.SetSpecificProperties();
            form.ShowDialog();
        }

        public List<PatientRow> Filter()
        {
            var parameters = new string[] { "OperationDate", "OperationId", "Priority", "Description" };
            var form = new FilterForm(parameters);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sqlFilter = form.ReturnFilterString();
                var sqlQuery = $"SELECT * FROM Patients {sqlFilter}";
                using (var context = new ClinicDataEntities())
                {
                    try
                    {
                        var entites = context.Database.SqlQuery<Patients>(sqlQuery).ToList();
                        var entityRows = new List<PatientRow>();
                        foreach (var obj in entites)
                        {
                            entityRows.Add(context.PatientRow.First(p => p.Id == obj.Id));
                        }
                        return entityRows;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, "Niepoprawne zapytanie filtrowania", "Błąd");
                    }
                }
            }
            return null;
        }

        public BindingSource RefreshPatients()
        {
            var bsMain = new BindingSource();
            using (var context = new ClinicDataEntities())
            {
                var patientList = context.PatientRow.ToList();
                bsMain.DataSource = typeof(PatientRow);
                bsMain.DataSource = patientList;
                return bsMain;
            }
        }

        public void SavePatient(Patients patient, Data patientData, Form1.DetailsMode Mode)
        {
            using (var context = new ClinicDataEntities())
            {
                if (Mode == DetailsMode.Add)
                {
                    patientData.BirthDate = DateTime.Parse(patientData.BirthDate.ToShortDateString());
                    patient.OperationDate = DateTime.Parse(patient.OperationDate.ToShortDateString());
                    context.Data.Add(patientData);
                    context.SaveChanges();  /* zapisywanie danych osobowych */

                    patient.DataId = patientData.Id;  /* przypisanie danych osobowych do pracownika */
                    context.Patients.Add(patient);
                }
                else
                {
                    context.Entry(patientData).State = System.Data.Entity.EntityState.Modified;
                    context.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(null, ex.Message, "Blad");
                }
            }
        }
    }
}
