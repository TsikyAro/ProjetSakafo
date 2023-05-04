using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sakafo_isan_andro;
public class Santer
{
    private string idSanter;
    private string nom;

    public Santer(string idSanter, string nom)
    {
        this.setIdSanter(idSanter);
        this.setNom(nom);
    }

    public Santer()
    {
    }

    public string getIdSanter()
    {
        return idSanter;
    }

    public void setIdSanter(string idSanter)
    {
        this.idSanter = idSanter;
    }

    public string getNom()
    {
        return nom;
    }

    public void setNom(string nom)
    {
        this.nom = nom;
    }

    public Santer[] getDonnee(Connexion c)
    {
        List<Santer> santers = new List<Santer>();
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "SELECT * FROM Santer";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        while (data.Read())
        {
            Santer temp = new Santer(data.GetString(0), data.GetString(1));
            santers.Add(temp);
        }
        Santer[] santerList = new Santer[santers.Count];
        con.Close();
        santerList = santers.ToArray();
        return santerList;
    }

    public void insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        string sql = "INSERT INTO Santer (nom) VALUES ('@nom')";
        SqlCommand cmd = new SqlCommand(sql);
        cmd.Parameters.AddWithValue("@nom", this.getNom());
        cmd.ExecuteNonQuery();
        con.Close();
    }
}