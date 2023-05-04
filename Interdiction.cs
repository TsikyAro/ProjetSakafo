using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class Interdiction
    {
        private string idInterdiction;
        private string idSanter;
        private string idTypeSakafo;
        private double maximum;

        public Interdiction(string idInterdiction, string idSanter, string idTypeSakafo, double maximum)
        {
            this.setIdInterdiction(idInterdiction);
            this.setIdSanter(idSanter);
            this.setIdTypeSakafo(idTypeSakafo);
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

        public string getIdSanter()
        {
            return idSanter;
        }

        public void setIdSanter(string idSanter)
        {
            this.idSanter = idSanter;
        }
        public string getIdTypeSakafo()
        {
            return idTypeSakafo;
        }

        public void setIdTypeSakafo(string idSanter)
        {
            this.idTypeSakafo = idSanter;
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
                Interdiction temp = new Interdiction(data.GetString(0), data.GetString(1),data.GetString(2), data.GetDouble(3));
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
            String sql = "INSERT INTO Interdiction (idSanter, idTypeSakafo,maximun) VALUES (@idSanter, @idTypeSakafo,@maximum)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@idSanter", this.getIdSanter());
            cmd.Parameters.AddWithValue("@idTypeSakafo", this.getIdTypeSakafo());
            cmd.Parameters.AddWithValue("@maximum", this.getMaximum());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
