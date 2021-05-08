using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lesconario.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double? Code { get; set; }
        public int? Quantity { get; set; }
        public bool IsVisible { get; set; }
    }
}
