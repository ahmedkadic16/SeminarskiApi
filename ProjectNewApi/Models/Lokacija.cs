using System.ComponentModel.DataAnnotations;

namespace ProjectNewApi.Models
{
    public class Lokacija
    {
        [Key]
        public int LokacijaId { get; set; }
        public string Grad { get; set; }
        public string Opcina { get; set;}
        public string Mjesto { get; set;}
        public string Adresa { get; set; }
        public int PostanskiBroj { get; set; }
    }
}
