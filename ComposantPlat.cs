using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class ComposantPlat
    {
        private string idComposantPlat;
        private string idPlat;
        private string idSakafo;

        public ComposantPlat(string idComposantPlat, string idPlat, string idSakafo)
        {
            this.setIdComposantPlat(idComposantPlat);
            this.setIdPlat(idPlat);
            this.setIdSakafo(idSakafo);
        }

        public ComposantPlat()
        {
        }

        public string getIdComposantPlat()
        {
            return idComposantPlat;
        }

        public void setIdComposantPlat(string idComposantPlat)
        {
            this.idComposantPlat = idComposantPlat;
        }

        public string getIdPlat()
        {
            return idPlat;
        }

        public void setIdPlat(string idPlat)
        {
            this.idPlat = idPlat;
        }

        public string getIdSakafo()
        {
            return idSakafo;
        }

        public void setIdSakafo(string idSakafo)
        {
            this.idSakafo = idSakafo;
        }

        public ComposantPlat[] getDonnee(Connexion c)
        {
            List<ComposantPlat> ComposantPlatList = new List<ComposantPlat>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM ComposantPlat";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                ComposantPlat temp = new ComposantPlat(data.GetString(0), data.GetString(1), data.GetString(2));
                ComposantPlatList.Add(temp);
            }
            ComposantPlat[] ComposantPlatArray = new ComposantPlat[ComposantPlatList.Count];
            con.Close();
            ComposantPlatArray = ComposantPlatList.ToArray();
            return ComposantPlatArray;
        }

        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO ComposantPlat (idPlat, idSakafo) VALUES ('@idPlat', '@idSakafo')";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@idPlat", this.getIdPlat());
            cmd.Parameters.AddWithValue("@idSakafo", this.getIdSakafo());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
