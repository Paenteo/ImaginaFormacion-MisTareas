using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MisTareas
{
    class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
