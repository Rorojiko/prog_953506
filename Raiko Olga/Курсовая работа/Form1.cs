using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    { int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            WebBrowser web = new WebBrowser();
            web.Visible = true;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.DocumentCompleted += Web_DocumentCompleted;
            tabControl1.TabPages.Add("New Page");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i++;
        }

        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle + "TheBrauzer";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != null)
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
            else
            {

            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
            else { Application.Exit(); }
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoHome();
        }
        
    }
}
