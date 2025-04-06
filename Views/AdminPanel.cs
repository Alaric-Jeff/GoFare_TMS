using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPT_TMS_GoFare.Views
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void getClients()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("clientId");
            dataTable.Columns.Add("cardId");
            dataTable.Columns.Add("firstName");
            dataTable.Columns.Add("lastName");
            dataTable.Columns.Add("balance");
            dataTable.Columns.Add("cardStatus");
        }

        private void adminNavbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void goFareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AnalyticsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
