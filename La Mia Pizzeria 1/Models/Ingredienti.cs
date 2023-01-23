using System.Text.Json.Serialization;

namespace La_Mia_Pizzeria_1.Models
{
    public class Ingredienti
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Pizza> Pizza { get; set; }

        public Ingredienti()
        {

        }
    }
}
