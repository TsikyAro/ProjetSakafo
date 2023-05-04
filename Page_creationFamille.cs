using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Page_creationFamille : TabPage
    {
        public Page_creationFamille() : base("Creation famille")
        {
            // Label for "Nom"
            Label nomLabel = new Label()
            {
                Text = "Nom",
                Location = new Point(150, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            this.Controls.Add(nomLabel);

            // TextBox for name input
            TextBox nomTextBox = new TextBox()
            {
                Location = new Point(150, 40),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TabIndex = 0
            };
            this.Controls.Add(nomTextBox);

            // CheckedListBox for selecting members
            CheckedListBox memberCheckedListBox = new CheckedListBox()
            {
                Location = new Point(150, 80),
                Size = new Size(200, 150),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TabIndex = 1
            };

            // Load members from database
            Personne personne = new Personne();
            Connexion c = new Connexion();
            Personne[] personnes = personne.getSingle(c);
            for (int i = 0; i < personnes.Length; i++)
            {
                memberCheckedListBox.Items.Add(personnes[i].getNom(), false);
            }

            this.Controls.Add(memberCheckedListBox);

            // Label for "Salaire"
            Label salaireLabel = new Label()
            {
                Text = "Salaire",
                Location = new Point(150, 240),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                TabIndex = 2
            };
            this.Controls.Add(salaireLabel);

            // NumericUpDown for salary input
            NumericUpDown salaireNumericUpDown = new NumericUpDown()
            {
                Location = new Point(150, 270),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Minimum = 10000,
                Maximum = 10000000,
                TabIndex = 3
            };
            this.Controls.Add(salaireNumericUpDown);

            // Button for creating family
            Button createFamilyButton = new Button()
            {
                Text = "Créer une famille",
                Location = new Point(150, 310),
                Size = new Size(200, 35),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                TabIndex = 4
            };
            this.Controls.Add(createFamilyButton);

            // Click event for creating family
            createFamilyButton.Click += (sender, e) =>
            {
                // Get values from UI controls
                string nom = nomTextBox.Text.Trim();
                double pourcentage = (double)salaireNumericUpDown.Value;

                if (nom == string.Empty)
                {
                    MessageBox.Show("Le nom de la famille est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert new family into database
                Famille famille = new Famille(null, nom, pourcentage);
                famille.insert(c);
                famille.setIdFamille(famille.getIdFamille(c));

                // Insert checked members into MembreFamille table
                string message = "";
                for (int i = 0; i < personnes.Length; i++)
                {
                    if (memberCheckedListBox.GetItemChecked(i))
                    {
                        MembreFamille membreFamille = new MembreFamille(famille.getIdFamille(), personnes[i].getIdPersonne());
                        membreFamille.insert(c);
                        message = message + " " + personnes[i].getNom() + " \n";
                    }
                }
                message = message + " sont dans " + famille.getNom();
                MessageBox.Show(message);
            };
            this.Controls.Add(createFamilyButton);
        }
    }
}