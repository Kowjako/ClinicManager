﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManager.DataAccessLayer;

namespace ClinicManager
{
    public partial class ClinicDetails : Form
    {
        public ClinicDetails()
        {
            InitializeComponent();
        }

        public List<Clinics> BindingSource
        {
            set { _bsDetails.DataSource = value; }
        }
    }
}
