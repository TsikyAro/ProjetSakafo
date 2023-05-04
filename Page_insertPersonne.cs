using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Page_insertPersonne : TabPage
    {
        public Page_insertPersonne() : base("insert personne")
        {
            // Create and position the labels and input controls
            Label nomLabel = new Label() { Text = "Nom:", Location = new Point(10, 20), AutoSize = true };
            TextBox nomTextBox = new TextBox() { Location = new Point(150, 20), Width = 200 };
            Label dateNaissanceLabel = new Label() { Text = "Date de naissance:", Location = new Point(10, 60), AutoSize = true };
            DateTimePicker dateNaissancePicker = new DateTimePicker() { Location = new Point(150, 60), Width = 200 };
            Label santerLabel = new Label() { Text = "Santer:", Location = new Point(10, 100), AutoSize = true };
            ComboBox santerComboBox = new ComboBox() { Location = new Point(150, 100), Width = 200 };
            Label pourcentageLabel = new Label() { Text = "Pourcentage:", Location = new Point(10, 140), AutoSize = true };
            NumericUpDown pourcentageUpDown = new NumericUpDown() { Location = new Point(150, 140), Width = 200, Minimum = 0, Maximum = 100 };
            Button saveButton = new Button() { Text = "Enregistrer", Location = new Point(150, 200), Width = 100 };

            // Populate the Santer combo box with options
            Santer santer = new Santer();
            Connexion c = new Connexion();
            Santer[] santers = santer.getDonnee(c);
            foreach (Santer sante in santers)
            {
                santerComboBox.Items.Add(sante.getNom());
            }

            // Add the controls to the form
            Controls.AddRange(new Control[] { nomLabel, nomTextBox, dateNaissanceLabel, dateNaissancePicker, santerLabel, santerComboBox, pourcentageLabel, pourcentageUpDown, saveButton });

            // Save button click event handler
            saveButton.Click += (sender, e) =>
            {
                // Retrieve user input
                string nom = nomTextBox.Text;
                string dateNaissance = dateNaissancePicker.Value.ToShortDateString();
                string santer = santerComboBox.Text;
                int index = santerComboBox.SelectedIndex;
                string pourcentage = pourcentageUpDown.Value.ToString();

                // Validate user input
                string errorMessage = "";
                if (string.IsNullOrWhiteSpace(nom))
                {
                    errorMessage += "- Veuillez saisir un nom valide.\n";
                }
                if (DateTime.Today < dateNaissancePicker.Value.Date)
                {
                    errorMessage += "- La date de naissance doit être antérieure à la date d'aujourd'hui.\n";
                }
                if (index == -1)
                {
                    errorMessage += "- Veuillez sélectionner une option pour le santer.\n";
                }
                if (string.IsNullOrWhiteSpace(pourcentage))
                {
                    errorMessage += "- Veuillez saisir un pourcentage valide.\n";
                }

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    MessageBox.Show("Erreurs:\n" + errorMessage, "Erreurs de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string message="";
                // Save the data to the database
                try
                {
                    DateTime date = DateTime.Parse(dateNaissance);
                    Connexion con = new Connexion();
                    Personne personne = new Personne(null,nom,date);
                    personne.insertWithEtat(con,santers[index].getIdSanter(),int.Parse(pourcentage));

                    // Display success message
                     message = $"Nom: {nom}\nDate de Naissance: {date}\nSanter: {santer}\nPourcentage: {pourcentage}%\nInsert";

                    message = $"Nom: {nom}\nDate de Naissance: {date}\nSanter: {santer}\nPourcentage: {pourcentage}%\nInsertion reussi";
                }
                catch (System.Exception)
                {
                    message = "Erreu se reproduit";
                    throw;
                }
                
                MessageBox.Show(message);
            };
            this.Controls.Add(saveButton);
        }
    }
}