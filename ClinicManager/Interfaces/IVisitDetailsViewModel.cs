﻿using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager.Interfaces
{
    interface IVisitDetailsViewModel
    {
        void SaveVisit(Registrations visit, DetailsMode mode, PatientRow patient);
        void DeleteVisit(RegistrationRow visit);
        BindingSource RefreshVisits();
        List<RegistrationRow> Filter();
        void EditRegistration(RegistrationRow row);
        void AddRegistration();
        void GetSchedule();
        void Sort(DataGridView grid, BindingSource list);
        void AcceptVisit(RegistrationRow row);
        void RealizeVisit(RegistrationRow row);
        void UndoVisit(RegistrationRow row);
        void CheckRegistrationStatus(DataGridView gridView);
        void AddRegistrationForClient(PatientRow client);
    }
}
