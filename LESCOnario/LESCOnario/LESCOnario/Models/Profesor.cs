using System.Collections.Generic;
using SQLite;

namespace Lesconario.Models
{
    public class Profesor
    {
        [PrimaryKey]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int idU { get; set; }
        public bool IsVisible { get; set; }
    }
}