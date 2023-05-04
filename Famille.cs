using System.Collections.Generic;
using System.Data.SqlClient;
namespace Sakafo_isan_andro;

public class Famille
{
    private string idFamille;
    private string nom;
    private double salaire;
    public double getSalaire()
    {
        return this.salaire;
    }
    public void setSalaire(double salaire)
    {
        this.salaire = salaire;
    }

    public Famille(string idFamille, string nom, double salaire)
    {
        this.setIdFamille(idFamille);
        this.setNom(nom);
        this.setSalaire(salaire);
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
            Famille temp = new Famille(data.GetString(0), data.GetString(1),data.GetDouble(2));
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
    public Personne[] disponible(Connexion c,Personne[] personnes, DateTime date)
    {
        List<Personne> list = new List<Personne>();
        foreach (Personne personne in personnes)
        {
            if(personne.getDisponibilite(c,date) == 1)
            {
                list.Add(personne);
            }
        }
        Personne[] tpersonne = new Personne[list.Count];
        return tpersonne;
    }
    public bool checkMarary(Connexion c, Personne[] pers)
    {
        foreach (Personne personne in pers)
        {
            if(personne.mararyVe(c))
            {
                return true;
            }
        }
        return false;
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
        string sql = "INSERT INTO Famille (nom,salaire) VALUES (@nom,@salaire)";
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.Parameters.AddWithValue("@nom", this.getNom());
        cmd.Parameters.AddWithValue("@salaire", this.getSalaire());
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
