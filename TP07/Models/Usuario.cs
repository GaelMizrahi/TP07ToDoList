namespace TP07.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


public class Usuario
{
  [JsonProperty]
    public int ID { get; private set; }

    [JsonProperty]

    public string username { get; private set; }

    [JsonProperty]

    public string password { get; private set; }

    [JsonProperty]
    public string nombre { get; private set; }

    [JsonProperty]
    public string apellido { get; private set; }

    [JsonProperty]
    public DateTime ultimoLogin { get; private set; }
    [JsonProperty]
    public string foto{get;private set;}

    public Usuario()
    {
    
    }

}