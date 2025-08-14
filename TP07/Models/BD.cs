namespace TP07.Models;
using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
{
    private static string _connectionString = @"Server=localhost; 
    DataBase ToDoList; Integrated Security=True; TrustServerCertificate=True;";
    public static Usuario Login(string username, string password)
{
    Usuario usuarios = new Usuario ();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Usuarios WHERE username = @username AND password = @password";
        usuarios = connection.QueryFirstOrDefault<Usuario>(query, new {username, password});
    }
     return usuarios;

}
    
    public static bool sePuedeRegistrar(Usuario usuario)
    {
       bool sepudo = false;
       using(SqlConnection connection = new SqlConnection(_connectionString))
       {
          string query = "SELECT * FROM Usuarios WHERE username = @username";
          usuario = connection.QueryFirstOrDefault<Usuario>(query, new {username = usuario.username});
          if(usuario == null)
          {
            sepudo = true;
            
          }
        return sepudo;
    }
}
    public static bool registrar ( Usuario usuario)
    {
        bool sePudo = sePuedeRegistrar (usuario);
        if(sePudo == true)
        {
        string query = "INSERT INTO Usuarios (username, password, nombre, apellido, foto, ultimoLogin VALUES )VALUES (@Username, @Password, @Nombre, @Apellido, @Foto, @UltimoLogin)";
         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
           
           connection.Execute(query, new {username = usuario.username, password = usuario.password, nombre = usuario.nombre, apellido = usuario.apellido, foto = usuario.foto, ultimoLogin = usuario.ultimoLogin});
        }
        }
       return sePudo;
    }

    public static List<Tarea> TraerTareas(int idUsuario)
    {
        bool sePudo = false;
        List <Tarea> tareas = new List<Tarea>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Tareas WHERE idUsuario = @idUsuario";
        tareas = connection.Query<Tarea>(query, new { idUsuario }).ToList();
    }
        return tareas;
    }

    public static void CrearTarea(Tarea tarea)
    {
        string query = "INSERT INTO Tareas (id, titulo, descripcion, fecha, finalizada, idUsuario) VALUES (@id, @titulo, @descripcion, @fecha, @finalizada, @idUsuario)";
        using(SqlConnection connection = new SqlConnection(_connectionString))
    {      
        connection.Execute(query, new {id = tarea.id, titulo = tarea.titulo, descripcion = tarea.descripcion, fecha = tarea.fecha, finalizada = tarea.finalizada, idUsuario = tarea.idUsuario });
    }
    
    }
    public static void EliminarTarea(int IdTarea)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "DELETE FROM Tareas WHERE id = @idTarea";
        connection.Execute(query, new { idTarea });
    }
}
    
      public static Tarea TraerTareaAEditar(int ID)
    {
        Tarea tareaAEditar = new Tarea();
        using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Tareas WHERE ID = @ID";
        tareaAEditar = connection.QueryFirstOrDefault<Tarea> (query, new { ID });        

    }
    return tareaAEditar;
 
    }
    public static void ActualizarTarea(Tarea tarea)
    {
        Tarea Tact = new Tarea();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
           string query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, fecha = @fecha, finalizada = @finalizada WHERE id = @id   WHERE ID = @ID AND idUsuario = @idUsuario;";
             connection.Execute(query, new {
             titulo = tarea.titulo,
            descripcion = tarea.descripcion,
            fecha = tarea.fecha,
            finalizada = tarea.finalizada,
            idUsuario = tarea.idUsuario});
        }
    }
        
 public static void FinalizarTarea(int idTarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET finalizada = 1 WHERE ID = @idTarea";
            connection.Execute(query, new { idTarea });
        }
    }

   public static void ActualizarFechaLogin(int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Usuarios SET ultimoLogin = @fecha WHERE Id = @idUsuario";
            connection.Execute(query, new { fecha = DateTime.Now, idUsuario });
        }
    }
}