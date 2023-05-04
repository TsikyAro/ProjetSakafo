using System.Collections.Generic;
using System.Data.SqlClient;
namespace Sakafo_isan_andro;

public class Famille
{
    private string idFamille;
    private string nom;

    public Famille(string idFamille, string nom)
    {
        this.setIdFamille(idFamille);
        this.setNom(nom);
    }

    public Famille()
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

    public string getNom()
    {
        return nom;
    }

    public void setNom(string nom)
    {
        this.nom = nom;
    }

    public Famille[] getDonnee(Connexion c)
    {
        List<Famille> familles = new List<Famille>();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "SELECT * FROM Famille";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        while (data.Read())
        {
            Famille temp = new Famille(data.GetString(0), data.GetString(1));
            familles.Add(temp);
        }
        Famille[] familleArray = new Famille[familles.Count];
        con.Close();
        familleArray = familles.ToArray();
        return familleArray;
    }
    public string getIdFamille(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        string result = "";
        string sql = $"SELECT idFamille FROM Famille where nom ='{this.getNom()}'";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        if (data.Read())
        {
            result = data.GetString(0);
        }
        con.Close();
        return result;
    }

    public Personne[] getMembreFamille(Connexion c)
    {
        List<Personne> personnes = new List<Personne>();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = $"select p.* from personne p left join membreFamille m on p.idPersonne = m.idPersonne where m.idFamille='{this.getIdFamille()}'";
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
    public void insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "INSERT INTO Famille (nom) VALUES (@nom)";
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.Parameters.AddWithValue("@nom", this.getNom());
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
