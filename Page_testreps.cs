using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Page_testreps: TabPage
    {
        public Page_testreps() : base("test")
        {
            Connexion c = new Connexion();
            Sakafo kaly = new Sakafo();
            Sakafo[][] val = kaly.getallSakafoParCategorie(c);
            // int d = 1;
            // Sakafo[] reps = kaly.compoPlat(val,d);
            // string va = reps.Length.ToString();
            // MessageBox.Show(va);
            this.Controls.Add(new Label() { Text = "hello", Location = new Point(10, 10) });
        }
    }
}