using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class Plat
    {
        private string idPlat;
        private string nom;

        public Plat(string idPlat, string nom)
        {
            this.setIdPlat(idPlat);
            this.setNom(nom);
        }

        public Plat()
        {
        }

        public string getIdPlat()
        {
            return idPlat;
        }

        public void setIdPlat(string idPlat)
        {
            this.idPlat = idPlat;
        }

        public string getNom()
        {
            return nom;
        }

        public void setNom(string nom)
        {
            this.nom = nom;
        }

        public Plat[] getDonnee(Connexion c)
        {
            List<Plat> plats = new List<Plat>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM Plat";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Plat temp = new Plat(data.GetString(0), data.GetString(1));
                plats.Add(temp);
            }
            Plat[] platArray = new Plat[plats.Count];
            con.Close();
            platArray = plats.ToArray();
            return platArray;
        }

        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO Plat (nom) VALUES ('@nom')";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@nom", this.getNom());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
