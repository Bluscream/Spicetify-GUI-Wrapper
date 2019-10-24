using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spicetify_GUI_Wrapper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void FillApps(bool force = false)
        {
            var apps = Program.Spicetify.Apps;
            force = force || apps is null || apps.Count < 1;
            if (force) apps = Program.Spicetify.LoadApps(); // Proper timeouts
            lst_apps.Items.Clear();
            foreach (var app in apps) lst_apps.Items.Add(app, app.Enabled);
            if (force)
            {
                Logger.Log("Loaded {0} apps from {1}.", apps.Count, Program.Spicetify.AppsDirectory.FullName.Quote()); Logger.Trace(apps.ToJson(false));
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Text)
            {
                case "Apps":
                    FillApps();
                    break;
            }
        }
    }
}