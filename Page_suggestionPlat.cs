using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Page_suggestionPlat : TabPage
    {
        public Page_suggestionPlat() : base("suggestion des plat")
        {
            Connexion c = new Connexion();
            Famille famille = new Famille();
            Famille[] list  = famille.getDonnee(c);
            Famille mlay = list[2];
            Personne p = new Personne();
            DateTime date = new DateTime(2023,05,01);
            Random random = new Random();
            Sakafo temp = new Sakafo();
            // Personne[] present = mlay.getMembreFamille(c);
            
            for (int i = 0; i < 14; i++)
            {
                List<string> composant = new List<string>();
                    if(i == 5 || i == 6 || i == 7 || i == 12 || i == 13 || )
                {
                   
                }
                else
                {
                     string[] lh = {"legumeH1","legumeH2","legumeH3","legumeH4","legumeH5","legumeH6","legumeH7"};
                    composant.Add(lh[random.Next(0,lh.Length-1)]);
                }
                string[] lb = {"legumeB1","legumeB2","legumeB3","legumeB4","legumeB5","legumeB6","legumeB7"};
                composant.Add(lb[random.Next(0,lb.Length-1)]);
                string[] vb = {"ViandeB1","ViandeB2","ViandeB3","ViandeB4","ViandeB5","ViandeB6","ViandeB7"};
                composant.Add(vb[random.Next(0,vb.Length-1)]);
                string[] vr = {"ViandeR1","ViandeR2","ViandeR3","ViandeR4","ViandeR5","ViandeR6","ViandeR7"};
                composant.Add(vr[random.Next(0,vr.Length-1)]);
                string[] ab = {"abbat1","abbat2","abbat3","abbat4","abbat5","abbat6","abbat7"};
                composant.Add(ab[random.Next(0,ab.Length-1)]);
                string[] ac = {"accomp1","accomp2","accomp3","accomp4","accomp5","accomp6","accomp7"};
                composant.Add(ac[random.Next(0,ac.Length-1)]);

                string[] resultat = new string[composant.Count];
                resultat = composant.ToArray();
                string[] kaly = resultat;

                int y = 10;
                this.Controls.Add(new Label() { Text = $"jour {i}", Location = new Point(10+ 100*i, y) });
                y = y + 20;
                foreach (string sakafo in kaly)
                {
                    this.Controls.Add(new Label() { Text = sakafo, Location = new Point(10+ 100*i, y) });
                    y = y + 20;
                }
                y = 10;
            }
            
        }
    }
}