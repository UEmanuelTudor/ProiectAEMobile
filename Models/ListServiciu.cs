using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectAEMobile.Models
{
    public class ListServiciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ProgramariList))]
        public int ProgramariListID { get; set; }
        public int ServiciuID { get; set; }
    }
}
