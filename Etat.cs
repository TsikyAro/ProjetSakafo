using System.Data.SqlClient;
namespace Sakafo_isan_andro
{
    public class Etat
    {
        private string idEtat;
        private string idSanter;
        private string idPersonne;
        private int pourcentage;

        public Etat(string idEtat, string idSanter,string idPersonne, int pourcentage)
        {
            this.setIdEtat(idEtat);
            this.setIdSanter(idSanter);
            this.setIdPersonne(idPersonne);
            this.setPourcentage(pourcentage);
        }

        public Etat()
        {
        }
        public void setIdPersonne(string id)
        {
            this.idPersonne = id;
        }
        public string getIdPersonne()
        {
            return this.getIdPersonne();
        }

        public string getIdEtat()
        {
            return idEtat;
        }

        public void setIdEtat(string idEtat)
        {
            this.idEtat = idEtat;
        }

        public string getIdSanter()
        {
            return idSanter;
        }

        public void setIdSanter(string idSanter)
        {
            this.idSanter = idSanter;
        }

        public int getPourcentage()
        {
            return pourcentage;
        }

        public void setPourcentage(int pourcentage)
        {
            this.pourcentage = pourcentage;
        }
        public void insert(Connexion c)
        {
            using (SqlConnection con = c.connexion())
            {
                con.Open();
                string sql = "INSERT INTO Etat (idSante, idPersonne, pourcentage) VALUES (@idSante, @idPersonne, @pourcentage)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@idSante", this.getIdSanter());
                    cmd.Parameters.AddWithValue("@idPersonne", this.getIdPersonne());
                    cmd.Parameters.AddWithValue("@pourcentage", this.getPourcentage());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        // public void insert(Connexion c)
        // {
        //     SqlConnection con = c.connexion();
        //     con.Open();
        //     String sql = "INSERT INTO Etat (idSanter, idPersonne, pourcentage) VALUES (@idSanter, @idPersonne, @pourcentage)";
        //     SqlCommand cmd = new SqlCommand(sql,con);
        //     cmd.Parameters.AddWithValue("@idSanter", this.getIdSanter());
        //     cmd.Parameters.AddWithValue("@idPersonne", this.getIdPersonne());
        //     cmd.Parameters.AddWithValue("@pourcentage", this.getPourcentage());
        //     cmd.ExecuteNonQuery();
        //     con.Close();
        // }
        public Etat[] getDonnee(Connexion c)
        {
            List<Etat> etats = new List<Etat>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM Etat";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                string idEtat = data.GetString(0);
                string idSanter = data.GetString(1);
                string idPersonne = data.GetString(2);
                int pourcentage = data.GetInt32(3);
                Etat temp = new Etat(idEtat, idSanter, idPersonne, pourcentage);
                etats.Add(temp);
            }
            Etat[] etatArray = new Etat[etats.Count];
            con.Close();
            etatArray = etats.ToArray();
            return etatArray;
        }
    }
}
