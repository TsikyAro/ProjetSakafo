using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

public class Connexion {
    private SqlConnection connection;
    public Connexion(){
        string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=Sakafo;Trusted_Connection=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        this.connection = connection;
    }
    public SqlConnection connexion()
    {
        return this.connection;
    }
}