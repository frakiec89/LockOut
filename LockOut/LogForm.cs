using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockOut
{
    public partial class LogForm : Form
    {

        private LockOutsController controller;
        public LogForm()
        {
            InitializeComponent();

        }

        public LogForm( ref LockOutsController controller) : this()
        {
            this.controller = controller;

            dataGridView1.DataSource = controller.LockOutcs.OrderBy(x => x.Date).ToList();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.LockOutcs.Where(t => t.Date >= DateTime.Now.AddMinutes(-5)).OrderBy(x => x.Date).ToList();
        }

        private void bt10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.LockOutcs.Where(t => t.Date >= DateTime.Now.AddMinutes(-10)).OrderBy(x => x.Date).ToList();
        }
    }
}
