using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro
{
    public class Sakafo
    {
        private string idSakafo;
        private string nom;
        private string idTypeSakafo;
        private double prix;
        public  Sakafo[][] getallSakafoParCategorie(Connexion c){
            Sakafo[] accompanement = this.accompanement(c);
            Sakafo[] legumebas = this.legumeBas(c);
            Sakafo[] legumehaut = this.legumeHaut(c);
            Sakafo[] viandeBlanche = this.viandeBlanche(c);
            Sakafo[] viandeRouge = this.viandeRouge(c);
            Sakafo[][] liste = {accompanement,legumebas,legumehaut,viandeBlanche,viandeRouge};
            return liste;
        }
        public  Sakafo[] compoPlat(Sakafo[][]listesakafo,int day){
            Sakafo[] proposition = new Sakafo[5];
            Console.WriteLine(day % listesakafo[0].Length);
            proposition[0]=listesakafo[0][day % listesakafo[0].Length];
            proposition[1]=listesakafo[1][day % listesakafo[1].Length];
            proposition[2]=listesakafo[2][day%listesakafo[2].Length];
            proposition[3]=listesakafo[3][day%listesakafo[3].Length];
            proposition[4]=listesakafo[4][day%listesakafo[4].Length];
            return proposition;
        }
        public Sakafo[] accompanement(Connexion c){
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM AcC";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }
        public Sakafo[] legumeBas(Connexion c){
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM LegumeB";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }
        public Sakafo[] legumeHaut(Connexion c){
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM LegumeH";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }
        public Sakafo[] abbat(Connexion c)
        {
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM AbB";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }
        public Sakafo[] viandeRouge(Connexion c)
        {
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM ViandeR";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }
        public Sakafo[] viandeBlanche(Connexion c){
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM ViandeB";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }
        public Sakafo[] getDonnee(Connexion c) {
            List<Sakafo> sakafoList = new List<Sakafo>();
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "SELECT * FROM sakafo";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Sakafo temp = new Sakafo(data.GetString(0), data.GetString(1), data.GetString(2), data.GetDouble(3));
                sakafoList.Add(temp);
            }
            Sakafo[] sakafoArray = new Sakafo[sakafoList.Count];
            con.Close();
            sakafoArray = sakafoList.ToArray();
            return sakafoArray;
        }        
        public void insert(Connexion c)
        {
            SqlConnection con = c.connexion();
            con.Open();
            String sql = "INSERT INTO sakafo (nom, idTypeSakafo,prix) VALUES (@nom, @idTypeSakafo,@prix)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@nom", this.getNom());
            cmd.Parameters.AddWithValue("@idTypeSakafo", this.getIdTypeSakafo());
            cmd.Parameters.AddWithValue("@prix", this.getPrix());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Sakafo(string idSakafo, string nom, string idTypeSakafo,double prix)
        {
            this.setIdSakafo(idSakafo);
            this.setNom(nom);
            this.setIdTypeSakafo(idTypeSakafo);
            this.setPrix(prix);
        }

        public Sakafo()
        {
        }
        public double getPrix(){
            return prix;
        } 
        public void setPrix(double prix){
            this.prix = prix;
        }
        public string getIdSakafo()
        {
            return idSakafo;
        }

        public void setIdSakafo(string idSakafo)
        {
            this.idSakafo = idSakafo;
        }

        public string getNom()
        {
            return nom;
        }

        public void setNom(string nom)
        {
            this.nom = nom;
        }

        public string getIdTypeSakafo()
        {
            return idTypeSakafo;
        }

        public void setIdTypeSakafo(string idTypeSakafo)
        {
            this.idTypeSakafo = idTypeSakafo;
        }
    }
}
