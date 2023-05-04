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
    public Sakafo[] sakafoJour(Connexion c, DateTime date)
    {
        Random random = new Random();
        Sakafo temp = new Sakafo();
        Personne[] present = this.disponible(c,date);
        List<Sakafo> composant = new List<Sakafo>();
        if(checkMarary(c,present))
        {
            Sakafo[] lh = temp.legumeBas(c);
            composant.Add(lh[random.Next(0,lh.Length-1)]);
        }
        Sakafo[] lb = temp.legumeHaut(c);
        composant.Add(lb[random.Next(0,lb.Length-1)]);
        Sakafo[] vb = temp.viandeRouge(c);
        composant.Add(vb[random.Next(0,vb.Length-1)]);
        Sakafo[] vr = temp.viandeBlanche(c);
        composant.Add(vr[random.Next(0,vr.Length-1)]);
        Sakafo[] ab = temp.abbat(c);
        composant.Add(ab[random.Next(0,ab.Length-1)]);
        Sakafo[] ac = temp.accompanement(c);
        composant.Add(ac[random.Next(0,ac.Length-1)]);

        Sakafo[] resultat = new Sakafo[composant.Count];
        resultat = composant.ToArray();
        return resultat;
    }
    public Personne[] disponible(Connexion c, DateTime date)
    {
        Personne[] personnes = this.getMembreFamille(c);
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
        string sql = "INSERT INTO Famille (nom) VALUES (@nom)";
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.Parameters.AddWithValue("@nom", this.getNom());
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
