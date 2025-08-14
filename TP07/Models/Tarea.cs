namespace TP07.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


public class Tarea
{
  
    public int ID { get; private set; }

    

    public string titulo { get; private set; }

    

    public string descripcion { get; private set; }

    
    public DateTime fecha { get; private set; }

    
    public bool finalizada { get; private set; }
    public bool idUsuario { get; private set; }

    public Tarea()
    {
        
    }

}