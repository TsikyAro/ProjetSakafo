using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            Page_insertPersonne tabPage1 = new Page_insertPersonne();
            Page_creationFamille tabPage3 = new Page_creationFamille();
            Page_suggestionPlat tabPage2 = new Page_suggestionPlat();
            Page_testreps tabPage4 = new Page_testreps();

            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage3);
            tabControl.TabPages.Add(tabPage2);
            tabControl.TabPages.Add(tabPage4);

            this.Controls.Add(tabControl);
        }
    }
}
