using System.Data.SqlClient;
namespace Sakafo_isan_andro;

public class EmploiDuTemp
{
    private string idEmploiDuTemp;
    private string idPersonne;

    public EmploiDuTemp(string idEmploiDuTemp, string idPersonne)
    {
        this.setIdEmploiDuTemp(idEmploiDuTemp);
        this.setIdPersonne(idPersonne);
    }

    public EmploiDuTemp()
    {
    }

    public string getIdEmploiDuTemp()
    {
        return idEmploiDuTemp;
    }

    public void setIdEmploiDuTemp(string idEmploiDuTemp)
    {
        this.idEmploiDuTemp = idEmploiDuTemp;
    }

    public string getIdPersonne()
    {
        return idPersonne;
    }

    public void setIdPersonne(string idPersonne)
    {
        this.idPersonne = idPersonne;
    }

    public EmploiDuTemp[] getDonnee(Connexion c)
    {
        List<EmploiDuTemp> emplois = new List<EmploiDuTemp>();
        SqlConnection con = c.connexion();
        con.Open();
        String sql = "SELECT * FROM EmploiDuTemp";
        SqlCommand command = new SqlCommand(sql, con);
        SqlDataReader data = command.ExecuteReader();
        while (data.Read())
        {
            EmploiDuTemp temp = new EmploiDuTemp(data.GetString(0), data.GetString(1));
            emplois.Add(temp);
        }
        EmploiDuTemp[] emploisDuTemp = new EmploiDuTemp[emplois.Count];
        con.Close();
        emploisDuTemp = emplois.ToArray();
        return emploisDuTemp;
    }

    public void insert(Connexion c)
    {
        SqlConnection con = c.connexion();
        con.Open();
        String sql = "INSERT INTO EmploiDuTemp (idPersonne) VALUES ('@idPersonne')";
        SqlCommand cmd = new SqlCommand(sql);
        cmd.Parameters.AddWithValue("@idPersonne", this.getIdPersonne());
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
