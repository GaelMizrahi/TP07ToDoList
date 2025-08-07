namespace TP07.Models;
using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost; 
    DataBase ToDoList; Integrated Security=True; TrustServerCertificate=True;";
    public List<Usuario> IniciarSesion(string username, string password)
{
    List <Usuario> usuarios = new List<Usuario>();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrante WHERE username = @username AND password = @password";
        usuarios = connection.Query<Usuario>(query).ToList();
    }
     return usuarios;

}




}
