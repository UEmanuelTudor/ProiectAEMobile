using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProiectAEMobile.Models
{
    public class ProgramariList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string Descriere { get; set; }
        public DateTime Data { get; set; }

    }
}
