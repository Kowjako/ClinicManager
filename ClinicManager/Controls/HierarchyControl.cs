using ClinicManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager.Controls
{
    public partial class HierarchyControl : Form
    {
        public HierarchyControl()
        {
            InitializeComponent();
        }

        public void SetHierarchy(ClinicRow row)
        {
            var mainNode = new TreeNode();
            mainNode.Name = "workersNode";
            mainNode.Text = "Pracownicy";
            clinicTree.Nodes.Add(mainNode);

            var managerNode = new TreeNode();
            managerNode.Text = "Kierownik";

            var smallEmployee = new TreeNode();
            smallEmployee.Text = "Młodszy lekarz";

            var employee = new TreeNode();
            employee.Text = "Lekarz";

            var headEmployee = new TreeNode();
            headEmployee.Text = "Główny lekarz";

            clinicTree.Nodes[0].Nodes.Add(managerNode);
            clinicTree.Nodes[0].Nodes.Add(headEmployee);
            clinicTree.Nodes[0].Nodes.Add(employee);
            clinicTree.Nodes[0].Nodes.Add(smallEmployee);

            using (var context = new ClinicDataEntities())
            {
                var employees = context.Employees.Where(p => p.ClinicId == row.Id);
                var employeesRow = context.EmployeeRow.AsEnumerable().Where(p => employees.Any(x => x.Id == p.Id));
                foreach (var emp in employeesRow)
                {
                    if (emp.Stanowisko == "Kierownik przychodni") clinicTree.Nodes[0].Nodes[0].Nodes.Add(new TreeNode() { Text = emp.Lekarz });
                    if (emp.Stanowisko == "Glowny lekarz") clinicTree.Nodes[0].Nodes[1].Nodes.Add(new TreeNode() { Text = emp.Lekarz });
                    if (emp.Stanowisko == "Lekarz") clinicTree.Nodes[0].Nodes[2].Nodes.Add(new TreeNode() { Text = emp.Lekarz });
                    if (emp.Stanowisko == "Mlodszy lekarz") clinicTree.Nodes[0].Nodes[3].Nodes.Add(new TreeNode() { Text = emp.Lekarz });
                }
            }
            
        }
    }
}
