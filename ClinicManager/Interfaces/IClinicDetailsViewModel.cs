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
    interface IClinicDetailsViewModel
    {
        void SaveClinics(Clinics clinic, DetailsMode mode);
        void DeleteClinics(ClinicRow clinic);
        BindingSource RefreshClinics();
        List<ClinicRow> Filter();
        void EditClinic(ClinicRow row);
        void AddClinic();
        BindingSource GetOpinions(ClinicRow row);
        void AddOpinion();
        void Sort(DataGridView grid, BindingSource list);
        void ShowHierarchy(ClinicRow row);
        void MakeOrder();
        void SaveOrder(Orders order);
        void SaveOrderTools(OrdersTools order);
        void MakeOrderTool();
        void GetHighestMark(int clinicId);
    }
}
