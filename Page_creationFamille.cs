using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Page_creationFamille : TabPage
    {
        public Page_creationFamille() : base("Creation famille")
        {
            this.Controls.Add(new Label() { Text = "Nom", Location = new Point(150, 10) });
            TextBox nomTextBox = new TextBox() { Location = new Point(150, 50) };
            this.Controls.Add(nomTextBox);

            Personne personne = new Personne();
            Connexion c = new Connexion();
            Personne[] personnes = personne.getSingle(c);
            CheckedListBox checkBox = new CheckedListBox();
            for (int i = 0; i < personnes.Length; i++)
            {
                checkBox.Items.Add(personnes[i].getNom(),false);
            }
            this.Controls.Add(checkBox);

            this.Controls.Add(new Label() { Text = "Salaire", Location = new Point(250, 10) });
            NumericUpDown pourcentageUpDown = new NumericUpDown() { Location = new Point(250, 50), Minimum = 10000, Maximum = 10000000 };
            this.Controls.Add(pourcentageUpDown);

            Button saveButton = new Button() { Text = "Creation famille", Location = new Point(150, 90) };
            saveButton.Click +=(sender, e) =>
            {
                double pourcentage = (double) pourcentageUpDown.Value;
                String nom = nomTextBox.Text;
                Famille famille = new Famille(null,nom,pourcentage);
                famille.insert(c);
                famille.setIdFamille(famille.getIdFamille(c));
                string message = "";
                for (int i = 0; i < personnes.Length; i++)
                {
                    if(checkBox.GetItemChecked(i))
                    {
                        MembreFamille membreFamille = new MembreFamille(famille.getIdFamille(),personnes[i].getIdPersonne());
                        membreFamille.insert(c);
                        message = message + " " + personnes[i].getNom() + " \n";
                    }
                }
                message = message + " sont dans " + famille.getNom();
                MessageBox.Show(message);
            };
            this.Controls.Add(saveButton);
        }
    }
}