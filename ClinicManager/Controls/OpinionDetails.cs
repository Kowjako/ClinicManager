using ClinicManager.DataAccessLayer;
using ClinicManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace ClinicManager.Controls
{
    public partial class OpinionDetails : Form
    {
        private byte Mark;
        private StaticDictionaries Dictionaries;
        private PatientRow loggedUser;
        public OpinionDetails()
        {
            InitializeComponent();
            Dictionaries = new StaticDictionaries();

            if((Form1.Rights.dataId as int?).HasValue)
            {
                loggedUser = Dictionaries.PatientList.Value.Values.First(p => p.Id == p.GetIdByDataId((Form1.Rights.dataId as int?).Value));
                bsPatients.DataSource = new List<PatientRow> { loggedUser };

                bsClinics.DataSource = loggedUser.GetVisitedClinics();
            }
            
        }

        private void star1_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                ((PictureBox)(this.Controls.Find($"star{i}", true)[0])).Image = (Image)Resources.unstar;
            }
            var star = ((PictureBox)sender);
            for (int i = 1; i <= Int32.Parse(star.Name.Substring(4,1)); i++)
            {
                ((PictureBox)(this.Controls.Find($"star{i}", true)[0])).Image = (Image)Resources.star;
            }
        }

        private void star1_Click(object sender, EventArgs e)
        {
            star1.MouseEnter -= star1_MouseEnter;
            star2.MouseEnter -= star1_MouseEnter;
            star3.MouseEnter -= star1_MouseEnter;
            star4.MouseEnter -= star1_MouseEnter;
            star5.MouseEnter -= star1_MouseEnter;

            Mark = byte.Parse(((PictureBox)sender).Name.Substring(4, 1));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(Mark == 0)
            {
                MessageBox.Show(null, "Ocena musi byc co najmniej jeden", "Blad");
            }
            else
            {
                if (loggedUser.ExistsOpinionForClinic((clinicBox.SelectedItem as ClinicRow).Id))
                {
                    MessageBox.Show(null, "Wystawiles juz ocene dla tej przychodni", "Blad");
                }
                else
                {
                    var newOpinion = new Opinions();
                    newOpinion.Mark = Mark;
                    newOpinion.ClinicId = (clinicBox.SelectedItem as ClinicRow).Id;
                    try
                    {
                        using (var context = new ClinicDataEntities())
                        {
                            newOpinion.DataId = context.Data.Find((context.Patients.Find((patientBox.SelectedItem as PatientRow).Id)).DataId).Id;
                            context.Opinions.Add(newOpinion);
                            context.SaveChanges();
                        }
                    }
                    catch (DbUpdateException)
                    {
                        MessageBox.Show(null, "Nie udalo sie wystawic opinii", "Blad");
                    }
                }
            }
            this.Close();
        }
    }
}
