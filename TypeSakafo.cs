using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class TypeSakafo
    {
        private string idTypeSakafo;
        private string nom;

        public TypeSakafo(string idTypeSakafo, string nom)
        {
            this.setIdTypeSakafo(idTypeSakafo);
            this.setNom(nom);
        }

        public TypeSakafo()
        {
        }

        public string getIdTypeSakafo()
        {
            return idTypeSakafo;
        }

        public void setIdTypeSakafo(string idTypeSakafo)
        {
            this.idTypeSakafo = idTypeSakafo;
        }

        public string getNom()
        {
            return nom;
        }

        public void setNom(string nom)
        {
            this.nom = nom;
        }

        public TypeSakafo[] getDonnee(Connexion c)
        {
            List<TypeSakafo> typesakafo = new List<TypeSakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM TypeSakafo";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                TypeSakafo temp = new TypeSakafo(data.GetString(0), data.GetString(1));
                typesakafo.Add(temp);
            }
            TypeSakafo[] typesakafoArray = new TypeSakafo[typesakafo.Count];
            con.Close();
            typesakafoArray = typesakafo.ToArray();
            return typesakafoArray;
        }

        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO TypeSakafo (nom) VALUES ('@nom')";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@nom", this.getNom());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
