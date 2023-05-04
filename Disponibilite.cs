using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class Disponibilite
    {
        private string idDisponibilite;
        private string idEmploiDuTemp;
        private DateTime leDate;
        private int disponibilite;

        public Disponibilite(string idDisponibilite, string idEmploiDuTemp, DateTime leDate, int disponibilite)
        {
            this.setIdDisponibilite(idDisponibilite);
            this.setIdEmploiDuTemp(idEmploiDuTemp);
            this.setLeDate(leDate);
            this.setDisponibilite(disponibilite);
        }

        public Disponibilite()
        {
        }

        public string getIdDisponibilite()
        {
            return idDisponibilite;
        }

        public void setIdDisponibilite(string idDisponibilite)
        {
            this.idDisponibilite = idDisponibilite;
        }

        public string getIdEmploiDuTemp()
        {
            return idEmploiDuTemp;
        }

        public void setIdEmploiDuTemp(string idEmploiDuTemp)
        {
            this.idEmploiDuTemp = idEmploiDuTemp;
        }

        public DateTime getLeDate()
        {
            return leDate;
        }

        public void setLeDate(DateTime leDate)
        {
            this.leDate = leDate;
        }

        public int getDisponibilite()
        {
            return disponibilite;
        }

        public void setDisponibilite(int disponibilite)
        {
            this.disponibilite = disponibilite;
        }

        public Disponibilite[] getDonnee(Connexion c)
        {
            List<Disponibilite> disponibilites = new List<Disponibilite>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM Disponibilite";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Disponibilite temp = new Disponibilite(data.GetString(0), data.GetString(1), data.GetDateTime(2), data.GetInt32(3));
                disponibilites.Add(temp);
            }
            Disponibilite[] disponibiliteArray = new Disponibilite[disponibilites.Count];
            con.Close();
            disponibiliteArray = disponibilites.ToArray();
            return disponibiliteArray;
        }

        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO Disponibilite (idEmploiDuTemp, leDate, disponibilite) VALUES ('@idEmploiDuTemp', '@leDate', @disponibilite)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@idEmploiDuTemp", this.getIdEmploiDuTemp());
            cmd.Parameters.AddWithValue("@leDate", this.getLeDate());
            cmd.Parameters.AddWithValue("@disponibilite", this.getDisponibilite());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
