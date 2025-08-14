namespace TP07.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


public class Usuario
{
  [JsonProperty]
    public int ID { get; private set; }

    

    public string username { get; private set; }

    

    public string password { get; private set; }

    
    public string nombre { get; private set; }

    
    public string apellido { get; private set; }

    
    public DateTime ultimoLogin { get; private set; }
    
    public string foto{get;private set;}

    public Usuario()
    {
    
    }

}