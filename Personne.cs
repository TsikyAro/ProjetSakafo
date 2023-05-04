using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sakafo_isan_andro;
public class Personne
{
    private string idPersonne;
    private string nom;
    private DateTime dateDeNaissance;

    public Personne(string idPersonne, string nom, DateTime dateDeNaissance)
    {
        this.setIdPersonne(idPersonne);
        this.setNom(nom);
        this.setDateDeNaissance(dateDeNaissance);
    }

    public Personne()
    {
    }

    public string getIdPersonne()
    {
        return idPersonne;
    }

    public void setIdPersonne(string idPersonne)
    {
        this.idPersonne = idPersonne;
    }

    public string getNom()
    {
        return nom;
    }

    public void setNom(string nom)
    {
        this.nom = nom;
    }

    public DateTime getDateDeNaissance()
    {
        return dateDeNaissance;
    }

    public void setDateDeNaissance(DateTime dateDeNaissance)
    {
        this.dateDeNaissance = dateDeNaissance;
    }
    public Personne[] getSingle(Connexion c)
    {
        List<Personne> personnes = new List<Personne>();
        SqlConnection con = c.connexion();
        con.Open();
        String sql = "SELECT * FROM single";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        while (data.Read())
        {
            Personne temp = new Personne(data.GetString(0), data.GetString(1), data.GetDateTime(2));
            personnes.Add(temp);
        }
        Personne[] personnesArray = new Personne[personnes.Count];
        con.Close();
        personnesArray = personnes.ToArray();
        return personnesArray;
    }
    public Personne[] getDonnee(Connexion c)
    {
        List<Personne> personnes = new List<Personne>();
        SqlConnection con = c.connexion();
        con.Open();
        String sql = "SELECT * FROM Personne";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        while (data.Read())
        {
            Personne temp = new Personne(data.GetString(0), data.GetString(1), data.GetDateTime(2));
            personnes.Add(temp);
        }
        Personne[] personnesArray = new Personne[personnes.Count];
        con.Close();
        personnesArray = personnes.ToArray();
        return personnesArray;
    }
    public void insertWithEtat(Connexion c, string idSanter, int pourcentage){
        this.insert(c);
        SqlConnection con = c.connexion();
        con.Open();
        string idPersonne = "";
        string sql = $"select * from personne where nom='{this.getNom()}'";
        SqlCommand command = new SqlCommand(sql,con);
        SqlDataReader data = command.ExecuteReader();
        if(data.Read()){
            idPersonne = data.GetString(0);
            MessageBox.Show(idPersonne);
            this.setIdPersonne(idPersonne);
        }
        con.Close();
        MessageBox.Show(pourcentage.ToString());
        con.Open();
        String sql2 = "INSERT INTO Etat (idSanter, idPersonne, pourcentage) VALUES (@idSanter, @idPersonne, @pourcentage)";
        SqlCommand cmd = new SqlCommand(sql2,con);
        cmd.Parameters.AddWithValue("@idSanter", idSanter);
        cmd.Parameters.AddWithValue("@idPersonne", this.getIdPersonne());
        cmd.Parameters.AddWithValue("@pourcentage", pourcentage);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        String sql = $"INSERT INTO Personne (nom, dateDeNaissance) VALUES (@nom, CONVERT(datetime, @dateDeNaissance, 103))";
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.Parameters.AddWithValue("@nom", this.getNom());
        cmd.Parameters.AddWithValue("@dateDeNaissance", this.getDateDeNaissance().ToString("dd/MM/yyyy"));
        MessageBox.Show(cmd.CommandText);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}

