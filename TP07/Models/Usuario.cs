namespace TP07.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


public class Usuario
{
  [JsonProperty]
    public int ID { get;  set; }

    

    public string username { get;  set; }

    

    public string password { get;  set; }

    
    public string nombre { get;  set; }

    
    public string apellido { get; set; }

    
    public DateTime ultimoLogin { get;  set; }
    
    public string foto{get; set;}

    public Usuario()
    {
    
    }

}