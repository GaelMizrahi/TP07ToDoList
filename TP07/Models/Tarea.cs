namespace TP07.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


public class Tarea
{
  
    public int ID { get;  set; }

    

    public string titulo { get;  set; }

    

    public string descripcion { get; set; }

    
    public DateTime fecha { get;  set; }

    
    public bool finalizada { get;  set; }
    public int idUsuario { get;  set; }

    public Tarea()
    {
        
    }

}