using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectNewApi.Models
{
    public class Studio
    {
        [Key]
        public int StudioId { get; set; }
        public string Naziv { get; set; }
        public Lokacija Lokacija { get; set; }
        public int VlasnikId { get; set; }
        public List<User> Instruktori { get; set; } = new List<User>();
        public string StudioImageUrl { get; set; }

    }
}
