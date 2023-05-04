using System;
using System.Windows.Forms;

namespace Sakafo_isan_andro
{
    public partial class Page_insertPersonne : TabPage
    {
        public Page_insertPersonne() : base("insert personne")
        {
            this.Controls.Add(new Label() { Text = "Nom", Location = new Point(10, 10) });
            TextBox nomTextBox = new TextBox() { Location = new Point(200, 10) };
            this.Controls.Add(nomTextBox);

            this.Controls.Add(new Label() { Text = "Date de Naissance", Location = new Point(10, 50) });
            DateTimePicker dateNaissancePicker = new DateTimePicker() { Location = new Point(200, 50) };
            this.Controls.Add(dateNaissancePicker);

            Santer santerr = new Santer();
            Connexion c = new Connexion();
            Santer[] santers = santerr.getDonnee(c);
            this.Controls.Add(new Label() { Text = "Santer", Location = new Point(10, 90) });
            ComboBox santerComboBox = new ComboBox() { Location = new Point(200, 90) };
            foreach (var santer in santers)
            {
                santerComboBox.Items.Add(santer.getNom());
            }
            santerComboBox.ValueMember = "Text";
            santerComboBox.SelectedIndex = 0;
            this.Controls.Add(santerComboBox);

            this.Controls.Add(new Label() { Text = "Pourcentage", Location = new Point(10, 130) });
            NumericUpDown pourcentageUpDown = new NumericUpDown() { Location = new Point(200, 130), Minimum = 0, Maximum = 100 };
            this.Controls.Add(pourcentageUpDown);
        
            Button saveButton = new Button() { Text = "Save", Location = new Point(150, 170) };
            saveButton.Click +=(sender, e) =>
            {
                string nom = nomTextBox.Text;
                string dateNaissance = dateNaissancePicker.Value.ToShortDateString();
                string santer = santerComboBox.Text;
                int index = santerComboBox.SelectedIndex;
                string pourcentage = pourcentageUpDown.Value.ToString();
                string message = "";
                try
                {
                    DateTime date = DateTime.Parse(dateNaissance);
                    Connexion con = new Connexion();
                    Personne personne = new Personne(null,nom,date);
                    personne.insertWithEtat(con,santers[index].getIdSanter(),int.Parse(pourcentage));
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