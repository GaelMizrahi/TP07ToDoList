namespace TP07.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


public class Tarea
{
  [JsonProperty]
    public int ID { get; private set; }

    [JsonProperty]

    public string titulo { get; private set; }

    [JsonProperty]

    public string descripcion { get; private set; }

    [JsonProperty]
    public DateTime fecha { get; private set; }

    [JsonProperty]
    public bool finalizada { get; private set; }

    public Tarea()
    {
        
    }

}