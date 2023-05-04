using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Create a new TabControl
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // Create two new TabPage controls
            Page_insertPersonne tabPage1 = new Page_insertPersonne();
            Page_creationFamille tabPage3 = new Page_creationFamille();
            TabPage tabPage2 = new TabPage("Page 2");


            // Add some controls to the second TabPage
            tabPage2.Controls.Add(new Label() { Text = "This is page 2" });
            tabPage2.Controls.Add(new Button() { Text = "Go back to page 1", Dock = DockStyle.Top });
            tabPage2.Controls.Add(new CheckBox() { Dock = DockStyle.Fill });

            // Add the TabPages to the TabControl
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage3);
            tabControl.TabPages.Add(tabPage2);

            // Add the TabControl to the Form
            this.Controls.Add(tabControl);
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Code to handle form submission
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Code to reset form fields
        }

        private void buttonViewStats_Click(object sender, EventArgs e)
        {
            // Code to display statistics
        }
    }
}

// namespace Sakafo_isan_andro;

// public partial class Form1 : Form
// {
//     public Form1()
//     {
//         InitializeComponent();
//     }
// }
