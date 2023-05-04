using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class Interdiction
    {
        private string idInterdiction;
        private string idSanter;
        private double maximum;

        public Interdiction(string idInterdiction, string idSanter, double maximum)
        {
            this.setIdInterdiction(idInterdiction);
            this.setIdSanter(idSanter);
            this.setMaximum(maximum);
        }

        public Interdiction()
        {
        }

        public string getIdInterdiction()
        {
            return idInterdiction;
        }

        public void setIdInterdiction(string idInterdiction)
        {
            this.idInterdiction = idInterdiction;
        }

        public string getidSanter()
        {
            return idSanter;
        }

        public void setIdSanter(string idSanter)
        {
            this.idSanter = idSanter;
        }

        public double getMaximum()
        {
            return maximum;
        }

        public void setMaximum(double maximum)
        {
            this.maximum = maximum;
        }

        public Interdiction[] getDonnee(Connexion c)
        {
            List<Interdiction> InterdictionList = new List<Interdiction>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM Interdiction";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Interdiction temp = new Interdiction(data.GetString(0), data.GetString(1), data.GetDouble(2));
                InterdictionList.Add(temp);
            }
            Interdiction[] InterdictionArray = new Interdiction[InterdictionList.Count];
            con.Close();
            InterdictionArray = InterdictionList.ToArray();
            return InterdictionArray;
        }

        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO Interdiction (idSanter, idTypeInterdiction) VALUES ('@idSanter', '@idTypeInterdiction')";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@idSanter", this.getidSanter());
            cmd.Parameters.AddWithValue("@idTypeInterdiction", this.getMaximum());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
