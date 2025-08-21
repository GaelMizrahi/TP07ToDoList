namespace TP07.Models;

using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString =
        "Server=localhost;Database=ToDoList;Integrated Security=True;TrustServerCertificate=True;";

    public static Usuario Login(string username, string password)
    {
        Usuario usuario;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE [username] = @username AND [password] = @password";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { username, password });
        }
        return usuario;
    }

    public static bool sePuedeRegistrar(Usuario usuario)
    {
        bool sePudo;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE username = @username";
            Usuario existente = connection.QueryFirstOrDefault<Usuario>(query, new { username = usuario.username });
            sePudo = (existente == null);
        }
        return sePudo;
    }

    public static bool registrar(Usuario usuario)
    {
        bool sePudo = sePuedeRegistrar(usuario);
        if (sePudo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Usuarios (username, password, nombre, apellido, foto, ultimoLogin)
                                 VALUES (@username, @password, @nombre, @apellido, @foto, @ultimoLogin)";
                connection.Execute(query, new
                {
                    username = usuario.username,
                    password = usuario.password,
                    nombre = usuario.nombre,
                    apellido = usuario.apellido,
                    foto = usuario.foto,
                    ultimoLogin = usuario.ultimoLogin
                });
            }
        }
        return sePudo;
    }

    public static void ActualizarFechaLogin(int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Usuarios SET ultimoLogin = @fecha WHERE id = @idUsuario";
            connection.Execute(query, new { fecha = DateTime.Now, idUsuario });
        }
    }

   
    public static List<Tarea> TraerTareas(int idUsuario)
    {
        List<Tarea> tareas;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE idUsuario = @idUsuario";
            tareas = connection.Query<Tarea>(query, new { idUsuario }).ToList();
        }
        return tareas;
    }

    public static void CrearTarea(Tarea tarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"INSERT INTO Tareas (titulo, descripcion, fecha, finalizada, idUsuario)
                             VALUES (@titulo, @descripcion, @fecha, @finalizada, @idUsuario)";
            connection.Execute(query, new
            {
                titulo = tarea.titulo,
                descripcion = tarea.descripcion,
                fecha = tarea.fecha,
                finalizada = tarea.finalizada,
                idUsuario = tarea.idUsuario
            });
        }
    }

    public static void EliminarTarea(int idTarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE FROM Tareas WHERE id = @idTarea";
            connection.Execute(query, new { idTarea });
        }
    }

    public static Tarea TraerTareaAEditar(int id)
    {
        Tarea tareaAEditar;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE id = @id";
            tareaAEditar = connection.QueryFirstOrDefault<Tarea>(query, new { id });
        }
        return tareaAEditar;
    }

    public static void ActualizarTarea(Tarea tarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"UPDATE Tareas
                             SET titulo = @titulo,
                                 descripcion = @descripcion,
                                 fecha = @fecha,
                                 finalizada = @finalizada
                             WHERE id = @ID AND idUsuario = @idUsuario";
            connection.Execute(query, new
            {
                titulo = tarea.titulo,
                descripcion = tarea.descripcion,
                fecha = tarea.fecha,
                finalizada = tarea.finalizada,
                ID = tarea.ID,
                idUsuario = tarea.idUsuario
            });
        }
    }

    public static void FinalizarTarea(int idTarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET finalizada = 1 WHERE id = @idTarea";
            connection.Execute(query, new { idTarea });
        }
    }
}