using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test.Form1;

namespace ClinicManager.Controls
{
    public partial class UnitDetails : Form
    {
        private AddValues Mode;
        private StaticDictionaries Dictionaries;
        public UnitDetails(AddValues mode)
        {
            InitializeComponent();
            Dictionaries = new StaticDictionaries();
            Mode = mode;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(Mode == AddValues.Unit)
            {
                Dictionaries.AddUnit(typeName.Text);
            }
            if(Mode == AddValues.Operation)
            {
                Dictionaries.AddOperationType(typeName.Text);
            }
            this.Close();
        }
    }
}
