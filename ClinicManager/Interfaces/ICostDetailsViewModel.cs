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

    interface ICostDetailsViewModel
    {
        void SaveCost(Costs cost, DetailsMode mode);
        void DeleteCost(CostRow cost);
        BindingSource RefreshCosts();
        List<CostRow> Filter();
        void EditCost(CostRow row);
        void AddCost();
        void AddCost(ProducentRow producent);
        void Sort(DataGridView grid, BindingSource list);
        BindingSource GetCheapest();
        BindingSource GetFastest();
        void CheckCurrencyFormat(DataGridView grid, bool isCheapest = false, bool isFastest = false);
    }
}
