using System.Collections.Generic;
using SQLite;

namespace Lesconario.Models
{
    public class CursoxProfe
    {
        [PrimaryKey, AutoIncrement]
        public int num { get; set; }
        public string nombre { get; set; }
        public bool IsVisible { get; set; }
        public int id { get; set; }
    }
}
