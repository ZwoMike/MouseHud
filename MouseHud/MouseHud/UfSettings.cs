using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHud
{
    public partial class UfSettings : Form
    {
        public UfSettings()
        {
            InitializeComponent();
            
            this.TbFrameWidth.Text = Properties.Settings.Default.FrameWidth.ToString();
            this.TbFrameHeight.Text = Properties.Settings.Default.FrameHeight.ToString();
            this.TbFileName.Text = Properties.Settings.Default.BasicFileName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FrameWidth = Int32.Parse(this.TbFrameWidth.Text);
            Properties.Settings.Default.FrameHeight = Int32.Parse(this.TbFrameHeight.Text);
            Properties.Settings.Default.BasicFileName = this.TbFileName.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
