using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class MembreFamille
    {
        private string idFamille;
        private string idPersonne;

        public MembreFamille(string idFamille, string idPersonne)
        {
            this.setIdFamille(idFamille);
            this.setIdPersonne(idPersonne);
        }

        public MembreFamille()
        {
        }

        public string getIdFamille()
        {
            return idFamille;
        }

        public void setIdFamille(string idFamille)
        {
            this.idFamille = idFamille;
        }

        public string getIdPersonne()
        {
            return idPersonne;
        }

        public void setIdPersonne(string idPersonne)
        {
            this.idPersonne = idPersonne;
        }

        public MembreFamille[] getDonnee(Connexion c)
        {
            List<MembreFamille> MembreFamilleList = new List<MembreFamille>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM MembreFamille";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                MembreFamille temp = new MembreFamille(data.GetString(0), data.GetString(1));
                MembreFamilleList.Add(temp);
            }
            MembreFamille[] MembreFamilleArray = new MembreFamille[MembreFamilleList.Count];
            con.Close();
            MembreFamilleArray = MembreFamilleList.ToArray();
            return MembreFamilleArray;
        }

        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO MembreFamille (idFamille, idPersonne) VALUES (@idFamille, @idPersonne)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@idFamille", this.getIdFamille());
            cmd.Parameters.AddWithValue("@idPersonne", this.getIdPersonne());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
